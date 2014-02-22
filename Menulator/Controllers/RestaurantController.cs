using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Menulator.Controllers
{
    public class RestaurantController : ApiController
    {
        string[] restaurants = new string[] { "Drexel Pizza", "Axis Pizza" };
        // GET api/values
        public IEnumerable<string> Get()
        {
            return restaurants;
        }

        // GET api/values/5
        public string Get(int id)
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
