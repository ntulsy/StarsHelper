namespace StarsHelper
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddCourse = new System.Windows.Forms.Button();
            this.RemoveCourse = new System.Windows.Forms.Button();
            this.Listbox_SelectedCourse = new System.Windows.Forms.ListBox();
            this.Listbox_SelectedIndex = new System.Windows.Forms.ListBox();
            this.Label_CourseInformation = new System.Windows.Forms.Label();
            this.Display_CourseInformation = new System.Windows.Forms.Label();
            this.Display_IndexInformation = new System.Windows.Forms.Label();
            this.Label_SelectedCourses = new System.Windows.Forms.Label();
            this.Label_SelectedIndices = new System.Windows.Forms.Label();
            this.AddIndex = new System.Windows.Forms.Button();
            this.RemoveIndex = new System.Windows.Forms.Button();
            this.PlanCourse = new System.Windows.Forms.Button();
            this.ForceVacancy = new System.Windows.Forms.CheckBox();
            this.IsMixAllowed = new System.Windows.Forms.CheckBox();
            this.CustomizedIndex = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddCourse
            // 
            this.AddCourse.Location = new System.Drawing.Point(389, 21);
            this.AddCourse.Name = "AddCourse";
            this.AddCourse.Size = new System.Drawing.Size(112, 23);
            this.AddCourse.TabIndex = 0;
            this.AddCourse.Text = "Add Course";
            this.AddCourse.UseVisualStyleBackColor = true;
            this.AddCourse.Click += new System.EventHandler(this.AddCourse_Click);
            // 
            // RemoveCourse
            // 
            this.RemoveCourse.Location = new System.Drawing.Point(389, 63);
            this.RemoveCourse.Name = "RemoveCourse";
            this.RemoveCourse.Size = new System.Drawing.Size(112, 23);
            this.RemoveCourse.TabIndex = 1;
            this.RemoveCourse.Text = "Remove Course";
            this.RemoveCourse.UseVisualStyleBackColor = true;
            this.RemoveCourse.Click += new System.EventHandler(this.RemoveCourse_Click);
            // 
            // Listbox_SelectedCourse
            // 
            this.Listbox_SelectedCourse.FormattingEnabled = true;
            this.Listbox_SelectedCourse.Location = new System.Drawing.Point(25, 50);
            this.Listbox_SelectedCourse.Name = "Listbox_SelectedCourse";
            this.Listbox_SelectedCourse.Size = new System.Drawing.Size(166, 173);
            this.Listbox_SelectedCourse.TabIndex = 2;
            this.Listbox_SelectedCourse.SelectedValueChanged += new System.EventHandler(this.Listbox_SelectedCourse_SelectedValueChanged);
            // 
            // Listbox_SelectedIndex
            // 
            this.Listbox_SelectedIndex.FormattingEnabled = true;
            this.Listbox_SelectedIndex.Location = new System.Drawing.Point(230, 50);
            this.Listbox_SelectedIndex.Name = "Listbox_SelectedIndex";
            this.Listbox_SelectedIndex.Size = new System.Drawing.Size(135, 173);
            this.Listbox_SelectedIndex.TabIndex = 3;
            this.Listbox_SelectedIndex.SelectedValueChanged += new System.EventHandler(this.Listbox_SelectedIndex_SelectedValueChanged);
            // 
            // Label_CourseInformation
            // 
            this.Label_CourseInformation.AutoSize = true;
            this.Label_CourseInformation.Location = new System.Drawing.Point(22, 226);
            this.Label_CourseInformation.Name = "Label_CourseInformation";
            this.Label_CourseInformation.Size = new System.Drawing.Size(98, 13);
            this.Label_CourseInformation.TabIndex = 4;
            this.Label_CourseInformation.Text = "Course Information:";
            // 
            // Display_CourseInformation
            // 
            this.Display_CourseInformation.AutoSize = true;
            this.Display_CourseInformation.Location = new System.Drawing.Point(22, 239);
            this.Display_CourseInformation.Name = "Display_CourseInformation";
            this.Display_CourseInformation.Size = new System.Drawing.Size(33, 13);
            this.Display_CourseInformation.TabIndex = 6;
            this.Display_CourseInformation.Text = "None";
            // 
            // Display_IndexInformation
            // 
            this.Display_IndexInformation.AutoSize = true;
            this.Display_IndexInformation.Location = new System.Drawing.Point(22, 285);
            this.Display_IndexInformation.Name = "Display_IndexInformation";
            this.Display_IndexInformation.Size = new System.Drawing.Size(33, 13);
            this.Display_IndexInformation.TabIndex = 7;
            this.Display_IndexInformation.Text = "None";
            // 
            // Label_SelectedCourses
            // 
            this.Label_SelectedCourses.AutoSize = true;
            this.Label_SelectedCourses.Location = new System.Drawing.Point(22, 21);
            this.Label_SelectedCourses.Name = "Label_SelectedCourses";
            this.Label_SelectedCourses.Size = new System.Drawing.Size(93, 13);
            this.Label_SelectedCourses.TabIndex = 8;
            this.Label_SelectedCourses.Text = "Selected Courses:";
            // 
            // Label_SelectedIndices
            // 
            this.Label_SelectedIndices.AutoSize = true;
            this.Label_SelectedIndices.Location = new System.Drawing.Point(229, 21);
            this.Label_SelectedIndices.Name = "Label_SelectedIndices";
            this.Label_SelectedIndices.Size = new System.Drawing.Size(89, 13);
            this.Label_SelectedIndices.TabIndex = 9;
            this.Label_SelectedIndices.Text = "Selected Indices:";
            // 
            // AddIndex
            // 
            this.AddIndex.Location = new System.Drawing.Point(389, 105);
            this.AddIndex.Name = "AddIndex";
            this.AddIndex.Size = new System.Drawing.Size(112, 23);
            this.AddIndex.TabIndex = 10;
            this.AddIndex.Text = "Add Index";
            this.AddIndex.UseVisualStyleBackColor = true;
            this.AddIndex.Click += new System.EventHandler(this.AddIndex_Click);
            // 
            // RemoveIndex
            // 
            this.RemoveIndex.Location = new System.Drawing.Point(389, 146);
            this.RemoveIndex.Name = "RemoveIndex";
            this.RemoveIndex.Size = new System.Drawing.Size(112, 23);
            this.RemoveIndex.TabIndex = 11;
            this.RemoveIndex.Text = "Remove Index";
            this.RemoveIndex.UseVisualStyleBackColor = true;
            this.RemoveIndex.Click += new System.EventHandler(this.RemoveIndex_Click);
            // 
            // PlanCourse
            // 
            this.PlanCourse.Location = new System.Drawing.Point(389, 319);
            this.PlanCourse.Name = "PlanCourse";
            this.PlanCourse.Size = new System.Drawing.Size(112, 23);
            this.PlanCourse.TabIndex = 12;
            this.PlanCourse.Text = "Plan My Course";
            this.PlanCourse.UseVisualStyleBackColor = true;
            this.PlanCourse.Click += new System.EventHandler(this.PlanCourse_Click);
            // 
            // ForceVacancy
            // 
            this.ForceVacancy.AutoSize = true;
            this.ForceVacancy.Location = new System.Drawing.Point(25, 319);
            this.ForceVacancy.Name = "ForceVacancy";
            this.ForceVacancy.Size = new System.Drawing.Size(185, 17);
            this.ForceVacancy.TabIndex = 13;
            this.ForceVacancy.Text = "Combinations must have vacancy";
            this.ForceVacancy.UseVisualStyleBackColor = true;
            // 
            // IsMixAllowed
            // 
            this.IsMixAllowed.AutoSize = true;
            this.IsMixAllowed.Location = new System.Drawing.Point(25, 352);
            this.IsMixAllowed.Name = "IsMixAllowed";
            this.IsMixAllowed.Size = new System.Drawing.Size(153, 17);
            this.IsMixAllowed.TabIndex = 14;
            this.IsMixAllowed.Text = "Allow mix of tutorial and lab";
            this.IsMixAllowed.UseVisualStyleBackColor = true;
            // 
            // CustomizedIndex
            // 
            this.CustomizedIndex.Location = new System.Drawing.Point(389, 188);
            this.CustomizedIndex.Name = "CustomizedIndex";
            this.CustomizedIndex.Size = new System.Drawing.Size(112, 35);
            this.CustomizedIndex.TabIndex = 15;
            this.CustomizedIndex.Text = "Wah! I have some special needs!";
            this.CustomizedIndex.UseVisualStyleBackColor = true;
            this.CustomizedIndex.Click += new System.EventHandler(this.CustomizedIndex_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Monitor Vacancy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 382);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CustomizedIndex);
            this.Controls.Add(this.IsMixAllowed);
            this.Controls.Add(this.ForceVacancy);
            this.Controls.Add(this.PlanCourse);
            this.Controls.Add(this.RemoveIndex);
            this.Controls.Add(this.AddIndex);
            this.Controls.Add(this.Label_SelectedIndices);
            this.Controls.Add(this.Label_SelectedCourses);
            this.Controls.Add(this.Display_IndexInformation);
            this.Controls.Add(this.Display_CourseInformation);
            this.Controls.Add(this.Label_CourseInformation);
            this.Controls.Add(this.Listbox_SelectedIndex);
            this.Controls.Add(this.Listbox_SelectedCourse);
            this.Controls.Add(this.RemoveCourse);
            this.Controls.Add(this.AddCourse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.Text = "AmmiNi Stars Helper V1.0.0";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddCourse;
        private System.Windows.Forms.Button RemoveCourse;
        private System.Windows.Forms.ListBox Listbox_SelectedCourse;
        private System.Windows.Forms.ListBox Listbox_SelectedIndex;
        private System.Windows.Forms.Label Label_CourseInformation;
        private System.Windows.Forms.Label Display_CourseInformation;
        private System.Windows.Forms.Label Display_IndexInformation;
        private System.Windows.Forms.Label Label_SelectedCourses;
        private System.Windows.Forms.Label Label_SelectedIndices;
        private System.Windows.Forms.Button AddIndex;
        private System.Windows.Forms.Button RemoveIndex;
        private System.Windows.Forms.Button PlanCourse;
        private System.Windows.Forms.CheckBox ForceVacancy;
        private System.Windows.Forms.CheckBox IsMixAllowed;
        private System.Windows.Forms.Button CustomizedIndex;
        private System.Windows.Forms.Button button1;

    }
}

