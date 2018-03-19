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
        public List<Article> Articles;
        public string search;

        [HttpGet]
        public ActionResult Index(int? page, string searchBar)
        {
            var dummyItems = GetAPIResponse(searchBar);
            var pager = new Pager(dummyItems.Count(), page);

            var viewModel = new IndexViewModel
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager,
                SearchBar = searchBar != null ? searchBar : ""
            };

            return View(viewModel);
        }

        public ActionResult Index(string searchBar)
        {
            var dummyItems = GetAPIResponse(searchBar);
            var pager = new Pager(dummyItems.Count(), 1);

            var viewModel = new IndexViewModel
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager,
                SearchBar = searchBar
            };

            return View(viewModel);
        }

        #region Helper functions

        private List<Article> GetAPIResponse(string query)
        {
            if (query == null)
            {
                query = "";
            }

            var url = "https://newsapi.org/v2/everything?" +
                "domains=bbc.co.uk&" +
                "pageSize=100&" +
                "page=" + "1" + "&" +
                "q=" + query + "&" +
                "apiKey=dbca6d85dbbd4e11b532b212af6282b5";

            var json = new WebClient().DownloadString(url);

            Articles = new List<Article>();

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

                Articles.Add(newArticle);
            }

            return Articles;
        }

        #endregion
    }
}