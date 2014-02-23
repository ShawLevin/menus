using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Menulator.Models;
using System.Linq;

namespace Menulator.Controllers
{
    
    public class RestaurantController : ApiController
    {
        List<Restaurant> restaurants = new List<Restaurant> { new Restaurant { ID = 0, Name = "Drexel Pizza", Description = "Pizza pizza." }, new Restaurant { ID = 1, Name = "Sabrains", Description = "Brunch" } };
        // GET api/values
        public List<Restaurant> Get()
        {
            return restaurants;
        }

        // GET api/values/5
        public Restaurant Get(int id)
        {
            var Selected = from r in restaurants
                    where r.ID == id
                    select r;
            if (Selected.Count() > 0)
                return Selected.ElementAt(0);
            else
                return null;
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
