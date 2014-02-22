using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Menulator.Models
{
    public class RestaurantTag
    {
        [Key]
        public int RestaurantTagID { get; set; }
        public int RestaurantID { get; set; }
        public string Value { get; set; }
    }
}