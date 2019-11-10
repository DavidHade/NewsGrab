using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public interface IWebsiteModel
    {
        string WebsiteUrl { get; set; }
        string NewsSource { get; set; }
        List<string> HeadlineXpaths { get; set; }
        string HeadlineURLXPath { get; set; }
        List<string> ArticleXPaths { get; set; }
        string Headline { get; set; }
        string HeadlineUrl { get; set; }
        string ArticleURL { get; set; }
        string SearchStringStart { get; set; }
        string SearchStringEnd { get; set; }
        int SearchStringOffset { get; set; }
        string UrlModify { get; set; }
    }
}
