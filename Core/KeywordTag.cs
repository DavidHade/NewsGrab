using Core.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class KeywordTag
    {
        public string Tag(DataEntryModel model, List<TechnologyKeyword> tkw, List<PoliticalKeyword> pkw)
        {
            int tkwCount = 0;
            int pkwCount = 0;

            foreach (var i in tkw)
            {
                if (model.Article.Contains(i.keyword))
                {
                    tkwCount++;
                }
            }

            foreach (var x in pkw)
            {
                if (model.Article.Contains(x.keyword))
                {
                    pkwCount++;
                }
            }

 

            return "dsadf";
        }
    }
}
