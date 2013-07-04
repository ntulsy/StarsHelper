using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StarsHelper.Structures;
using StarsHelper.CoursePlanningLogic;

namespace StarsHelper
{
    public partial class AddSpecialNeedPage : Form
    {
        private Form source;
        public AddSpecialNeedPage(Form source)
        {
            InitializeComponent();
            this.source = source;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Course course = new Course();
            course.CourseCode = Cause.Text;
            course.CourseName = Cause.Text;
            course.ExamTime = "no exam";
            Index index = new Index();
            index.IndexNumber = "-1";
            index.Group = "FOREVER ALONE";
            IndexRow indexRow = new IndexRow();
            indexRow.Day = (WeekDays)Convert.ToInt32(Day.Text);
            indexRow.StartTime = StartTime.Text;
            indexRow.EndTime = EndTime.Text;
            for (int i = 0; i < 13; i++)
            {
                indexRow.IsScheduledInWeek[i] = true;
            }

            course.addIndex(index);
            index.addIndexRow(indexRow);
            CoursePlanningController.CourseList.Add(course);

            source.Refresh();
            this.Close();
        }
    }
}
