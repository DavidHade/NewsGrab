using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core
{
    public class Keywords
    {
        public HashSet<string> GetKeywords(Logger _logger)
        {
            //List<string> test = new List<string>(( new string "Google", "OS");

            List<string> dbKeywords = new List<string>();

            HashSet<string> keywords =
            new HashSet<string>(dbKeywords, StringComparer.OrdinalIgnoreCase);

            

            NewsDBDataContext dc = new NewsDBDataContext();
            // Load article
            var articles = (from i in dc.NewsEntries select i.Article);

            //HashSet<string> hash = new HashSet<string>
            //    (from i in dc.NewsEntries select i.Article);

            string text = "";

            foreach (var a in articles)
            {
                text += a;
            }

            //string[] words = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] words = Regex.Split(text, "\\b", RegexOptions.IgnoreCase);
            //HashSet<string> hash3 = Regex.Split(text, "\\b", RegexOptions.IgnoreCase);

            //HashSet<string> hash = new HashSet<string>();


            MatchCollection matches = Regex.Matches(text, "[a-z]([’]*[a-z])+",
                                          RegexOptions.IgnoreCase);
            #region Regex match
            //foreach (Match match in matches)
            //{
            //    _logger.Log(match.ToString() + " ", ConsoleColor.Red);

            //    if (keywords.Contains(match.Value))
            //    {
            //        //ProcessKeyword(match.Value); // Do whatever you need to do here
            //    }
            //}
            #endregion

            #region Dictionary
            Dictionary<string, int> dictionary = words.GroupBy(word => word)
                                            .ToDictionary(
                                            kvp => kvp.Key, // the word itself is the key
                                            kvp => kvp.Count()); // number of occurences is the value

            var dictList = dictionary.ToList();
            dictList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            foreach (KeyValuePair<string, int> kvp in dictList)
            {
                _logger.Log($"{kvp.Value} {kvp.Key}", ConsoleColor.Red);
            }
            #endregion


            return keywords;
        }

        
    }
}
