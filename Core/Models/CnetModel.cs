using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CnetModel : AbstractWebsiteModel
    {
        public CnetModel()
        {
            //WebsiteUrl = "https://www.cnet.com/topics/tech-industry/";
            WebsiteUrl = "https://www.cnet.com";
            NewsSource = "Cnet";
            HeadlineXpaths = new List<string>
            {
                "//body/div/div/div/section/div/div/div/div/div/h3/a"
                
                

            };
            TitleXpath = "//body//h1";
            ArticleXPaths = new List<string>
            {
                "//body/div/div/div/div/div/div/div/div/article/div/p"

            };
            
            UrlModify = "https://www.cnet.com";

            ImageXpath = "//*[@id=\"article-body\"]//span/img";
            

            #region DeprecatedFields
            //SearchStringStart = "href=\"";
            //SearchStringEnd = "/\">";
            //SearchStringOffset = 6;
            //ImageSsStart = "http";
            //ImageSsEnd = "\" class";
            #endregion
        }

        //public string WebsiteUrl { get; set; }
        //public string NewsSource { get; set; }
        //public List<string> HeadlineXpaths { get; set; }
        //public string TitleXpath { get; set; }
        //public string HeadlineURLXPath { get; set; }
        //public List<string> ArticleXPaths { get; set; }
        //public string Headline { get; set; }
        //public string HeadlineUrl { get; set; }
        //public string ArticleURL { get; set; }
        //public string SearchStringStart { get; set; }
        //public string SearchStringEnd { get; set; }
        //public int SearchStringOffset { get; set; }
        //public string UrlModify { get; set; }

        //public string ImageXpath { get; set; }
        //public string ImageSsStart { get; set; }
        //public string ImageSsEnd { get; set; }
    }
}
