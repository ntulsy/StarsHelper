namespace StarsHelper
{
    partial class AddSpecialNeedPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.Cause = new System.Windows.Forms.TextBox();
            this.Day = new System.Windows.Forms.TextBox();
            this.StartTime = new System.Windows.Forms.TextBox();
            this.EndTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cause (e.g. Lunch)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Which Day? (1-7 for Mon-Sun)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Start From? (e.g.0830)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "End At (e.g. 2100)";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(164, 126);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(108, 40);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "I know I want a lot! Please Proceed!";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // Cause
            // 
            this.Cause.Location = new System.Drawing.Point(175, 9);
            this.Cause.Name = "Cause";
            this.Cause.Size = new System.Drawing.Size(100, 20);
            this.Cause.TabIndex = 5;
            // 
            // Day
            // 
            this.Day.Location = new System.Drawing.Point(175, 39);
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(100, 20);
            this.Day.TabIndex = 6;
            // 
            // StartTime
            // 
            this.StartTime.Location = new System.Drawing.Point(175, 70);
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(100, 20);
            this.StartTime.TabIndex = 7;
            // 
            // EndTime
            // 
            this.EndTime.Location = new System.Drawing.Point(175, 98);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(100, 20);
            this.EndTime.TabIndex = 8;
            // 
            // AddSpecialNeedPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 178);
            this.Controls.Add(this.EndTime);
            this.Controls.Add(this.StartTime);
            this.Controls.Add(this.Day);
            this.Controls.Add(this.Cause);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSpecialNeedPage";
            this.Text = "Special Need";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox Cause;
        private System.Windows.Forms.TextBox Day;
        private System.Windows.Forms.TextBox StartTime;
        private System.Windows.Forms.TextBox EndTime;
    }
}