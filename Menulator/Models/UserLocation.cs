using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Models
{
    public class UserLocation
    {
        public int UserLocationID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
    }
}