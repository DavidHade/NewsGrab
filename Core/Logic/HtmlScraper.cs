using Core.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.EntityFramework.SQL;
using Core.Models.ML_models;

namespace Core
{
    public class HtmlScraper
    {
        Substring _ss;
        readonly DataEntryModel _DEM;
        DAL.EntityFramework.SQL.NewsEntry EFnewsentryModel = new DAL.EntityFramework.SQL.NewsEntry(); //EF data entry model
        //DataEntry _DE; previously used for LINQ
        Logger _logger;
        DataService dataService;

        public HtmlScraper(Substring substring, DataEntryModel dataEntryModel,
            DAL.EntityFramework.SQL.NewsEntry efmodel, Logger logger, DataService ds)
        {
            _ss = substring;
            _DEM = dataEntryModel;
            EFnewsentryModel = efmodel;
            //_DE = dataEntry;
            _logger = logger;
            dataService = ds;
        }

        public void Parse(AbstractWebsiteModel website, string headlinexpath, bool isTest)
        {
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;

            var htmlDoc = web.Load(website.WebsiteUrl);
            HtmlNodeCollection headline = null;
            HtmlNodeCollection articleURL = null;

            try
            {
                headline = htmlDoc.DocumentNode.SelectNodes(headlinexpath);
                //never called
            }
            catch(Exception ex)
            {
                _logger.Log($"Unable to grab articles from {website.WebsiteUrl} in Parse method - {ex}", ConsoleColor.Yellow);
            }
            try
            {
                articleURL = htmlDoc.DocumentNode.SelectNodes(website.HeadlineURLXPath);
                // TODO fix NY times headline url xpath
            }catch (Exception ex)
            {
                _logger.Log($"Unable to articles urls {website.WebsiteUrl} - {ex} in Parse method - {ex}", ConsoleColor.Yellow);
            }




            if (headline != null)
            {
                for (int i = 0; i < headline.Count; i++)
                {
                    
                    //_logger.Log($"[{website.NewsSource}]" +
                    //    $"{HtmlEntity.DeEntitize(headline[i].InnerText.Trim())}", ConsoleColor.White);

                    string url = website.UrlModify;
                    //url += _ss.Substringurl(articleURL[i].OuterHtml, website.SearchStringStart, 
                    //    website.SearchStringEnd, website.SearchStringOffset);
                    url += _ss.RegexParse(articleURL[i].OuterHtml);
                    
                    
                    //doc2 = article opened from doc
                    var htmlDoc2 = web.Load(url);
                    _logger.Log($"Loaded {url}", ConsoleColor.Yellow);

                    StringBuilder sb = new StringBuilder();

                    string imgUrl = null;
                    var imageNode = htmlDoc2.DocumentNode.SelectSingleNode(website.ImageXpath);
                    var meta_img = htmlDoc2.DocumentNode.SelectSingleNode("//meta[@property='og:image']")?.Attributes["content"]?.Value;

                    HtmlNode title = htmlDoc2.DocumentNode.SelectSingleNode(website.TitleXpath);


                    try
                    {
                        EFnewsentryModel.Headline = HtmlEntity.DeEntitize(title.InnerText.Trim());
                        //_DEM.Headline = HtmlEntity.DeEntitize(title.InnerText.Trim());

                    }
                    catch(Exception ex)
                    {
                        _logger.Log($"Unable to grab article - {ex.Message}" +
                            $"\n{url}, image: {imageNode?.HasAttributes}", ConsoleColor.Red);
                        //imagenode can be null therefore .hasattributes could throw an exception
                    }
                    
                    _logger.Log($"[{website.NewsSource}] " +
                        $"{HtmlEntity.DeEntitize(title?.InnerText.Trim())}");

                    if (imageNode != null)
                    {
                        //imgUrl = _ss.Substringurl(imageNode.OuterHtml, 
                        //    website.ImageSsStart, website.ImageSsEnd, 0);
                        imgUrl = _ss.RegexParse(imageNode.OuterHtml);
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
                    
                    
                    //_DEM.HeadlineUrl = url;
                    EFnewsentryModel.HeadlineUrl = url;
                    //_DEM.NewsSource = website.NewsSource;
                    EFnewsentryModel.NewsSource = website.NewsSource;

                    if (sb.Length < 1)
                    {
                        _logger.Log($"StringBuilder returned null article for {headlinexpath}", ConsoleColor.Red);
                    }

                    //_DEM.Article = HtmlEntity.DeEntitize(sb?.ToString()); //could be null
                    EFnewsentryModel.Article = HtmlEntity.DeEntitize(sb?.ToString());
                    //_DEM.ImagePath = imgUrl; //could be null
                    if (!string.IsNullOrEmpty(meta_img))
                    {
                        EFnewsentryModel.Imagepath = meta_img;
                    }
                    else
                    {
                        EFnewsentryModel.Imagepath = imgUrl;
                    }

                    //_DEM.Category = null;
                    ArticleModel mlModel = new ArticleModel();
                    mlModel.Article = EFnewsentryModel.Article;
                    mlModel.Headline = EFnewsentryModel.Headline;
                    EFnewsentryModel.Category = Program.Predict(mlModel);
                    _logger.Log($"Predicted category - {EFnewsentryModel.Category}", ConsoleColor.DarkYellow);
                    if (!isTest && title != null)
                    {
                        //_DE.Execute(_DEM);
                        dataService.Execute(EFnewsentryModel);
                    }
                    _logger.Log($"_________________________________________________");
                    //Nullifying model at the end of the loop
                    //to prevent next iteration from retaining values
                    EFnewsentryModel.Article = null;
                    EFnewsentryModel.Category = null;
                    EFnewsentryModel.Headline = null;
                    EFnewsentryModel.HeadlineUrl = null;
                    EFnewsentryModel.Imagepath = null;
                    EFnewsentryModel.NewsSource = null;
                   
                }
            }
        }
    }
}
