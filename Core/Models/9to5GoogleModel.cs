using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class _9to5GoogleModel
    {
        public _9to5GoogleModel()
        {
            WebsiteUrl = "https://ww.9to5google.com";
            NewsSource = "9to5Google";
            HeadlineXpaths = new List<string>
            {
                "//body/div[4]/article/div/h1"
            };
            ArticleXPaths = new List<string>
            {
                "//body/div[4]/article/div[3]/div/p"
            };
            SearchStringStart = "href=\"";
            SearchStringEnd = "\" itemprop";
            SearchStringOffset = 0;
            UrlModify = "";

            ImageXpath = "//body/div/div[6]/div/div[5]/div/div[2]/div/div/div/div[2]/figure/span/img";
            ImageSsStart = "http";
            ImageSsEnd = "\" srcset";
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

        public string ImageXpath { get; set; }
        public string ImageSsStart { get; set; }
        public string ImageSsEnd { get; set; }
    }
}
