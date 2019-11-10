using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataEntry
    {
        public void Execute(DataEntryModel DEM)
        {
            NewsDBDataContext dc = new NewsDBDataContext();
            var DeObj = new NewsEntry();

            var dbObj = (from entry in dc.NewsEntries where entry.Headline == DEM.Headline select entry).FirstOrDefault();

            if (dbObj == null)
            {
                DeObj.Headline = DEM.Headline;
                DeObj.HeadlineUrl = DEM.HeadlineUrl;
                DeObj.NewsSource = DEM.NewsSource;
                DeObj.TimeAdded = DateTime.Now;
                DeObj.Article = DEM.Article;

                dc.NewsEntries.InsertOnSubmit(DeObj);
                dc.SubmitChanges();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Added to Database");
                Console.ResetColor();
            }
            Console.WriteLine();
        }  
    }
}
