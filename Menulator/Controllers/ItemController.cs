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
    public class ItemController : ApiController
    {
        private MenulatorContext db = new MenulatorContext();

        // GET api/Item
        public IQueryable<Item> GetItems()
        {
            return db.Items;
        }

        [HttpGet]
        public IQueryable<Item> Search(int filter)
        {
            return (from x in db.Items where x.CategoryID == filter select x);
        }


        [Route("api/Item/GetMostFrequentOrderByRestaurant/{restaurantID}")]
        // GET api/Order
        public IQueryable<Item> GetMostPopularItemByRestaurant(int restaurantID)
        {
            db.Restaurants.Find(restaurantID);
            IQueryable<Item> restaurantItems = (from x in db.Menus
                                                join y in db.Orders
                                                on x.MenuID equals y.MenuID
                                                join z in db.OrderItems
                                                on y.OrderID equals z.OrderID
                                                join a in db.Items
                                                on z.ItemID equals a.ItemID
                                                select a);

            var list = (from c in restaurantItems
                        group c by c into g
                        orderby g.Count() descending
                        select g.Key).Take(2);// FirstOrDefault();

            return list;
        }

        [HttpGet]
        public IQueryable<Item> GetItemsByUserPreference(int prefID)
        {
            String pref = db.Preferences.Find(prefID).ItemTagValue;
            IQueryable<int> itemIDs = (from x in db.ItemTags where x.Value == pref select x.ItemID);
            return (from x in db.Items where (itemIDs.Contains(x.ItemID)) select x);
        }

        // GET api/Item/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult GetItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT api/Item/5
        public IHttpActionResult PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.ItemID)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST api/Item
        [ResponseType(typeof(Item))]
        public IHttpActionResult PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Items.Add(item);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = item.ItemID }, item);
        }

        // DELETE api/Item/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            db.Items.Remove(item);
            db.SaveChanges();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Items.Count(e => e.ItemID == id) > 0;
        }
    }
}