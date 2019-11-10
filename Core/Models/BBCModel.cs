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
            ArticleXPaths = new List<string>
            {
                "//body/div/div/div/div/div/div/div/div/div/div/p",
                "//body/div/div/div/div/div/div/div/div/div/p"
            };
            SearchStringStart = "href=\"";
            SearchStringEnd = "\" rev=";
            SearchStringOffset = 7;
            UrlModify = "https://bbc.com/";
        }

        //public List<string> headlineXpaths = new List<string>();
        //public string WebsiteUrl = "https://www.bbc.com";
        //public string SearchStringStart = "href=\""; //12            
        //public string SearchStringEnd = "\" rev="; //42
        //public int SearchStringOffset = 7;



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
