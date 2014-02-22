using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Models
{
    public class Location
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
        public int RestaurantID { get; set; }

        public int HourID{ get; set; }
        
        public int MenuID { get; set; }
        
    }
}