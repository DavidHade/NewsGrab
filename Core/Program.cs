using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
           
            while (1 == 1)
            {
                
                HtmlScraper htmlSraper = Factory.CreateHtmlScraper();
                IWebsiteModel theguardian = Factory.CreateTheGuardian();
                IWebsiteModel foxnews = Factory.CreateFoxNews();
                IWebsiteModel nytimes = Factory.CreateNyTimesModel();
                IWebsiteModel bbcnews = Factory.CreateBbcModel();

                GetData(htmlSraper, theguardian);
                GetData(htmlSraper, foxnews);
                GetData(htmlSraper, nytimes);
                GetData(htmlSraper, bbcnews);

                void GetData(HtmlScraper htmlscraper, IWebsiteModel model) {
                    foreach (var x in model.HeadlineXpaths)
                    {
                        model.HeadlineURLXPath = x + "/a";
                        htmlscraper.Parse(model, x);
                    }
                    Thread.Sleep(500);
                }
                Console.WriteLine($"================= Finished at {DateTime.UtcNow}==================");
                Thread.Sleep(300000);
            }
        }
    }
}
