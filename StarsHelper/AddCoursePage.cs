using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StarsHelper.CoursePlanningLogic;

namespace StarsHelper
{
    public partial class AddCoursePage : Form
    {
        private Form source;
        public AddCoursePage(Form source)
        {
            this.source = source;
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            string[] value = CourseBox.Text.Split('\n');
            CoursePlanningController cpc = new CoursePlanningController();
            cpc.AddCourse(value);
            source.Refresh();
            this.Close();
        }
    }
}
