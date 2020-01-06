using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core
{
    public class Substring
    {
        Logger _logger;

        public Substring(Logger logger)
        {
            _logger = logger;
        }

        public string Substringurl(string ss, string searchstringstart, string searchstringend, int searchstringoffset)
        {
            if (ss == null)
            {
                _logger.Log("Received string was null (Subsctring.cs)");
                return null;
            }

            String s = ss;
            int startIndex = s.IndexOf(searchstringstart) + searchstringoffset;
            int endIndex = s.IndexOf(searchstringend);
            if (startIndex > endIndex)
            {
                _logger.Log("Start index was bigger than end index");
                return null;
            }
            if (ss.Contains(searchstringstart) && ss.Contains(searchstringend))
            {
                String substring = s.Substring(startIndex, endIndex - searchstringend.Length + searchstringend.Length - startIndex);
                return substring;
            }
            else
            {
                _logger.Log("Substring returned null", ConsoleColor.Yellow);
                return null;
            }
        }

        public string RegexParse(string input)
        {
            string pattern = @"(https*:)*(\/+)([\w\.\/\-\?\=\$\(\):_]*)";

            var match = Regex.Match(input, pattern);
            _logger.Log($"Regex returned {match.Groups[0].Value}", ConsoleColor.Green);

            return match.Groups[0].Value;
        }
    }
}
