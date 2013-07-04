using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarsHelper.Structures;
using StarsHelper.NetworkLayer;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace StarsHelper.CoursePlanningLogic
{
    public class CoursePlanningController
    {
        public static List<Course> CourseList = new List<Course>();
        public static int[] IndexRefList;
        public static List<int[]> IndexRefListCollection = new List<int[]>();
        public static int CollectionPointer = -1;
        public static bool IsFirstRun = true;
        private static int[,,] timetable = new int[13,6,48];
        

        #region Controller Functions

        public void AddCourse(string courseCode)
        {
            NetworkCommunicator nc = new NetworkCommunicator();

            // build course structure
            string courseInformation = nc.GetCourseInfo(courseCode);
            CourseInformationParser cip = new CourseInformationParser();
            Course newCourse = cip.ParseCourseInformationFromHtmlString(courseInformation);

            // add exam time information
            string examTimeInformation = nc.GetCourseExamTime(courseCode);
            string examTime = cip.ParseCourseExamTimeFromHtmlString(examTimeInformation);
            newCourse.ExamTime = examTime;

            // add indices vacancy information

            if (newCourse != null)
            {
                CourseList.Add(newCourse);
            }
        }

        public void AddCourse(string[] courseCodes)
        {
            // multithread network connection
            foreach (string str in courseCodes)
            {
                string newStr = Regex.Replace(str, @"[\n\r]", "");
                CoursePlanningController cpc = new CoursePlanningController();
                cpc.AddCourse(newStr);
            }
        }

        public void AddCourse(Course course)
        {
            if (course != null)
            {
                CoursePlanningController.CourseList.Add(course);
            }
        }

        public void ClearCourseInformation()
        {
            CourseList.Clear();
            IndexRefList = null;
        }

        public void RemoveCourse(string courseCode)
        {
            CourseList.RemoveAll(i => i.CourseCode == courseCode);
        }

        public void RemoveIndexFromCourse(string courseCode, string index)
        {
            Course course = CourseList.Find(c => c.CourseCode == courseCode);
            course.removeIndex(index);
            if (course.Indices.Count == 0)
            {
                RemoveCourse(course.CourseCode);
            }
        }

        public void addIndex(string courseCode, string index)
        {
            NetworkCommunicator nc = new NetworkCommunicator();
            string courseInformation = nc.GetCourseInfo(courseCode);
            CourseInformationParser cip = new CourseInformationParser();
            Course newCourse = cip.ParseCourseInformationFromHtmlString(courseInformation);
            newCourse.Indices.RemoveAll(i => i.IndexNumber != index);

            // if this index actually exists, add to the list
            if (newCourse.Indices.Count != 0)
            {
                // check whether this course is already in the list
                Course existingCourse = CourseList.Find(c => c.CourseCode == courseCode);
                if (existingCourse == null)
                    CourseList.Add(newCourse);
                else
                {
                    existingCourse.addIndex(newCourse.Indices.First());
                }
            }
        }

        #endregion

        #region Course Planning Functions

        private void InitializeIndexReference()
        {
            IndexRefList = new int[CourseList.Count];
            for (int i = 0; i < IndexRefList.Length; i++)
                IndexRefList[i] = 0;
        }

        private void InitializeTimeTable()
        {
            int i, j, k;
            for (i = 0; i < 13; i++)
                for (j = 0; j < 6; j++)
                    for (k = 0; k < 48; k++)
                        timetable[i,j,k] = 0;
        }

        public void PlanCourse()
        {
            if (IsFirstRun)
            {
                InitializeIndexReference();
                IndexRefListCollection.Clear();
                CollectionPointer = -1;
            }
            else
            {
                // since we are going to find the next solution
                // we need to progress the current state!
                // therefore, we move the last one forward
                ProgressIndexRefList(IndexRefList.Length - 1);
            }
            if (CourseList.Count == 0)
            {
                MessageBox.Show("You have not entered any course yet!");
                return;
            }

            // start to do the loop
            // indexRefList[i] is the index pointer for CourseList[i]
            while (IndexRefList[0] < CourseList[0].Indices.Count)
            {
                // check current combination
                // if any clash happen, stop current combination and progress to next combination
                InitializeTimeTable();
                int i;
                for (i = 0; i < CourseList.Count; i++) // for each course's current index
                {
                    if (PutIndexIntoTimetable(CourseList[i].Indices[IndexRefList[i]]) == false)
                    {
                        ProgressIndexRefList(i);
                        break;
                    }
                }

                // if i goes through all courses, it means the combination is available
                // otherwise, the while loop will start again and next combination will be examined
                if (i == CourseList.Count)
                {
                    // display the window
                    int[] toSave = new int[CourseList.Count];
                    IndexRefList.CopyTo(toSave, 0);
                    IndexRefListCollection.Add(toSave);
                    CollectionPointer++;
                    if (IsFirstRun)
                    {
                        Form newTimeTablePage = new TimeTablePage();
                        newTimeTablePage.Show();
                        IsFirstRun = false;
                    }
                    break;
                }
            }
        }

        private bool PutIndexIntoTimetable(Index index)
        {
            foreach (IndexRow ir in index.IndexRows)
            {
                int day = (int)ir.Day;
                int startTime = (Convert.ToInt32(ir.StartTime) / 100 * 2)
                    + ((Convert.ToInt32(ir.StartTime) % 100 == 0) ? 0 : 1);
                int endTime = (Convert.ToInt32(ir.EndTime) / 100 * 2)
                    + ((Convert.ToInt32(ir.EndTime) % 100 == 0) ? 0 : 1);
                for (int i = 0; i < 13; i++)
                {
                    if (ir.IsScheduledInWeek[i])
                    {
                        for (int j = startTime; j < endTime; j++)
                        {
                            if (timetable[i, day, j] == 0 || timetable[i, day, j] == Convert.ToInt32(index.IndexNumber))
                                timetable[i, day, j] = Convert.ToInt32(index.IndexNumber);
                            else 
                                return false;
                        }
                    }
                }
            }
            return true;
        }

        private void ProgressIndexRefList(int startingRef)
        {
            // recursion termination condition: it has reached all combinations
            if (startingRef == -1)
                return;
            IndexRefList[startingRef]++;
            if (IndexRefList[startingRef] >= CourseList[startingRef].Indices.Count)
            {
                if (startingRef != 0)
                {
                    IndexRefList[startingRef] = 0;
                }
                ProgressIndexRefList(startingRef - 1);
            }
        }

        public bool CheckExamTime()
        {
            foreach (Course c in CourseList)
            {
                Course course;
                if ((course = CourseList.Find(
                    co => (co.ExamTime == c.ExamTime && co.ExamTime != "no exam" && c != co)
                    )) != null)
                {
                    MessageBox.Show("Exam Time of " + c.CourseCode + " clashes with " + course.CourseCode);
                    return false;
                }
            }
            return true;
        }


        #endregion

    }
}
