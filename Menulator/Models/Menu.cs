using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Models
{
    public class Menu
    {
        public int MenuID { get; set; }
        public int RestaurantID { get; set; }
        public string Title { get; set; }
        public DateTime Starting { get; set; }
        public DateTime Ending { get; set; }
    }
}