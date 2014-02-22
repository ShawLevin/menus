using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //References the MemberID of the restaurant "Owner"
        public int Contact { get; set; } 
    }
}