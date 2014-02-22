using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Menulator.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //References the MemberID of the restaurant "Owner"
        public int Contact { get; set; } 
    }
}