using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Substring
    {
        public string Substringurl(string ss, string searchstringstart, string searchstringend, int searchstringoffset)
        {

            String s = ss;
            int startIndex = s.IndexOf(searchstringstart) + searchstringoffset;
            int endIndex = s.IndexOf(searchstringend);
            String substring = s.Substring(startIndex, endIndex - searchstringend.Length + searchstringend.Length - startIndex);

            return substring;
        }
    }
}
