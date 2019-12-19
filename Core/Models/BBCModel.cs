using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BBCModel : IWebsiteModel
    {
        public BBCModel()
        {
            WebsiteUrl = "https://www.bbc.com/";
            NewsSource = "bbc";
            HeadlineXpaths = new List<string>
            {
                "//body/div[6]/div[1]/section[4]/div[1]/div[1]/div[2]/div[1]/section[1]/div/ul/li/div/div/h3"
            };
            TitleXpath = "//h1";
            ArticleXPaths = new List<string>
            {
                "//body/div/div/div/div/div/div/div/div/div/div/p",
                "//body/div/div/div/div/div/div/div/div/div/p"
            };
            SearchStringStart = "href=\"";
            SearchStringEnd = "\" rev=";
            SearchStringOffset = 7;
            UrlModify = "https://bbc.com/";

            ImageXpath = "//body/div/div[6]/div/div[5]/div/div[2]/div/div/div/div[2]/figure/span/img";
            ImageSsStart = "http";
            ImageSsEnd = "\" width";
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
