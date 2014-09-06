using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using MyForum.Entities;
using System.Text;

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

        public IEnumerable<Article> SearchArticles(SearchFilter filter)
        {
            IEnumerable<Article> list;

            StringBuilder sqlWhere = new StringBuilder();

            if (filter.CategoryID>0)
                sqlWhere.AppendFormat(" and CategoryId=@CategoryId");

            using (var dbContext = new DBContext())
            {
                list = dbContext.Connection.Query<Article>(@" select UID,[Title] from Articles where 1=1 " + sqlWhere, new { CategoryID=filter.CategoryID });
            }

            return list;
        }

        public IEnumerable<Category> GetCategories()
        {
            IEnumerable<Category> list;

            using (var dbContext = new DBContext())
            {
                list = dbContext.Connection.Query<Category>(@" select UID,[CategoryName] from Categories where active = 1  ", new { });
            }

            return list;
        }
    }
}