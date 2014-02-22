using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Menulator.Models;

namespace Menulator.Controllers
{
    
    public class RestaurantController : ApiController
    {
        List<Restaurant> restaurants = new List<Restaurant> { new Restaurant { ID = 1, Name = "Drexel Pizza", Description = "Pizza pizza." }, new Restaurant { ID = 2, Name = "Sabrains", Description = "Brunch" } };
        // GET api/values
        public List<Restaurant> Get()
        {
            return restaurants;
        }

        // GET api/values/5
        public Restaurant Get(int id)
        {
            return restaurants[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
