using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsHelper.Structures
{
    public class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public List<Index> Indices { get; private set; }
        public string ExamTime { get; set; }

        public Course()
        {
            ExamTime = "no exam";
            Indices = new List<Index>();
        }

        public void addIndex(Index index)
        {
            Indices.Add(index);
        }

        public void removeIndex(string indexNumber)
        {
            Indices.RemoveAll(i => i.IndexNumber == indexNumber);
        }

    }
}
