using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class FoxModel : IWebsiteModel
    {
        public FoxModel()
        {
            WebsiteUrl = "https://www.foxnews.com";
            NewsSource = "foxnews";
            HeadlineXpaths = new List<string>
            {
                "//body/div/div/div/div/main/div/div/div/div/article/div/header/h2"
            };
            TitleXpath = "//body/div/div/div/div[2]/div/main/article/header/h1";
            ArticleXPaths = new List<string>
            {
                "//body/div/div/div/div/div/main/article/div/div/div/p"
            };
            SearchStringStart = "http";
            SearchStringEnd = "\">";
            SearchStringOffset = 0;
            UrlModify = "";

            ImageXpath = "//body/div/div/div/div/div/main/article/div/div/div/div/div/div[2]/div/a/img";
            ImageSsStart = "http";
            ImageSsEnd = "\" alt";
        }

        public string WebsiteUrl { get; set; }
        public string NewsSource { get; set; }
        public List<string> HeadlineXpaths { get; set; }
        public string TitleXpath { get; set; }
        public string HeadlineURLXPath { get; set; }
        public List<string> ArticleXPaths { get; set; }
        public string Headline { get; set; }
        public string HeadlineUrl { get; set; }
        public string ArticleURL { get; set; }
        public string SearchStringStart { get; set; }
        public string SearchStringEnd { get; set; }
        public int SearchStringOffset { get; set; }
        public string UrlModify { get; set; }

        public string ImageXpath { get; set; }
        public string ImageSsStart { get; set; }
        public string ImageSsEnd { get; set; }
    }
}
