using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        
        public int LocationID { get; set; }
    }
}