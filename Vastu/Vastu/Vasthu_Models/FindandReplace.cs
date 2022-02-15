using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Vasthu_Models
{
    public static class FindandReplace
    {
        public static string SafeReplaceStartDIV(this string input, string find, string replace, bool matchWholeWord)
        {
            string result = string.Empty;
            string textToFind = matchWholeWord ? string.Format(@"{0}", find) : find;
            result = Regex.Replace(input, textToFind, replace);

            return result;
        }

        public static string SafeReplaceRemoveNonBreakSpace(this string input)
        {
            string result = string.Empty;
            
            string fin = "&nbsp; ";
            string findstring = string.Empty;
            result = input.Replace("&nbsp;", "<br>");
            for (int i = 0; i < 50; i++)
            {
                //findstring = "<div>" + fin + "</div>";
                if (i == 0)
                {
                    findstring = "<div>&nbsp;</div>";
                    string textToFind = true ? string.Format(@"{0}", findstring) : findstring;
                    result = Regex.Replace(input, textToFind, "<br>");
                    fin = fin + "&nbsp;";
                }
                else
                {
                    findstring = "<div>" + fin + "</div>";
                    string textToFind = true ? string.Format(@"{0}", findstring) : findstring;
                    result = Regex.Replace(input, textToFind, "<br>");
                    fin = fin + " &nbsp;";
                }


            }
            return result;
        }




        public static string SafeReplaceCloseDIV(this string input, string find, string replace, bool matchWholeWord)
        {
            List<MasterContent> obj = new List<MasterContent>();
            string textToFind = matchWholeWord ? string.Format(@"{0}", find) : find;

            string result = Regex.Replace(input, textToFind, replace);
            return result;
        }
        
    }
}
