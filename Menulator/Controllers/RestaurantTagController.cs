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

namespace Menulator.Controllers
{
    public class RestaurantTagController : ApiController
    {
        private MenulatorContext db = new MenulatorContext();

        // GET api/RestaurantTag
        public IQueryable<RestaurantTag> GetRestaurantTags()
        {
            return db.RestaurantTags;
        }

        [HttpGet]
        public IQueryable<RestaurantTag> Search(int id)
        {
            return (from x in db.RestaurantTags where x.RestaurantID == id select x);
        }

        // GET api/RestaurantTag/5
        [ResponseType(typeof(RestaurantTag))]
        public IHttpActionResult GetRestaurantTag(int id)
        {
            RestaurantTag restauranttag = db.RestaurantTags.Find(id);
            if (restauranttag == null)
            {
                return NotFound();
            }

            return Ok(restauranttag);
        }

        // PUT api/RestaurantTag/5
        public IHttpActionResult PutRestaurantTag(int id, RestaurantTag restauranttag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restauranttag.RestaurantTagID)
            {
                return BadRequest();
            }

            db.Entry(restauranttag).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantTagExists(id))
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

        // POST api/RestaurantTag
        [ResponseType(typeof(RestaurantTag))]
        public IHttpActionResult PostRestaurantTag(RestaurantTag restauranttag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantTags.Add(restauranttag);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restauranttag.RestaurantTagID }, restauranttag);
        }

        // DELETE api/RestaurantTag/5
        [ResponseType(typeof(RestaurantTag))]
        public IHttpActionResult DeleteRestaurantTag(int id)
        {
            RestaurantTag restauranttag = db.RestaurantTags.Find(id);
            if (restauranttag == null)
            {
                return NotFound();
            }

            db.RestaurantTags.Remove(restauranttag);
            db.SaveChanges();

            return Ok(restauranttag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantTagExists(int id)
        {
            return db.RestaurantTags.Count(e => e.RestaurantTagID == id) > 0;
        }
    }
}