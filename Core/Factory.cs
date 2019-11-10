using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using DAL;

namespace Core
{
    public class Factory
    {
        public static HtmlScraper CreateHtmlScraper()
        {
            return new HtmlScraper(CreateSubstring(), CreateDataEntryModel(), CreateDataEntry(), CreateLogger());
        }

        public static IWebsiteModel CreateTheGuardian()
        {
            return new TheGuardianModel();
        }

        public static IWebsiteModel CreateFoxNews()
        {
            return new FoxModel();
        }

        public static IWebsiteModel CreateNyTimesModel()
        {
            return new NyTimesModel();
        }

        public static IWebsiteModel CreateBbcModel()
        {
            return new BBCModel();
        }

        public static DataEntryModel CreateDataEntryModel()
        {
            return new DataEntryModel();
        }

        public static DataEntry CreateDataEntry()
        {
            return new DataEntry();
        }

        public static Substring CreateSubstring()
        {
            return new Substring();
        }

        public static Logger CreateLogger()
        {
            return new Logger();
        }

        public static NewsDBDataContext CreateDBContext()
        {
            return new NewsDBDataContext();
        }
    }
}
