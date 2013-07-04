using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using StarsHelper.Structures;
using StarsHelper.CoursePlanningLogic;

namespace StarsHelper
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void MainPage_Load(object sender, EventArgs e)
        {
            
        }

        private void AddCourse_Click(object sender, EventArgs e)
        {
            Form newAddCoursePage = new AddCoursePage(this);
            newAddCoursePage.Show();
        }

        public override void Refresh()
        {
            base.Refresh();
            RefreshCourseList();
            RefreshIndexList();
        }

        private void RefreshCourseList()
        {
            Listbox_SelectedCourse.DataSource = null;
            if (CoursePlanningController.CourseList.Count != 0)
            {
                Listbox_SelectedCourse.DataSource = CoursePlanningController.CourseList;
                Listbox_SelectedCourse.DisplayMember = "CourseCode";
            }
        }

        private void RefreshIndexList()
        {
            Listbox_SelectedIndex.DataSource = null;
            if (Listbox_SelectedCourse.SelectedValue != null)
            {
                Course course = CoursePlanningController.CourseList.Find(
                        c => c.CourseCode == ((Course)Listbox_SelectedCourse.SelectedValue).CourseCode);
                Listbox_SelectedIndex.DataSource = course.Indices;
                Listbox_SelectedIndex.DisplayMember = "IndexNumber";
            }
        }

        private void Listbox_SelectedCourse_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Listbox_SelectedCourse.SelectedValue != null)
            {
                Course course = CoursePlanningController.CourseList.Find(
                    c => c.CourseCode == ((Course)Listbox_SelectedCourse.SelectedValue).CourseCode);
                
                StringBuilder sb = new StringBuilder ();
                sb.Append("Course code: ");
                sb.Append(course.CourseCode);
                sb.Append("  ");
                sb.Append(course.CourseName);
                sb.Append("\n");
                sb.Append("Exam Time: ");
                sb.Append(course.ExamTime);
                Display_CourseInformation.Text = sb.ToString();

                this.RefreshIndexList();
            }
        }

        private void Listbox_SelectedIndex_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Listbox_SelectedIndex.SelectedValue != null)
            {
                // find course
                Course course = CoursePlanningController.CourseList.Find(
                    c => c.CourseCode == ((Course)Listbox_SelectedCourse.SelectedValue).CourseCode);
                // find index
                Index index = course.Indices.Find(
                    i => i.IndexNumber == ((Index)(Listbox_SelectedIndex.SelectedValue)).IndexNumber);

                StringBuilder sb = new StringBuilder();
                sb.Append("Index Group: ");
                sb.Append(index.Group);
                sb.Append("\n");
                sb.Append("Current Vacancy:");
                Display_IndexInformation.Text = sb.ToString();
            }
        }

        private void RemoveCourse_Click(object sender, EventArgs e)
        {
            CoursePlanningController cpc = new CoursePlanningController();
            if (Listbox_SelectedCourse.SelectedValue != null)
            {
                cpc.RemoveCourse(((Course)Listbox_SelectedCourse.SelectedValue).CourseCode);

                // refresh the course list
                this.Refresh();
            }
        }

        private void RemoveIndex_Click(object sender, EventArgs e)
        {
            CoursePlanningController cpc = new CoursePlanningController();
            if (Listbox_SelectedCourse.SelectedValue != null
                && Listbox_SelectedIndex.SelectedValue != null)
            {
                cpc.RemoveIndexFromCourse(((Course)Listbox_SelectedCourse.SelectedValue).CourseCode,
                    ((Index)(Listbox_SelectedIndex.SelectedValue)).IndexNumber);

                // refresh index list
                this.Refresh();
            }
        }

        private void AddIndex_Click(object sender, EventArgs e)
        {
            Form newAddNewIndexPage = new AddNewIndexPage(this);
            newAddNewIndexPage.Show();
        }

        private void CustomizedIndex_Click(object sender, EventArgs e)
        {
            Form newAddSpecialNeedPage = new AddSpecialNeedPage(this);
            newAddSpecialNeedPage.Show();
        }

        private void PlanCourse_Click(object sender, EventArgs e)
        {
            CoursePlanningController cpc = new CoursePlanningController();
            if (cpc.CheckExamTime())
                cpc.PlanCourse();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It will be available in the next release!");
        }
    }
}
