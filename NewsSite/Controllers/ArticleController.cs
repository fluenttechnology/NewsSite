using NewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSite.Controllers
{
    public class ArticleController : Controller
    {
        public Article article;
        // GET: Article
        public ActionResult Index(string urlToImg, string title, string description)
        {
            article = new Article();
            article.urlToImg = urlToImg;
            article.title = title;
            article.description = description;

            return View(article);
        }
    }
}