using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Menulator.Models
{
    public class Preference
    {
        [Key]
        public int PreferenceID { get; set; }
        public int UserID { get; set; }
        //Will be used to get any items which have the attribute defined by attribute (rather than relate to a specific item attribute)
        public string ItemTagValue { get; set; }
        public bool Flag { get; set; }
    }
}