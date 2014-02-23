using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Helpers
{
    public class MenuItems
    {
        public int CategoryID { get; set; }
        public int ParentCategoryID { get; set; }
        public int MenuID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
    }
}