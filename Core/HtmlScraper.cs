using Core.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Core
{
    public class HtmlScraper
    {
        Substring _ss;
        DataEntryModel _DEM;
        DataEntry _DE;
        Logger _logger;

        public HtmlScraper(Substring substring, DataEntryModel dataEntryModel, DataEntry dataEntry, Logger logger)
        {
            _ss = substring;
            _DEM = dataEntryModel;
            _DE = dataEntry;
            _logger = logger;
        }

        public void Parse(IWebsiteModel website, string headlinexpath)
        {
            
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;

            var htmlDoc = web.Load(website.WebsiteUrl);
            
            var headline = htmlDoc.DocumentNode.SelectNodes(headlinexpath);
            var articelURL = htmlDoc.DocumentNode.SelectNodes(website.HeadlineURLXPath);
            
            if (headline != null)
            {
                for (int i = 0; i < headline.Count; i++)
                {
                    _logger.Log($"{HtmlEntity.DeEntitize(headline[i].InnerText.Trim())} - {website.NewsSource}");

                    string url = website.UrlModify;
                    url += _ss.Substringurl(articelURL[i].OuterHtml, website.SearchStringStart, website.SearchStringEnd, website.SearchStringOffset);

                    var htmlDoc2 = web.Load(url);
                    StringBuilder sb = new StringBuilder();

                    for (int c = 0; c < website.ArticleXPaths.Count; c++)
                    {
                        var article = htmlDoc2.DocumentNode.SelectNodes(website.ArticleXPaths[c]);

                        if (article != null)
                        {
                            for (int b = 0; b < article.Count; b++)
                            {
                                sb.Append(article[b].InnerText);
                                sb.AppendLine();
                            }
                        }
                    }

                    //_logger.Log(url);
                    //_logger.Log(HtmlEntity.DeEntitize(sb.ToString()));
                    if (sb.Length > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        _logger.Log("+ article");
                        Console.ResetColor();
                    }
                    

                    _DEM.Headline = HtmlEntity.DeEntitize(headline[i].InnerText.Trim().ToString());
                    _DEM.HeadlineUrl = url;
                    _DEM.NewsSource = website.NewsSource.Trim().ToString();
                    _DEM.Article = HtmlEntity.DeEntitize(sb.ToString());
                    
                    _DE.Execute(_DEM);
                }
            }
        }
    }
}
