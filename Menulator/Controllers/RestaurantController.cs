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
using Thinktecture.IdentityModel;
using System.Web.Http.Cors;

namespace Menulator.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RestaurantController : ApiController
    {
        private MenulatorContext db = new MenulatorContext();

        // GET api/Restaurant
        public IQueryable<Restaurant> GetRestaurants()
        {
            return db.Restaurants;
        }

        [Route("api/restaurant/getbycity/{city}")]
        public IQueryable<Restaurant> GetRestaurantsByCity(string city)
        {
            return (from x in db.Restaurants where x.Description.Contains(city) select x);
        }

        [HttpGet]
        public IQueryable<Restaurant> Search(string filter)
        {
            List<int> ids = new List<int>();
            ids.AddRange((from x in db.RestaurantTags where x.Value.Contains(filter) select x.RestaurantID).ToList());
            return (from x in db.Restaurants where (x.Name.Contains(filter) || x.Description.Contains(filter)) || ids.Contains(x.RestaurantID) select x);
        }

        // GET api/Restaurant/5
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult GetRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // PUT api/Restaurant/5
        public IHttpActionResult PutRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.RestaurantID)
            {
                return BadRequest();
            }

            db.Entry(restaurant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
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

        // POST api/Restaurant
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult PostRestaurant([FromBody]Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurants.Add(restaurant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restaurant.RestaurantID }, restaurant);
        }

        // DELETE api/Restaurant/5
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            db.Restaurants.Remove(restaurant);
            db.SaveChanges();

            return Ok(restaurant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantExists(int id)
        {
            return db.Restaurants.Count(e => e.RestaurantID == id) > 0;
        }
    }
}