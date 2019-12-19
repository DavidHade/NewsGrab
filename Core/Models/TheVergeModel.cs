using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class TheVergeModel : IWebsiteModel
    {
        public TheVergeModel()
        {
            WebsiteUrl = "https://www.theverge.com/tech";
            NewsSource = "theverge";
            HeadlineXpaths = new List<string>
            {
                "//body/div/main/div[4]/div/div[1]/div[1]/div/div/div/div/h2",
                "//body/div/main/div[5]/div/div[1]/div[1]/div/div/div/div/h2",
                //"//body/div/main/div[6]/div/div[1]/div[1]/div/div/div/div/h2",
            };
            TitleXpath = "//h1";
            ArticleXPaths = new List<string>
            {
                "//body/div/main/article/div[2]/div/div/p"
            };
            SearchStringStart = "http";
            SearchStringEnd = "\">";
            SearchStringOffset = 0;
            UrlModify = "";

            ImageXpath = "//body/div/main/article/div[2]/div/figure/span/span/picture/img";
            ImageSsStart = "http";
            ImageSsEnd = " 320w";
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
