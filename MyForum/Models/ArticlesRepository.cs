using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using MyForum.Entities;

namespace MyForum.Models
{
    public class ArticlesRepository
    {
        public IEnumerable<Article> GetFeaturedList()
        {
            IEnumerable<Article> list;

            using (var dbContext = new DBContext())
            {
                list = dbContext.Connection.Query<Article>(@" select UID,[Title] from Articles  ", new { });
            }

            return list;
        }
    }
}