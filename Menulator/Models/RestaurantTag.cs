using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Models
{
    public class RestaurantTag
    {
        public int RestaurantTagID { get; set; }
        public int RestaurantID { get; set; }
        public string Value { get; set; }
    }
}