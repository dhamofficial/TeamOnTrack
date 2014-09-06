using MyForum.Entities;
using MyForum.Models;
using MyForum.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyForum.Controllers
{
    public class ArticlesController : Controller
    {
        private SearchFilter filter { get; set; }

        public ArticlesController()
        {
            
            filter = new SearchFilter();
        }

        // GET: Articles
        public ActionResult Index()
        {
            var viewModel = GetArticleContainer(filter);

            return View(viewModel);
        }

        public ActionResult Favorites()
        {
            var viewModel = GetArticleContainer(filter);

            return View(viewModel);
        }

        public ActionResult Category(int? id)
        {
            filter.CategoryID = Convert.ToInt32(id);
            var viewModel = GetArticleContainer(filter);

            return View("Search",viewModel);
        }

        public ActionResult Team(int? id)
        {
            filter.TeamID = Convert.ToInt32(id);
            var viewModel = GetArticleContainer(filter);

            return View("Search", viewModel);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult NewPost()
        {
            return View();
        }

        ArticlesContainer GetArticleContainer(SearchFilter filter)
        {
            ArticlesContainer viewModel = new ArticlesContainer();
            ArticlesRepository obj = new ArticlesRepository();
            TeamRepository teamObj = new TeamRepository();

            viewModel.FeaturedArticles = obj.SearchArticles(filter);
            viewModel.Categories = obj.GetCategories();
            viewModel.Teams = teamObj.GetTeams();

            return viewModel;
        }
    }
}