using NewsSite.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NewsSite.Controllers
{
    public class HomeController : Controller
    {
        public Articles Articles;
        public string search;
        public string paginationNumber;

        public ActionResult Index(string searchBar, string pageNumber)
        {
            if(pageNumber == null)
            {
                pageNumber = "1";
            }
            if (searchBar == null)
            {
                searchBar = "";
            }

            var url = "https://newsapi.org/v2/everything?" +
                "domains=bbc.co.uk&" +
                "pageSize=15&" +
                "page=" + pageNumber + "&" +
                "q=" + searchBar + "&" +
                "apiKey=dbca6d85dbbd4e11b532b212af6282b5";

            var json = new WebClient().DownloadString(url);

            Articles = new Articles();
            Articles.articles = new List<Article>();

            JObject jObject = JObject.Parse(json);
            JToken jArticles = jObject["articles"];
            JToken jSource;

            int i = 1;

            foreach (var article in jArticles)
            {
                Article newArticle = new Article();

                jSource = article["source"];

                newArticle.id = i.ToString();
                newArticle.source = (string)(jSource["id"]);
                newArticle.name = (string)(jSource["name"]);
                newArticle.author = (string)article["author"];
                newArticle.title = (string)article["title"];
                newArticle.description = (string)article["description"];
                newArticle.url = (string)article["url"];
                newArticle.urlToImg = (string)article["urlToImage"];
                newArticle.publishedDate = (string)article["publishedAt"];

                Articles.articles.Add(newArticle);
            }

            return View(Articles);
        }
        
        public PartialViewResult GetArticles(string searchBar, string pageNumber)
        {
            if (pageNumber == null)
            {
                pageNumber = "1";
            }
            if (searchBar == null)
            {
                searchBar = "";
            }
           
            var url = "https://newsapi.org/v2/everything?" +
                "domains=bbc.co.uk&" +
                "pageSize=15&" +
                "page=" + pageNumber + "&" +
                "q=" + searchBar + "&" +
                "apiKey=dbca6d85dbbd4e11b532b212af6282b5";

            var json = new WebClient().DownloadString(url);

            Articles = new Articles();
            Articles.articles = new List<Article>();

            JObject jObject = JObject.Parse(json);
            JToken jArticles = jObject["articles"];
            JToken jSource;

            int i = 1;

            foreach (var article in jArticles)
            {
                Article newArticle = new Article();

                jSource = article["source"];

                newArticle.id = i.ToString();
                newArticle.source = (string)(jSource["id"]);
                newArticle.name = (string)(jSource["name"]);
                newArticle.author = (string)article["author"];
                newArticle.title = (string)article["title"];
                newArticle.description = (string)article["description"];
                newArticle.url = (string)article["url"];
                newArticle.urlToImg = (string)article["urlToImage"];
                newArticle.publishedDate = (string)article["publishedAt"];

                Articles.articles.Add(newArticle);
            }


            return PartialView("_ArticlesView", Articles);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = Articles.articles.Find(x => x.id == id.ToString());
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }        
    }
}