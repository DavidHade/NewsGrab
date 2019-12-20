using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            String s = ss;
            int startIndex = s.IndexOf(searchstringstart) + searchstringoffset;
            int endIndex = s.IndexOf(searchstringend);
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
    }
}
