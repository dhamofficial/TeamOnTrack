using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyForum.Entities
{
    public class Category
    {
        public int UID { get; set; }
        public string CategoryName { get; set; }
        public bool Active { get; set; }
    }
}