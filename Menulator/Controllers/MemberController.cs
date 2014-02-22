using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Menulator.Models;

namespace Menulator.Controllers
{
    public class MemberController : ApiController
    {
        List<Member> members = new List<Member> { new Member { MemberID = 1, Name = "Berian Lee", Email = "pizza@pizzama.com" }, new Member { MemberID = 2, Name = "Cheep cheep", Email = "pizza@asda.com" } };
        
        // GET api/values
        public List<Member> Get()
        {
            return members;
        }

        // GET api/values/5
        public Member Get(int id)
        {
            return members[id];
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