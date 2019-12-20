using Core;
using Core.Contracts;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsGrab.Services
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
            var DeObj = new Core.Models.NewsEntry();

            //var dbObj = (from entry in dc.NewsEntries where entry.Headline.StartsWith(DEM.Headline.Remove(10, DEM.Headline.Length - 10)) select entry).FirstOrDefault();
            var DBitem = context.Find(NewsEntryModel.Headline);

            if (DBitem == null)
            {
                DBitem.Headline = NewsEntryModel.Headline;
                DBitem.HeadlineUrl = NewsEntryModel.HeadlineUrl;
                DBitem.NewsSource = NewsEntryModel.NewsSource;
                DBitem.TimeAdded = DateTime.UtcNow;
                DBitem.Article = NewsEntryModel.Article;
                DBitem.Imagepath = NewsEntryModel.Imagepath;
                DBitem.Category = NewsEntryModel.Category;

                context.Insert(DeObj);
                context.Commit();

                _logger.Log($"Added to database", ConsoleColor.Red);
            }


        }
    }
}
