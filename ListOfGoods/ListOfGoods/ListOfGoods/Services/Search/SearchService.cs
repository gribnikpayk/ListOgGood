using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using ListOfGoods.Infrastructure.GoogleSearch;
using Xamarin.Forms;

namespace ListOfGoods.Services.Search
{
    public class SearchService : ISearchService
    {
        public async Task<List<string>> SearchImagesAsync(string query)
        {
            query = query.Replace(' ', '+');
            string requestUri = $"http://images.google.com/images?q={query}";

            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(requestUri);
            var cellSelector = "img";
            var cells = document.QuerySelectorAll(cellSelector);
            List<string> imageSrc = cells.Select(m => m.GetAttribute("src"))
                .Where(src => !string.IsNullOrEmpty(src) && src.IndexOf("http", StringComparison.Ordinal) >= 0)
                .ToList();
            return imageSrc;
        }
    }
}
