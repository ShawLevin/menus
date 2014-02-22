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
    public class UserLocationController : ApiController
    {
        private MenulatorContext db = new MenulatorContext();

        // GET api/UserLocation
        public IQueryable<UserLocation> GetUserLocations()
        {
            return db.UserLocations;
        }

        // GET api/UserLocation/5
        [ResponseType(typeof(UserLocation))]
        public IHttpActionResult GetUserLocation(int id)
        {
            UserLocation userlocation = db.UserLocations.Find(id);
            if (userlocation == null)
            {
                return NotFound();
            }

            return Ok(userlocation);
        }

        // PUT api/UserLocation/5
        public IHttpActionResult PutUserLocation(int id, UserLocation userlocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userlocation.UserLocationID)
            {
                return BadRequest();
            }

            db.Entry(userlocation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLocationExists(id))
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

        // POST api/UserLocation
        [ResponseType(typeof(UserLocation))]
        public IHttpActionResult PostUserLocation(UserLocation userlocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserLocations.Add(userlocation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userlocation.UserLocationID }, userlocation);
        }

        // DELETE api/UserLocation/5
        [ResponseType(typeof(UserLocation))]
        public IHttpActionResult DeleteUserLocation(int id)
        {
            UserLocation userlocation = db.UserLocations.Find(id);
            if (userlocation == null)
            {
                return NotFound();
            }

            db.UserLocations.Remove(userlocation);
            db.SaveChanges();

            return Ok(userlocation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserLocationExists(int id)
        {
            return db.UserLocations.Count(e => e.UserLocationID == id) > 0;
        }
    }
}