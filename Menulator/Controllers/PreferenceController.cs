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
    public class PreferenceController : ApiController
    {
        private MenulatorContext db = new MenulatorContext();

        // GET api/Preference
        public IQueryable<Preference> GetPreferences()
        {
            return db.Preferences;
        }

        // GET api/Preference/5
        [ResponseType(typeof(Preference))]
        public IHttpActionResult GetPreference(int id)
        {
            Preference preference = db.Preferences.Find(id);
            if (preference == null)
            {
                return NotFound();
            }

            return Ok(preference);
        }

       //Brian
       [HttpGet]
       [Route("api/preference/getbyuser/{member}")]
       public IQueryable<Preference> GetUserPreferences(int memberID)
       {
           return (from x in db.Preferences where (x.MemberID == memberID) select x);
       }
       
        // PUT api/Preference/5
        public IHttpActionResult PutPreference(int id, Preference preference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preference.PreferenceID)
            {
                return BadRequest();
            }

            db.Entry(preference).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreferenceExists(id))
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

        // POST api/Preference
        [ResponseType(typeof(Preference))]
        public IHttpActionResult PostPreference(Preference preference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Preferences.Add(preference);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = preference.PreferenceID }, preference);
        }

        // DELETE api/Preference/5
        [ResponseType(typeof(Preference))]
        public IHttpActionResult DeletePreference(int id)
        {
            Preference preference = db.Preferences.Find(id);
            if (preference == null)
            {
                return NotFound();
            }

            db.Preferences.Remove(preference);
            db.SaveChanges();

            return Ok(preference);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreferenceExists(int id)
        {
            return db.Preferences.Count(e => e.PreferenceID == id) > 0;
        }
    }
}