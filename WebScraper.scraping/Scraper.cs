using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace WebScraper.scraping
{
    public class Scraper
    {
        public static List<Scoop> ScrapeLakewoodScoop()
        {
            var results = new List<Scoop>();
            var html = GetLakewoodScoopHtml();
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var searchResultElements = document.QuerySelectorAll(".post");
            foreach (var result in searchResultElements)
            {
                var scoop = new Scoop();

                var titleSpan = result.QuerySelector("h2");
                scoop.Title = titleSpan.TextContent;

                var imageHref = result.QuerySelector("a.fancybox");
                if (imageHref != null)
                {
                    scoop.ImageURL = imageHref.Attributes["href"].Value;
                }

                var textBuiltUp = "";
                var textSpan = result.QuerySelectorAll("p");
                foreach(var text in textSpan)
                {
                    textBuiltUp += text.TextContent.Replace("Read more ›", String.Empty);
                }
           
                scoop.Text = textBuiltUp;

                var comments = result.QuerySelector("div.backtotop");
                scoop.Comments = comments.TextContent;
               
                var anchorTag = result.QuerySelector("a.more-link");
                if (anchorTag != null)
                {
                    scoop.Link = anchorTag.Attributes["href"].Value;
                }
                results.Add(scoop);
            }
            return results;
        }
        private static string GetLakewoodScoopHtml()
        {
            string url = "https://www.thelakewoodscoop.com/";
            var client = new HttpClient();
            return client.GetStringAsync(url).Result;
        }
    }
}
