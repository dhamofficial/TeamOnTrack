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
            var viewModel = GetFeaturedtArticleContainer(filter);
            return View(viewModel);
        }

        public ActionResult Favorites()
        {
            var viewModel = GetArticleContainer(filter);

            return View(viewModel);
        }

        public ActionResult MyArticles()
        {
            var viewModel = GetArticleContainer(filter);

            return View(viewModel);
        }

        public ActionResult Article(int? id)
        {
            filter.ArticleID = Convert.ToInt32(id);
            var viewModel = GetArticleContainer(filter);

            return View("NewPost", viewModel);
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
            var viewModel = GetArticleContainer(filter);
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult NewPost(Article model)
        {
            ArticlesRepository articleRepo = new ArticlesRepository();
            model.Status = "New";

            var articleid = articleRepo.SaveArticle(model);

            MessageContainer msgContainer = new MessageContainer();
            msgContainer.Message = "Article Created Successfully.";
            msgContainer.MessageType = "success";

            return Json(msgContainer);
        }

        ArticlesContainer GetFeaturedtArticleContainer(SearchFilter filter)
        {
            ArticlesContainer viewModel = new ArticlesContainer();
            ArticlesRepository obj = new ArticlesRepository();
            TeamRepository teamObj = new TeamRepository();
            filter.IsFeatured = true;
            viewModel.FeaturedArticles = obj.SearchArticles(filter);
            viewModel.Categories = obj.GetCategories();
            viewModel.Teams = teamObj.GetTeams();

            return viewModel;
        }

        ArticlesContainer GetArticleContainer(SearchFilter filter)
        {
            ArticlesContainer viewModel = new ArticlesContainer();
            ArticlesRepository obj = new ArticlesRepository();
            TeamRepository teamObj = new TeamRepository();

            viewModel.FeaturedArticles = obj.SearchArticles(filter);
            viewModel.Categories = obj.GetCategories();
            viewModel.Teams = teamObj.GetTeams();

            Article selectedArticle = new Article();
            if (filter != null && filter.ArticleID > 0 && viewModel.FeaturedArticles.Count() > 0)
            {
                selectedArticle = viewModel.FeaturedArticles.FirstOrDefault();
            }
            viewModel.SelectedArticle = selectedArticle;

            return viewModel;
        }
    }
}