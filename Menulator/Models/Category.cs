using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Menulator.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public int ParentCategoryID { get; set; }
        public int MenuID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}