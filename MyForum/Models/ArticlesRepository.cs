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
        public IEnumerable<Article> SearchArticles(SearchFilter filter)
        {
            IEnumerable<Article> list;

            StringBuilder sqlWhere = new StringBuilder();

            if (filter.CategoryID>0)
                sqlWhere.AppendFormat(" and a.CategoryId=@CategoryId");

            if (filter.IsFeatured)
                sqlWhere.Append(" and a.Featured=1 ");

            if (filter.ArticleID>0)
                sqlWhere.Append(" and a.UID=@articleID ");

            using (var dbContext = new DBContext())
            {
                list = dbContext.Connection.Query<Article>(@" select top 10 a.UID,a.[Title],a.ShortDescription,b.Firstname [CreatedByName],a.CreatedDate, c.CategoryName 
                    from Articles a
                    Inner Join Users b on b.UID = a.CreatedBy
                    LEFT outer join [Categories] c on c.UID = a.CategoryID
                    where a.Featured=1 " + sqlWhere + " order by UID desc ",
                                         new { CategoryID = filter.CategoryID, articleID = filter.ArticleID });
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

        public int SaveArticle(Article article)
        {
            var articleID = 0;

            using (var dbContext = new DBContext())
            {
                StringBuilder query = new StringBuilder();

                if (article.UID == 0)
                {
                    query.Append(@" DECLARE @LastArticleID int; INSERT INTO Articles(Title,CreatedBy,CreatedDate,LastUpdated,Status,ShortDescription,CategoryId)
                    VALUES (@title,@createdby,getdate(),getdate(),@status,@shortdescription,@categoryid) 
                    Select @LastArticleID = IDENT_CURRENT('Articles');

                    INSERT INTO ArticlePosts (ArticleID,PostContent,CreatedBy,CreatedDate,Status) 
                    VALUES (@LastArticleID, @postcontent,@createdby,getdate(),@status)
                    ");


                }
                else 
                {
                    query.Append(@" UPDATE Articles SET Title=@title,LastUpdated=@lastupdated,Status=@status,ShortDescription=@shortdescription,CategoryId=@categoryid )
                    WHERE UID=@LastArticleID ");
                }

                var result = dbContext.Connection.Execute(query.ToString(),
                    new { title = new DbString { Value = article.Title, IsAnsi=true },  status=article.Status
                    ,
                          shortdescription = article.ShortDescription,
                          postcontent = article.PostContent,
                          categoryid = article.CategoryID,
                          articleid=article.UID,
                          createdby=article.CreatedBy
                    });
            }

            return articleID;

        }
    }
}