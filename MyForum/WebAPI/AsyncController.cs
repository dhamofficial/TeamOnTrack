using MyForum.Entities;
using MyForum.Models;
using MyForum.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyForum.WebAPI
{
    public class AsyncController : ApiController
    {

        public IEnumerable<Article> Category(int? id)
        {
            ArticlesContainer viewModel = new ArticlesContainer();
            ArticlesRepository obj = new ArticlesRepository();
            return obj.GetFeaturedList();
        }


        // GET: api/Async
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Async/5
        public string Get(int? id)
        {
            return "value";
        }

        // POST: api/Async
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Async/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Async/5
        public void Delete(int id)
        {
        }
    }
}
