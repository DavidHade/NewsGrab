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

        public HtmlScraper(Substring substring, DataEntryModel dataEntryModel, 
            DataEntry dataEntry, Logger logger)
        {
            _ss = substring;
            _DEM = dataEntryModel;
            _DE = dataEntry;
            _logger = logger;
        }

        public void Parse(IWebsiteModel website, string headlinexpath, bool isTest)
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
                    
                    //_logger.Log($"[{website.NewsSource}]" +
                    //    $"{HtmlEntity.DeEntitize(headline[i].InnerText.Trim())}", ConsoleColor.White);

                    string url = website.UrlModify;
                    url += _ss.Substringurl(articelURL[i].OuterHtml, website.SearchStringStart, 
                        website.SearchStringEnd, website.SearchStringOffset);
                    
                    //doc2 = article opened from doc
                    var htmlDoc2 = web.Load(url);

                    StringBuilder sb = new StringBuilder();

                    string imgUrl = null;
                    var imageNode = htmlDoc2.DocumentNode.SelectSingleNode(website.ImageXpath);
                    HtmlNode title = htmlDoc2.DocumentNode.SelectSingleNode(website.TitleXpath);

                    try
                    {
                        _logger.Log($"[{website.NewsSource}] " +
                        $"{HtmlEntity.DeEntitize(title.InnerText.Trim())}");
                        _DEM.Headline = HtmlEntity.DeEntitize(title.InnerText.Trim());
                    }
                    catch(Exception ex)
                    {
                        _logger.Log($"Unable to grab article - {ex.ToString()}" +
                            $"\n{url}, image: {imageNode?.HasAttributes}", ConsoleColor.Red);
                        //imagenode can be null therefore .hasattributes could throw an exception
                    }
                    
                    if (imageNode != null)
                    {
                        imgUrl = _ss.Substringurl(imageNode.OuterHtml, 
                            website.ImageSsStart, website.ImageSsEnd, 0);
                    }
                    
                    for (int c = 0; c < website.ArticleXPaths.Count; c++)
                    {
                        var article = htmlDoc2.DocumentNode.SelectNodes(website.ArticleXPaths[c]);

                        if (article != null)
                        {
                            for (int b = 0; b < article.Count; b++)
                            {
                                sb.Append("<p>");
                                sb.Append(article[b].InnerText);
                                sb.Append("</p>");
                                
                            }
                        }
                    }

                    if (sb.Length > 1)
                    {
                        _logger.Log("+ Article", ConsoleColor.Green);
                    }
                    if (imgUrl != null)
                    {
                        _logger.Log("+ Image", ConsoleColor.Blue);
                    }
                    
                    
                    _DEM.HeadlineUrl = url;
                    _DEM.NewsSource = website.NewsSource;

                    if (sb.Length < 1)
                    {
                        _logger.Log($"Returned null article for {headlinexpath}", ConsoleColor.Red);
                    }

                    _DEM.Article = HtmlEntity.DeEntitize(sb?.ToString()); //could be null
                    _DEM.ImagePath = imgUrl; //could be null
                   
                    _DEM.Category = null;
                    if (!isTest)
                    {
                        _DE.Execute(_DEM);
                    } 
                }
            }
            else
            {
                _logger.Log($"{website.WebsiteUrl} returned null", ConsoleColor.Red);
                return;
            }
        }
    }
}
