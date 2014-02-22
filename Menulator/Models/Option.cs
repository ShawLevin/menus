using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Menulator.Models
{
    public class Option
    {
        [Key]
        public int OptionID { get; set; }
        public int ItemID { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
        public int Max { get; set; }
    }
}