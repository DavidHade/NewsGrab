using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class NyTimesModel : AbstractWebsiteModel
    {
        public NyTimesModel()
        {
            WebsiteUrl = "https://www.nytimes.com";
            NewsSource = "nytimes";
            HeadlineXpaths = new List<string>
            {
                "//body/div/div/main/div/div/div/div/div/section/div/div/div/div/div/article/div/div",
                "//body/div/div/main/div/div/div/div/div/section/div/div/div/div/div/div/div/div/article/div/div"
            };
            TitleXpath = "//h1/span";
            
            ArticleXPaths = new List<string>
            {
                "//body/div/div/div/div/main/div/article/section/div/div/p"
            };
            
            UrlModify = "https://www.nytimes.com";

            ImageXpath = "//body//img";
            

            #region DeprecatedFields
            //SearchStringStart = "href=\"/";
            //SearchStringEnd = "\"><di";
            //SearchStringOffset = 7;
            //ImageSsStart = "http";
            //ImageSsEnd = "\" srcset";
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
