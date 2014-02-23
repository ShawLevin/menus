using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Menulator.Models;
using Menulator.DataAccess;
using System.Web.Http.Cors;

namespace Menulator.Controllers
{
    [EnableCors("*", "*", "*")]
    public class MenuController : ApiController
    {
        private MenulatorContext db = new MenulatorContext();

        // GET api/Menu
        public IQueryable<Menu> GetMenus()
        {
            return db.Menus;
        }

        [HttpGet]
        public IQueryable<Menu> Search(int filter)
        {
            return (from x in db.Menus where x.MenuID == filter select x);
        }

        // GET api/Menu/5
        [ResponseType(typeof(Menu))]
        public IHttpActionResult GetMenu(int id)
        {
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        // PUT api/Menu/5
        public IHttpActionResult PutMenu(int id, Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menu.MenuID)
            {
                return BadRequest();
            }

            db.Entry(menu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Menu
        [ResponseType(typeof(Menu))]
        public IHttpActionResult PostMenu(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Menus.Add(menu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = menu.MenuID }, menu);
        }

        // DELETE api/Menu/5
        [ResponseType(typeof(Menu))]
        public IHttpActionResult DeleteMenu(int id)
        {
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return NotFound();
            }

            db.Menus.Remove(menu);
            db.SaveChanges();

            return Ok(menu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuExists(int id)
        {
            return db.Menus.Count(e => e.MenuID == id) > 0;
        }

        [Route("api/menu/getdatetime")]
        [ResponseType(typeof(DateTime))]
        public IHttpActionResult GetDateTime()
        {
            return Ok(DateTime.Now);
        }

        // GET api/Menu/GetCurrentMenu/5
        [Route ("api/menu/getcurrentmenu/{restaurantID}")]
        [ResponseType(typeof(Menu))]
        public IHttpActionResult GetCurrentMenu(int restaurantID)
        {
            IQueryable<Menu> allMenusForRestaurant = db.Menus.Where(menu => menu.RestaurantID == restaurantID);

            //Convert the hour to ETC before comparing
            int currentHour = (24 + (DateTime.Now.ToUniversalTime().Hour - 5)) % 24;
            int currentMinute = DateTime.Now.Minute;

            IEnumerable<Menu> currentMenu = from menu in allMenusForRestaurant
                                            where
                                            (menu.Starting.Hour <= currentHour
                                            ||
                                            (menu.Starting.Hour == currentHour &&
                                            menu.Starting.Minute <= currentMinute))
                                            &&
                                            (menu.Ending.Hour > currentHour
                                            ||
                                            (menu.Ending.Hour == currentHour &&
                                            menu.Ending.Minute > currentMinute))
                                            orderby menu.Starting.Hour
                                            select menu;

            if (currentMenu.Count() == 0)
            {
                return NotFound();
            }

            return Ok(currentMenu.FirstOrDefault());
        }


        // GET api/Menu/GetAllMenusForRestaurant/5
        [Route("api/menu/GetAllMenusForRestaurant/{restaurantID}")]
        [HttpGet]
        public IQueryable<Menu> GetAllMenusForRestaurant(int restaurantID)
        {
            return (from x in db.Menus where x.RestaurantID == restaurantID select x);
        }
    }
}