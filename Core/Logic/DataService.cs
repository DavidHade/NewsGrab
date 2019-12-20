using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EntityFramework.SQL;

namespace Core
{
    public class DataService
    {
        IRepository<NewsEntry> context;
        Logger _logger;

  

        public DataService(IRepository<NewsEntry> newsEntryContext, Logger logger)
        {
            context = newsEntryContext;
            _logger = logger;
        }

        public void Execute(NewsEntry NewsEntryModel)
        {
            var DeObj = new DAL.EntityFramework.SQL.NewsEntry();

            //var dbObj = (from entry in dc.NewsEntries where entry.Headline.StartsWith(DEM.Headline.Remove(10, DEM.Headline.Length - 10)) select entry).FirstOrDefault();
            var DBitem = context.FindHeadline(NewsEntryModel.Headline);

            if (DBitem == null)
            {
                DeObj.Headline = NewsEntryModel.Headline;
                DeObj.HeadlineUrl = NewsEntryModel.HeadlineUrl;
                DeObj.NewsSource = NewsEntryModel.NewsSource;
                DeObj.TimeAdded = DateTime.UtcNow;
                DeObj.Article = NewsEntryModel.Article;
                DeObj.Imagepath = NewsEntryModel.Imagepath;
                DeObj.Category = NewsEntryModel.Category;
                
                context.Insert(DeObj);
                context.Commit();

                _logger.Log($"Added to database", ConsoleColor.Red);
            }


        }
    }
}

