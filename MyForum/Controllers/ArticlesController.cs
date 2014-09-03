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
        // GET: Articles
        public ActionResult Index()
        {
            ArticlesContainer viewModel = new ArticlesContainer();
            ArticlesRepository obj = new ArticlesRepository();
            viewModel.FeaturedArticles = obj.GetFeaturedList();

            return View(viewModel);
        }

        public ActionResult Favorites()
        {
            ArticlesContainer viewModel = new ArticlesContainer();
            ArticlesRepository obj = new ArticlesRepository();
            viewModel.FeaturedArticles = obj.GetFeaturedList();

            return View(viewModel);
        }
    }
}