using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyForum.Entities
{
    public class Article
    {
        public int UID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string PostContent { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }

    public class Post
    {
        public int UID { get; set; }
        public string PostContent { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CreatedByName { get; set; }
    }
}