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
using System.Text.RegularExpressions;

namespace StarsHelper
{
    public partial class AddNewIndexPage : Form
    {
        private Form source;
        public AddNewIndexPage(Form source)
        {
            InitializeComponent();
            this.source = source;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            CoursePlanningController cpc = new CoursePlanningController();
            if (CourseCode.Text.Length != 6 &&
                CourseCode.Text.Length != 5 ||
                Regex.IsMatch(CourseCode.Text, @"^[a-zA-Z]+$") )
            {
                MessageBox.Show("Please enter valid course code!");
                return;
            }
            int i;
            if (IndexNumber.Text.Length != 5 ||
                int.TryParse(IndexNumber.Text, out i) == false)
            {
                MessageBox.Show("Please enter valid index number!");
                return;
            }

            cpc.addIndex(CourseCode.Text, IndexNumber.Text);
            source.Refresh();
            this.Close();
        }
    }
}
