using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Core.Models;
using DAL.EntityFramework.SQL;

namespace Core
{
    public class Factory
    {

        public static HtmlScraper CreateHtmlScraper()
        {
            return new HtmlScraper(CreateSubstring(), CreateDataEntryModel(), new DAL.EntityFramework.SQL.NewsEntry(), CreateLogger(), CreateDataService());
        }

        public static DataService CreateDataService()
        {
            return new DataService(CreateDataContext(), CreateLogger());
        }

        public static IRepository<DAL.EntityFramework.SQL.NewsEntry> CreateDataContext()
        {
            return new SQLRepository<DAL.EntityFramework.SQL.NewsEntry>(new DAL.EntityFramework.SQL.DataContext());
        }

        //public static IWebsiteModel CreateTheGuardian()
        //{
        //    return new TheGuardianModel();
        //}

        //public static IWebsiteModel CreateFoxNews()
        //{
        //    return new FoxModel();
        //}

        //public static IWebsiteModel CreateNyTimesModel()
        //{
        //    return new NyTimesModel();
        //}

        //public static IWebsiteModel CreateBbcModel()
        //{
        //    return new BBCModel();
        //}

        //public static IWebsiteModel CreateTheVergeModel()
        //{
        //    return new TheVergeModel();
        //}

        //public static IWebsiteModel CreateCnetModel()
        //{
        //    return new CnetModel();
        //}

        //public static IWebsiteModel Create9to5Google()
        //{
        //    return new _9to5GoogleModel();
        //}

        public static DataEntryModel CreateDataEntryModel()
        {
            return new DataEntryModel();
        }

        //public static DataEntry CreateDataEntry()
        //{
        //    return new DataEntry(new NewsDBDataContext());
        //}

        public static Substring CreateSubstring()
        {
            return new Substring(new Logger());
        }

        public static Logger CreateLogger()
        {
            return new Logger();
        }

        //public static NewsDBDataContext CreateDBContext()
        //{
        //    return new NewsDBDataContext();
        //}
    }
}
