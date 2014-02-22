using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menulator.Models
{
    public class ItemTag
    {
        public int ItemTagID { get; set; }
        public int ItemID { get; set; }
        public string Value { get; set; }
    }
}