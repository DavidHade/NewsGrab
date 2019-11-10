using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class WebsiteModel //Deprecated
    {
        public string WebsiteUrl { get; set; }
        public string HeadelineXPath { get; set; }
        public string HeadlineURLXPath { get; set; }
        public string ArticleXPath { get; set; }
        public string Headline { get; set; }
        public string ArticleURL { get; set; }
        public string SearchStringStart { get; set; }
        public string SearchStringEnd { get; set; }
        public int SearchStringOffset { get; set; }
    }
}
