﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Models
{

    public class TheGuardianModel : AbstractWebsiteModel
    {
        public TheGuardianModel()
        {
            WebsiteUrl = "https://www.theguardian.com/international";
            NewsSource = "theguardian";
            HeadlineXpaths = new List<string>
            {
                "//body/div[4]/div/section[1]/div/div/div/ul/li/div/div/div/div/h3",
                "//body/div[4]/div/section[1]/div/div/div/ul/li/ul/li/div/div/div/div/h3"
            };
            TitleXpath = "";
            ArticleXPaths = new List<string>
            {
                "//body/div/article/div/div/div/div/p",
                "//body/figure/figure/div/div/div/p",
                "//body/div[1]/section[5]/div/div/main/main/div[1]/div/p"
            };            
            
            UrlModify = "";
            

            #region DeprecatedFields
            //SearchStringStart = "http";
            //SearchStringEnd = "\" class";
            //SearchStringOffset = 0;
            //ImageSsStart = "http"; //cannot retrieve images - this is a placeholder
            //ImageSsEnd = "placeholder";
            #endregion
        }

        //public string WebsiteUrl { get; set; }
        //public string NewsSource { get; set; }
        //public List<string> HeadlineXpaths { get; set; }
        //public string TitleXpath { get; set; }
        //public string HeadlineURLXPath { get; set; }
        //public List<string> ArticleXPaths { get; set; }
        //public string Headline { get; set; }
        //public string HeadlineUrl { get; set; }
        //public string ArticleURL { get; set; }
        //public string SearchStringStart { get; set; }
        //public string SearchStringEnd { get; set; }
        //public int SearchStringOffset { get; set; }
        //public string UrlModify { get; set; }
        //public string ImageXpath { get; set; }
        //public string ImageSsStart { get; set; }
        //public string ImageSsEnd { get; set; }
    }
}
