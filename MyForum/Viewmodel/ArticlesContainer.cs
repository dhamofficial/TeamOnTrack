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
        public IEnumerable<Team> Teams;

        public IEnumerable<Category> Categories;
        public IList<int> selectedCategories { get; set; }
    }
}