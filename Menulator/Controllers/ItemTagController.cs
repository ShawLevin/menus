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
    public class ItemTagController : ApiController
    {
        private MenulatorContext db = new MenulatorContext();

        // GET api/ItemTag
        public IQueryable<ItemTag> GetItemTags()
        {
            return db.ItemTags;
        }

        [HttpGet]
        public IQueryable<ItemTag> Search(int item)
        {
            return (from x in db.ItemTags where x.ItemID == item select x);
        }

        // GET api/ItemTag/5
        [ResponseType(typeof(ItemTag))]
        public IHttpActionResult GetItemTag(int id)
        {
            ItemTag itemtag = db.ItemTags.Find(id);
            if (itemtag == null)
            {
                return NotFound();
            }

            return Ok(itemtag);
        }

        // PUT api/ItemTag/5
        public IHttpActionResult PutItemTag(int id, ItemTag itemtag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemtag.ItemTagID)
            {
                return BadRequest();
            }

            db.Entry(itemtag).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTagExists(id))
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

        // POST api/ItemTag
        [ResponseType(typeof(ItemTag))]
        public IHttpActionResult PostItemTag(ItemTag itemtag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemTags.Add(itemtag);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemtag.ItemTagID }, itemtag);
        }

        // DELETE api/ItemTag/5
        [ResponseType(typeof(ItemTag))]
        public IHttpActionResult DeleteItemTag(int id)
        {
            ItemTag itemtag = db.ItemTags.Find(id);
            if (itemtag == null)
            {
                return NotFound();
            }

            db.ItemTags.Remove(itemtag);
            db.SaveChanges();

            return Ok(itemtag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemTagExists(int id)
        {
            return db.ItemTags.Count(e => e.ItemTagID == id) > 0;
        }
    }
}