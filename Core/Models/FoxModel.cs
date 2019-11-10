using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class FoxModel : IWebsiteModel
    {
        //public List<string> headlineXpaths = new List<string>();
        //public string WebsiteUrl = "https://www.foxnews.com";
        //public string SearchStringStart = "https";          
        //public string SearchStringEnd = "\">";
        //public int SearchStringOffset = 0;

        public FoxModel()
        {
            WebsiteUrl = "https://www.foxnews.com";
            NewsSource = "foxnews";
            HeadlineXpaths = new List<string>
            {
                "//body/div/div/div/div/main/div/div/div/div/article/div/header/h2"
            };
            ArticleXPaths = new List<string>
            {
                "//body/div/div/div/div/div/main/article/div/div/div/p"
            };
            SearchStringStart = "https";
            SearchStringEnd = "\">";
            SearchStringOffset = 0;
            UrlModify = "";
        }

        public string WebsiteUrl { get; set; }
        public string NewsSource { get; set; }
        public List<string> HeadlineXpaths { get; set; }
        public string HeadlineURLXPath { get; set; }
        public List<string> ArticleXPaths { get; set; }
        public string Headline { get; set; }
        public string HeadlineUrl { get; set; }
        public string ArticleURL { get; set; }
        public string SearchStringStart { get; set; }
        public string SearchStringEnd { get; set; }
        public int SearchStringOffset { get; set; }
        public string UrlModify { get; set; }
    }
}
