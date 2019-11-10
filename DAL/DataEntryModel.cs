using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataEntryModel
    {
        public DateTime TimeAdded { get; set; }
        public string Headline { get; set; }
        public string HeadlineUrl { get; set; }
        public string NewsSource { get; set; }
        public string Article { get; set; }

    }
}
