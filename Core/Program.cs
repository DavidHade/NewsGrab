using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;
using Microsoft.ML;
using Core.Models.ML_models;
using System.Diagnostics;
using System.IO;

namespace Core
{
    class Program
    {
        private static string modelPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\model.zip";
        private static MLContext _mlContext = new MLContext(seed: 0);
        private static PredictionEngine<ArticleModel, ArticleModelPrediction> _predEngine;
        private static ITransformer loadedModel = _mlContext.Model.Load(modelPath, out var modelInputSchema);
        
        static void Main()
        {

            while (1 == 1)
            {
                   
                HtmlScraper htmlSraper = Factory.CreateHtmlScraper();
                Logger _logger = Factory.CreateLogger();

                //GetData(htmlSraper, new TheGuardianModel()); //Cannot get images :(
                GetData(htmlSraper, new NyTimesModel(), "/a");
                GetData(htmlSraper, new FoxModel(), "/a");
                GetData(htmlSraper, new BBCModel(), "/a");
                GetData(htmlSraper, new TheVergeModel(), "/a");
                GetData(htmlSraper, new CnetModel(), "");
                GetData(htmlSraper, new CnetTechModel(), "");

                void GetData(HtmlScraper htmlscraper, AbstractWebsiteModel model, 
                    string headlineUrlXpath, bool isTest = false)
                {
                    foreach (var x in model.HeadlineXpaths)
                    {
                        try
                        {
                            model.HeadlineURLXPath = x + headlineUrlXpath;
                            htmlscraper.Parse(model, x, isTest);
                        }
                        catch (Exception ex)
                        {
                            _logger.Log(ex.ToString(), ConsoleColor.Red);
                        }
                    }
                }
                _logger.Log($"============= Finished at {DateTime.UtcNow}=============", ConsoleColor.Red);
                Thread.Sleep(300000);
            }
        }

        public static string Predict(ArticleModel article)
        {
            // Create prediction engine from loaded model
            _predEngine = _mlContext.Model.CreatePredictionEngine<ArticleModel, ArticleModelPrediction>(loadedModel);

            var prediction = _predEngine.Predict(article);

            return prediction.Category;
        }
    }
}
