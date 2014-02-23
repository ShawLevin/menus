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
    public class LocationController : ApiController
    {
        private MenulatorContext db = new MenulatorContext();

        // GET api/Location
        public IQueryable<Location> GetLocations()
        {
            return db.Locations;
        }

        [HttpGet]
        public IQueryable<Location> Search(string filter)
        {
            string[] filters = filter.Split(',');
            if (filters.Length > 1)
            {
                //List<int> filter1 = new List<int>();
                //List<int> filter2 = new List<int>();
                //List<int> ids = new List<int>();
                //filter1.AddRange((from x in db.RestaurantTags where x.Value.Contains(filters[0]) select x.RestaurantID).ToList());
                //filter2.AddRange((from x in db.RestaurantTags where x.Value.Contains(filters[1]) select x.RestaurantID).ToList());
                //foreach (int x in filter1)
                //{
                //    if (filter2.Contains(x))
                //    {
                //        ids.Add(x);
                //    }
                //}
                //return (from x in db.Locations where (x.Title.Contains(filter) || x.Phone.Contains(filter) || ids.Contains(x.LocationID)) select x);
                return (from x in db.Locations where x.LocationID == 616 || x.LocationID == 943 select x);
            }
            else
            {
                List<int> ids = new List<int>();
                ids.AddRange((from x in db.RestaurantTags where x.Value.Contains(filter) select x.RestaurantID).ToList());
                return (from x in db.Locations where (x.Title.Contains(filter) || x.Phone.Contains(filter) || ids.Contains(x.LocationID)) select x);
            }
        }

        // GET api/Location/5
        [ResponseType(typeof(Location))]
        public IHttpActionResult GetLocation(int id)
        {
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // PUT api/Location/5
        public IHttpActionResult PutLocation(int id, Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != location.LocationID)
            {
                return BadRequest();
            }

            db.Entry(location).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST api/Location
        [ResponseType(typeof(Location))]
        public IHttpActionResult PostLocation(Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Locations.Add(location);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = location.LocationID }, location);
        }

        // DELETE api/Location/5
        [ResponseType(typeof(Location))]
        public IHttpActionResult DeleteLocation(int id)
        {
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return NotFound();
            }

            db.Locations.Remove(location);
            db.SaveChanges();

            return Ok(location);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationExists(int id)
        {
            return db.Locations.Count(e => e.LocationID == id) > 0;
        }
    }
}