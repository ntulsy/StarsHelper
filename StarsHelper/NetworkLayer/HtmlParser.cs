using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StarsHelper.NetworkLayer
{
    public class HtmlParser
    {
        public IEnumerable GetTableRows(string table)
        {
            string str = String.Copy(table);

            while (!String.IsNullOrEmpty(str))
            {
                string stringInRow = GetStringInNextTag(str, "TR");
                if (String.IsNullOrEmpty(stringInRow))
                    break;
                else
                {
                    yield return stringInRow;
                    // cut off used string
                    int startIndex = str.IndexOf(stringInRow);
                    str = str.Substring(startIndex + stringInRow.Length + 5);
                }
            }
        }

        public IEnumerable GetTableCells(string row)
        {
            string str = String.Copy(row);

            // if this is a header line, ignore it
            if (GetStringInNextTag(str, "TH") != null)
                yield break;
            // else, parse the information in each cell
            else
            {
                while (!String.IsNullOrEmpty(str))
                {
                    string stringInTD = GetStringInNextTag(str, "TD");
                    if (String.IsNullOrEmpty(stringInTD))
                        break;
                    else
                    {
                        // another layer of getting string
                        string stringInB = GetStringInNextTag(stringInTD, "B");
                        yield return stringInB;

                        // cut off used string
                        int startIndex = str.IndexOf(stringInTD);
                        str = str.Substring(startIndex + stringInTD.Length + 5);
                    }
                }
            }
        }

        public string GetStringInNextTag(string source, string tag)
        {
            string startTag = "<" + tag;
            string stopTag = "</" + tag + ">";

            // if there is no this tag anymore, return null
            if (source.IndexOf(startTag) == -1)
                return null;
            int startIndex = source.IndexOf(">");
            
            string tempSubString = source.Substring(startIndex + 1);
            int stopIndex = tempSubString.IndexOf(stopTag);
            return tempSubString.Substring(0, stopIndex);
        }
    }
}
