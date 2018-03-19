using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsSite.Models
{
    // Model for Home Index view, contains Articles, pager and search info
    public class IndexViewModel
    {
        public IEnumerable<Article> Items { get; set; }
        public Pager Pager { get; set; }
        public string SearchBar { get; set; }
    }

    //Pager to allow browsing through pages of results
    public class Pager
    {
        public Pager(int totalItems, int? page, int pageSize = 15)
        {
            // calculate total, start and end pages
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            var search = "";
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            Search = search;
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public string Search { get; set; }
    }
}