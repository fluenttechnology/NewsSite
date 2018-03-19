using NewsSite.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NewsSite.Controllers
{
    public class HomeController : Controller
    {
        public List<Article> Articles;
        public string search;

        //Paging through results by taking in a page id
        [HttpGet]
        public ActionResult Index(int? page, string searchBar)
        {
            //URL to call external news API with
            var url = "https://newsapi.org/v2/everything?" +
                "domains=bbc.co.uk&" +
                "pageSize=100&" +
                "page=" + "1" + "&" +
                "q=" + searchBar + "&" +
                "apiKey=dbca6d85dbbd4e11b532b212af6282b5";

            //Calling helper function to get Articles
            var dummyItems = GetAPIResponse(url);
            var pager = new Pager(dummyItems.Count(), page);

            //Load our viewModel full of data
            var viewModel = new IndexViewModel
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager,
                SearchBar = searchBar != null ? searchBar : ""
            };

            //draw page with viewModel data
            return View(viewModel);
        }


        //Base index function, uses search bar
        public ActionResult Index(string searchBar)
        {
            var url = "https://newsapi.org/v2/everything?" +
                "domains=bbc.co.uk&" +
                "pageSize=100&" +
                "page=" + "1" + "&" +
                "q=" + searchBar + "&" +
                "apiKey=dbca6d85dbbd4e11b532b212af6282b5";

            var dummyItems = GetAPIResponse(url);
            var pager = new Pager(dummyItems.Count(), 1);

            var viewModel = new IndexViewModel
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager,
                SearchBar = searchBar
            };

            return View(viewModel);
        }

        //Prebuilt function to browse popular news stories
        public ActionResult Popular(string searchBar)
        {
            var url = "https://newsapi.org/v2/everything?" +
                "domains=bbc.co.uk&" +
                "pageSize=100&" +
                "page=" + "1" + "&" +
                "q=" + searchBar + "&" +
                "sortBy=popularity&" +
                "apiKey=dbca6d85dbbd4e11b532b212af6282b5";

            var dummyItems = GetAPIResponse(url);
            var pager = new Pager(dummyItems.Count(), 1);

            var viewModel = new IndexViewModel
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View("Index", viewModel);
        }

        //Prebuilt function to browse US stories
        public ActionResult UnitedStates(string searchBar)
        {
            var url = "https://newsapi.org/v2/top-headlines?" +
                "country=us&" +
                "pageSize=100&" +
                "page=" + "1" + "&" +
                "q=" + searchBar + "&" +
                "apiKey=dbca6d85dbbd4e11b532b212af6282b5";

            var dummyItems = GetAPIResponse(url);
            var pager = new Pager(dummyItems.Count(), 1);

            var viewModel = new IndexViewModel
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View("Index", viewModel);
        }

        #region Helper functions

        private List<Article> GetAPIResponse(string url)
        {
            //Gets response in the form of json
            var json = new WebClient().DownloadData(url);
            var jsonString = Encoding.UTF8.GetString(json);            

            Articles = new List<Article>();

            //Decodes response from API into managable object
            JObject jObject = JObject.Parse(jsonString);
            JToken jArticles = jObject["articles"];
            JToken jSource;

            int i = 1;

            foreach (var article in jArticles)
            {
                Article newArticle = new Article();

                jSource = article["source"];

                //Building our Article Model
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