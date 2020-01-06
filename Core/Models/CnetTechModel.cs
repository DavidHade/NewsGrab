using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CnetTechModel : AbstractWebsiteModel
    {
        public CnetTechModel() 
        {
            WebsiteUrl = "https://www.cnet.com/topics/tech-industry/";
            NewsSource = "CnetTech";
            HeadlineXpaths = new List<string>
            {
                "//*[@id='topicListing']/div/div"
            };
            TitleXpath = "//body/div[4]/div/div/div/div/div/div/div/h1";
            ArticleXPaths = new List<string>
            {
                "//body/div[4]/div[2]/div/div/div/div/div/div/article/div/p"
            };

            UrlModify = "https://www.cnet.com";
            ImageXpath = "//*[@id='article-body']/div[2]/figure/span/span/img";

        }
    }
}
