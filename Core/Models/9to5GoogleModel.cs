using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class _9to5GoogleModel : AbstractWebsiteModel //Gzip formatting, unable to parse
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
            UrlModify = "";
            ImageXpath = "//body/div/div[6]/div/div[5]/div/div[2]/div/div/div/div[2]/figure/span/img";

            #region DeprecatedFields
            //ImageSsStart = "http";
            //ImageSsEnd = "\" srcset";
            //SearchStringStart = "href=\"";
            //SearchStringEnd = "\" itemprop";
            //SearchStringOffset = 0;
            #endregion

        }
    }
}
