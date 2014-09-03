using MyForum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyForum.Viewmodel
{
    public class ArticlesContainer
    {
        public IEnumerable<Article> FeaturedArticles;
    }
}