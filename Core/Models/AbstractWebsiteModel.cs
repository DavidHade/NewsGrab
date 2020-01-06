using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public abstract class AbstractWebsiteModel
    {
        public virtual string WebsiteUrl { get; set; }
        public virtual string NewsSource { get; set; }
        public virtual List<string> HeadlineXpaths { get; set; }
        public virtual string TitleXpath { get; set; }
        // TODO - used Regex to get article url
        public virtual string HeadlineURLXPath { get; set; }
        public virtual List<string> ArticleXPaths { get; set; }
        public virtual string Headline { get; set; }
        public virtual string HeadlineUrl { get; set; }
        public virtual string ArticleURL { get; set; }
        public virtual string UrlModify { get; set; }
        public virtual string ImageXpath { get; set; }

        #region DeprecatedFields

        //public virtual string ImageSsStart { get; set; }
        //public virtual string ImageSsEnd { get; set; }
        //public virtual string SearchStringStart { get; set; }
        //public virtual string SearchStringEnd { get; set; }
        //public virtual int SearchStringOffset { get; set; }
        #endregion

    }
}
