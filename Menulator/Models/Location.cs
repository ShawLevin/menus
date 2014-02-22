using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Menulator.Models
{
    public class Location
    {
        [Key]
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}