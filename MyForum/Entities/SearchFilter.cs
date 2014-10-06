using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyForum.Entities
{
    public class SearchFilter
    {
        public int ArticleID { get; set; }
        public int CategoryID { get; set; }
        public int TeamID { get; set; }

        public bool IsFeatured { get; set; }
    }
}