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
using Menulator.Helpers;
using System.Web.Http.Cors;

namespace Menulator.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CategoryController : ApiController
    {
        private MenulatorContext db = new MenulatorContext();

        // GET api/Category
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }

        [HttpGet]
        public IQueryable<MenuItems> Search(int filter)
        {
            IQueryable<MenuItems> items = (from c in db.Categories join i in db.Items on c.CategoryID equals i.CategoryID select new MenuItems { CategoryID = c.CategoryID, Description = c.Description, Details = i.Description, ItemID = i.ItemID, MenuID = c.MenuID, Name = c.Name, ParentCategoryID = c.ParentCategoryID, Price = i.Price, Title = i.Title });
            return (from x in items where x.MenuID == filter select x);
        }

        // GET api/Category/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT api/Category/5
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST api/Category
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryID }, category);
        }

        // DELETE api/Category/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.CategoryID == id) > 0;
        }
    }
}