using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarsHelper.Structures;
using System.Text.RegularExpressions;

namespace StarsHelper.NetworkLayer
{
    internal class CourseInformationParser
    {
        public Course ParseCourseInformationFromHtmlString(string HtmlString)
        {
            Course courseToReturn = new Course();
            Index currentIndex = null;
            IndexRow currentIndexRow;
            string FinalTable;
            try
            {
                // process coursename
                string courseNameStartTag = "<TD WIDTH=\"100\"><B><FONT COLOR=#0000FF>";
                int courseNameStart = HtmlString.IndexOf(courseNameStartTag) + courseNameStartTag.Length;
                string courseNameStopTag = "</FONT>";
                string tempString = HtmlString.Substring(courseNameStart);
                int courseNameStop = tempString.IndexOf(courseNameStopTag);
                courseToReturn.CourseCode = tempString.Substring(0, courseNameStop);

                // process course title
                string courseTitleStartTag = "<TD WIDTH=\"500\"><B><FONT COLOR=#0000FF>";
                int courseTitleStart = HtmlString.IndexOf(courseTitleStartTag) + courseTitleStartTag.Length;
                string courseTitleStopTag = "</FONT>";
                tempString = HtmlString.Substring(courseTitleStart);
                int courseTitleStop = tempString.IndexOf(courseTitleStopTag);
                courseToReturn.CourseName = tempString.Substring(0, courseTitleStop);

                // process table information start
                // firstly extract tables
                string tableStartTag = "<TABLE  border>";
                int tableStart = HtmlString.IndexOf(tableStartTag) + tableStartTag.Length;
                string tableStopTag = "</TABLE>";
                tempString = HtmlString.Substring(tableStart);
                int tableStop = tempString.LastIndexOf(tableStopTag);
                FinalTable = tempString.Substring(0, tableStop);
            }
            catch
            {
                return null;
            }
            // deal with line break
            FinalTable = Regex.Replace(FinalTable, @"[\n\r]", "");

            HtmlParser hp1 = new HtmlParser();
            foreach (string row in hp1.GetTableRows(FinalTable))
            {
                HtmlParser hp2 = new HtmlParser();
                currentIndexRow = new IndexRow();
                int cellCount = 0;
                foreach (string cell in hp2.GetTableCells(row))
                {
                    // if this is a new index, add a new index
                    if (cellCount == 0 && !String.IsNullOrEmpty(cell))
                    {
                        currentIndex = new Index();
                        currentIndex.IndexNumber = String.Copy(cell);
                        courseToReturn.addIndex(currentIndex);
                    }
                    else
                    {
                        switch (cellCount)
                        {
                            case 1: // type information
                                currentIndexRow.Type = cell;
                                break;
                            case 2: //group information
                                currentIndex.Group = cell;
                                break;
                            case 3: // day information
                                currentIndexRow.Day = (WeekDays)Enum.Parse(typeof(WeekDays), cell);
                                break;
                            case 4: // time information
                                string[] temp = cell.Split('-');
                                currentIndexRow.StartTime = temp[0];
                                currentIndexRow.EndTime = temp[1];
                                break;
                            case 5: // venue information
                                currentIndexRow.Venue = cell;
                                break;
                            case 6: // week information
                                parseWeekInfo(currentIndexRow.IsScheduledInWeek, cell);
                                break;
                        }
                    }
                    cellCount++;
                }
                // finished one row, add the row into index
                if (currentIndex != null)
                    currentIndex.addIndexRow(currentIndexRow);
            }
            return courseToReturn;
        }

        public int ParseCourseVacancyFromHtmlString(string HtmlString)
        {
            throw new NotImplementedException();
        }

        public string ParseCourseExamTimeFromHtmlString(string HtmlString)
        {
            try
            {
                string startTag = "<TR ALIGN=\"yes\" VALIGN=\"yes\" bgcolor=#99CCFF>";
                int start = HtmlString.IndexOf(startTag) + startTag.Length;
                string stopTag = "<td align=left width=40%";
                string tempString = HtmlString.Substring(start);
                int stop = tempString.IndexOf(stopTag);
                string examTimeString = tempString.Substring(0, stop);

                // get date
                HtmlParser hp = new HtmlParser();
                string dateOfExam = hp.GetStringInNextTag(examTimeString, "td");
                int startIndex = examTimeString.IndexOf(dateOfExam);
                examTimeString = examTimeString.Substring(startIndex + dateOfExam.Length + 5);

                // bypass day
                string timeOfExam = hp.GetStringInNextTag(examTimeString, "td");
                startIndex = examTimeString.IndexOf(timeOfExam);
                examTimeString = examTimeString.Substring(startIndex + timeOfExam.Length + 5);

                // get date
                timeOfExam = hp.GetStringInNextTag(examTimeString, "td");

                return dateOfExam.Trim() + " " + timeOfExam.Trim();
            }
            catch
            {
                return "no exam";
            }
        }

        private void parseWeekInfo(bool[] week, string source)
        {
            if (String.IsNullOrEmpty(source))
            {
                for (int i = 0; i < week.Count(); i++)
                    week[i] = true;

            }
            else
            {
                // deal with each entry
                foreach (string entry in source.Split(','))
                {
                    // take away Wk 
                    string duplicatedEntry = entry;
                    if (entry.StartsWith("Wk"))
                        duplicatedEntry = entry.Remove(0, 2);

                    // process period
                    if (duplicatedEntry.Contains('-'))
                    {
                        string[] temp = duplicatedEntry.Split('-');
                        for (int i = Convert.ToInt32(temp[0]) - 1; i < Convert.ToInt32(temp[1]); i++)
                            week[i] = true;
                    }
                    else
                    {
                        try
                        {
                            week[Convert.ToInt32(duplicatedEntry) - 1] = true;
                        }
                        catch
                        {
                            // this is blank to deal with AB1000 case
                        }
                        
                    }
                }
            }
        }


    }
}
