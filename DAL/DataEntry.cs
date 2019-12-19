using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataEntry
    {
        NewsDBDataContext dc;
        


        public DataEntry(NewsDBDataContext datacontext)
        {
            dc = datacontext;
        }

        public void Execute(DataEntryModel DEM)
        {

            var DeObj = new NewsEntry();

            var dbObj = (from entry in dc.NewsEntries where entry.Headline.StartsWith(DEM.Headline.Remove(10,DEM.Headline.Length - 10)) select entry).FirstOrDefault();

            if (dbObj == null)
            {
                DeObj.Headline = DEM.Headline;
                DeObj.HeadlineUrl = DEM.HeadlineUrl;
                DeObj.NewsSource = DEM.NewsSource;
                DeObj.TimeAdded = DateTime.UtcNow;
                DeObj.Article = DEM.Article;
                DeObj.Imagepath = DEM.ImagePath;
                DeObj.Category = DEM.Category;

                dc.NewsEntries.InsertOnSubmit(DeObj);
                dc.SubmitChanges();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Added to Database");
                Console.ResetColor();
            }
            Console.WriteLine();
        }  

        //public List<TechnologyKeyword> GetTechnologyKeywords()
        //{
        //    NewsDBDataContext dc = new NewsDBDataContext();
        //    var techKeyword = (from i in dc.TechnologyKeywords select i).ToList();

        //    return techKeyword;
        //}
    }
}
