using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace StarsHelper.NetworkLayer
{
    internal class NetworkCommunicator
    {
        private const string COURSE_INFO_URL = "https://wish.wis.ntu.edu.sg/webexe/owa/AUS_SCHEDULE.main_display1";
        private const string COURSE_VACANCY_URL = "";
        private const string COURSE_EXAM_TIME_URL = "https://wis.ntu.edu.sg/webexe/owa/exam_timetable_und.get_detail";


        public string GetCourseInfo(string _courseCode)
        {
            string courseCode = _courseCode.ToUpper();
            try
            {
                string courseInfoPostData = "acadsem=2013%3B2&r_course_yr=&r_subj_code="+ courseCode + "&r_search_type=F&boption=Search&acadsem=2013%3B1&staff_access=false";
                return getData(COURSE_INFO_URL, "POST", courseInfoPostData);
            }
            catch
            {
                return null;
            }
        }

        public string GetCourseVacancy(string _courseCode)
        {
            throw new NotImplementedException();
            string courseCode = _courseCode.ToUpper();
            string courseVavancyPostData = "acadsem=2013%3B2&r_course_yr=&r_subj_code=" + courseCode + "&r_search_type=F&boption=Search&acadsem=2013%3B1&staff_access=false";
            return getData(COURSE_VACANCY_URL, "POST", courseVavancyPostData);
        }

        public string GetCourseExamTime(string _courseCode)
        {
            string courseCode = _courseCode.ToUpper();
            string courseExamTimePostData = "p_exam_dt=&p_start_time=&p_dept=&p_subj=" + courseCode + "&p_venue=&academic_session=Semester+1+Academic+Year+2013-2014&p_plan_no=2&p_exam_yr=2013&p_semester=1&bOption=Next";
            return getData(COURSE_EXAM_TIME_URL, "POST", courseExamTimePostData);
        }


        private string getData(string url, string method, string data)
        {
            byte[] postData = Encoding.UTF8.GetBytes(data);
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            byte[] responseData = webClient.UploadData(url, method, postData);
            string srcString = Encoding.UTF8.GetString(responseData);
            return srcString;
        }

    }
}
