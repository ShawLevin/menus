using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Menulator.Models
{
    public class ItemTag
    {
        [Key]
        public int ItemTagID { get; set; }
        public int ItemID { get; set; }
        public string Value { get; set; }
    }
}