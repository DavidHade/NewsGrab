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
                Logger _logger = Factory.CreateLogger();

                //GetData(htmlSraper, new TheGuardianModel());

                GetData(htmlSraper, new NyTimesModel(), "/a");
                GetData(htmlSraper, new FoxModel(), "/a");
                GetData(htmlSraper, new BBCModel(), "/a");
                GetData(htmlSraper, new TheVergeModel(), "/a");
                GetData(htmlSraper, new CnetModel(),"");


                void GetData(HtmlScraper htmlscraper, IWebsiteModel model, string headlineUrlXpath, bool isTest = false) {
                    foreach (var x in model.HeadlineXpaths)
                    {
                        try
                        {
                            model.HeadlineURLXPath = x + headlineUrlXpath;
                            htmlscraper.Parse(model, x, isTest);
                        }catch (Exception ex)
                        {
                            _logger.Log(ex.ToString(), ConsoleColor.Red);
                        }
                        
                    }
                }
                _logger.Log($"============= Finished at {DateTime.UtcNow}=============", ConsoleColor.Red);
                Thread.Sleep(300000);
            }
        }
    }
}
