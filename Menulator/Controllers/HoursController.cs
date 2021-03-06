﻿using System;
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
    public class HoursController : ApiController
    {
        private MenulatorContext db = new MenulatorContext();

        // GET api/Hours
        public IQueryable<Hours> GetHours()
        {
            return db.Hours;
        }

        [HttpGet]
        public IQueryable<Hours> Search(int filter)
        {
            return (from x in db.Hours where x.LocationID==filter select x);
        }

        // GET api/Hours/5
        [ResponseType(typeof(Hours))]
        public IHttpActionResult GetHours(int id)
        {
            Hours hours = db.Hours.Find(id);
            if (hours == null)
            {
                return NotFound();
            }

            return Ok(hours);
        }

        // PUT api/Hours/5
        public IHttpActionResult PutHours(int id, Hours hours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hours.HoursID)
            {
                return BadRequest();
            }

            db.Entry(hours).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoursExists(id))
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

        // POST api/Hours
        [ResponseType(typeof(Hours))]
        public IHttpActionResult PostHours(Hours hours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hours.Add(hours);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hours.HoursID }, hours);
        }

        // DELETE api/Hours/5
        [ResponseType(typeof(Hours))]
        public IHttpActionResult DeleteHours(int id)
        {
            Hours hours = db.Hours.Find(id);
            if (hours == null)
            {
                return NotFound();
            }

            db.Hours.Remove(hours);
            db.SaveChanges();

            return Ok(hours);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HoursExists(int id)
        {
            return db.Hours.Count(e => e.HoursID == id) > 0;
        }
    }
}