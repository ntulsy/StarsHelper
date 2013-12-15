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
using StarsHelper.Structures;

namespace StarsHelper
{
    public partial class TimeTablePage : Form
    {
        public TimeTablePage()
        {
            InitializeComponent();
        }

        private const int CELL_HEIGHT = 20;
        private const int CELL_WIDTH = 125;
        private static Color HEADER_COLOR = Color.Cyan;
        private static Color COURSE_COLOR = Color.Cyan;
        private static int currentIndex;

        public void InitializeTable()
        {
            InitializeHeaderComponents();
            DisplayTimetableComponents(CoursePlanningController.IndexRefList);
            currentIndex = CoursePlanningController.CollectionPointer;
        }

        private void DisplayTimetableComponents(int[] indexRefList)
        {
            for (int i = 0; i < indexRefList.Length; i++)
            {
                Index index = CoursePlanningController.CourseList[i].Indices[indexRefList[i]];
                foreach (IndexRow ir in index.IndexRows)
                {
                    // generate label content
                    Label label = new Label();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(CoursePlanningController.CourseList[i].CourseCode + " ");
                    sb.Append(index.IndexNumber + " ");
                    sb.Append(index.Group + " ");
                    sb.Append(ir.Type + " ");
                    sb.Append(ir.Venue);
                    label.Text = sb.ToString();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.BackColor = COURSE_COLOR;

                    // calculate position and span in table
                    int _start = (Convert.ToInt32(ir.StartTime) / 100 - 8) * 2;
                    _start++; // header offset
                    if (Convert.ToInt32(ir.StartTime) % 100 == 0)
                        _start--;
                    // 我操，牛逼算法，我数学真好
                    int _span = (Convert.ToInt32(ir.EndTime) - Convert.ToInt32(ir.StartTime) + 20) / 50;

                    // adjust the size of label
                    label.Size = new Size(CELL_WIDTH, CELL_HEIGHT * _span);

                    // put the label into table
                    Control existingControl = TimeTablePanel.GetControlFromPosition((int)ir.Day, _start + 1);
                    if (existingControl == null)
                    {
                        TimeTablePanel.Controls.Add(label, (int)ir.Day, _start);
                        TimeTablePanel.SetRowSpan(label, _span);
                    }
                    else
                    {
                        ((Label)existingControl).Text += "\n" + label.Text;
                    }
                }
            }
        }

        private void InitializeHeaderComponents()
        {
            foreach (RowStyle rs in TimeTablePanel.RowStyles)
            {
                rs.Height = CELL_HEIGHT;
            }

            foreach (ColumnStyle cs in TimeTablePanel.ColumnStyles)
            {
                cs.Width = CELL_WIDTH;
            }

            Label Monday_Label = new Label();
            Monday_Label.Text = "Monday";
            Monday_Label.Size = new Size(CELL_WIDTH, CELL_HEIGHT);
            Monday_Label.TextAlign = ContentAlignment.MiddleCenter;
            Monday_Label.BackColor = HEADER_COLOR;
            TimeTablePanel.Controls.Add(Monday_Label, 1, 0);

            Label Tuesday_Label = new Label();
            Tuesday_Label.Text = "Tuesday";
            Tuesday_Label.Size = new Size(CELL_WIDTH, CELL_HEIGHT);
            Tuesday_Label.TextAlign = ContentAlignment.MiddleCenter;
            Tuesday_Label.BackColor = HEADER_COLOR;
            TimeTablePanel.Controls.Add(Tuesday_Label, 2, 0);

            Label Wednesday_Label = new Label();
            Wednesday_Label.Text = "Wednesday";
            Wednesday_Label.Size = new Size(CELL_WIDTH, CELL_HEIGHT);
            Wednesday_Label.TextAlign = ContentAlignment.MiddleCenter;
            Wednesday_Label.BackColor = HEADER_COLOR;
            TimeTablePanel.Controls.Add(Wednesday_Label, 3, 0);

            Label Thursday_Label = new Label();
            Thursday_Label.Text = "Thursday";
            Thursday_Label.Size = new Size(CELL_WIDTH, CELL_HEIGHT);
            Thursday_Label.TextAlign = ContentAlignment.MiddleCenter;
            Thursday_Label.BackColor = HEADER_COLOR;
            TimeTablePanel.Controls.Add(Thursday_Label, 4, 0);

            Label Friday_Label = new Label();
            Friday_Label.Text = "Friday";
            Friday_Label.Size = new Size(CELL_WIDTH, CELL_HEIGHT);
            Friday_Label.TextAlign = ContentAlignment.MiddleCenter;
            Friday_Label.BackColor = HEADER_COLOR;
            TimeTablePanel.Controls.Add(Friday_Label, 5, 0);

            Label Saturday_Label = new Label();
            Saturday_Label.Text = "Saturday";
            Saturday_Label.Size = new Size(CELL_WIDTH, CELL_HEIGHT);
            Saturday_Label.TextAlign = ContentAlignment.MiddleCenter;
            Saturday_Label.BackColor = HEADER_COLOR;
            TimeTablePanel.Controls.Add(Saturday_Label, 6, 0);

            int time = 830;
            for (int i = 1; i < 29; i++)
            {
                Label TimeLabel = new Label();
                TimeLabel.Size = new Size(CELL_WIDTH, CELL_HEIGHT);
                TimeLabel.TextAlign = ContentAlignment.MiddleCenter;
                TimeLabel.BackColor = HEADER_COLOR;
                StringBuilder sb = new StringBuilder();
                sb.Append(time);
                sb.Append("-");
                incrementHour(ref time);
                sb.Append(time);
                TimeLabel.Text = sb.ToString();
                TimeTablePanel.Controls.Add(TimeLabel, 0, i);
            }
        }

        private void incrementHour(ref int i)
        {
            i += 30;
            if (i % 100 == 60)
                i = (i / 100 + 1) * 100;
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            Next.Enabled = false;
            Previous.Enabled = false;
            Save.Enabled = false;
            TimeTablePanel.Hide();
            TimeTablePanel.Controls.Clear();
            InitializeHeaderComponents();
            try
            {
                DisplayTimetableComponents(CoursePlanningController.IndexRefListCollection[--currentIndex]);
            }
            catch
            {
                MessageBox.Show("No previous combination.");
                currentIndex++;
                DisplayTimetableComponents(CoursePlanningController.IndexRefListCollection[currentIndex]);
            }
            TimeTablePanel.Show();
            Next.Enabled = true;
            Previous.Enabled = true;
            Save.Enabled = true;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Next.Enabled = false;
            Previous.Enabled = false;
            Save.Enabled = false;
            TimeTablePanel.Hide();
            TimeTablePanel.Controls.Clear();
            InitializeHeaderComponents();
            try
            {
                DisplayTimetableComponents(CoursePlanningController.IndexRefListCollection[++currentIndex]);
            }
            // if there is really no next one, generate it
            catch (ArgumentOutOfRangeException ex)
            {
                // oldCollectionPointer is used to determine whether new solution has been generated
                // therefore it will determine whether the end has been reached
                int oldCollectionPointer = CoursePlanningController.CollectionPointer;
                CoursePlanningController cpc = new CoursePlanningController();
                cpc.PlanCourseAndDisplayTimetable();
                currentIndex = CoursePlanningController.CollectionPointer;
                if (oldCollectionPointer == currentIndex)
                    MessageBox.Show("There is no more combination.");
                DisplayTimetableComponents(CoursePlanningController.IndexRefListCollection[currentIndex]);
            }
            TimeTablePanel.Show();
            Next.Enabled = true;
            Previous.Enabled = true;
            Save.Enabled = true;
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimeTablePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            CoursePlanningController.IsFirstRun = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It will be done in the next release!");
        }
    }
}
