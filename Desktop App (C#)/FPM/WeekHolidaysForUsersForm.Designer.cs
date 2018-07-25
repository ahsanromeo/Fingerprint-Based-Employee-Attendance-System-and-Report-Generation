namespace FPM
{
    partial class WeekHolidaysForUsersForm
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
            this.Sunday = new MetroFramework.Controls.MetroCheckBox();
            this.Monday = new MetroFramework.Controls.MetroCheckBox();
            this.Tuesday = new MetroFramework.Controls.MetroCheckBox();
            this.Wednesday = new MetroFramework.Controls.MetroCheckBox();
            this.Thursday = new MetroFramework.Controls.MetroCheckBox();
            this.Friday = new MetroFramework.Controls.MetroCheckBox();
            this.Saterday = new MetroFramework.Controls.MetroCheckBox();
            this.btn_OK = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // Sunday
            // 
            this.Sunday.AutoSize = true;
            this.Sunday.Location = new System.Drawing.Point(155, 85);
            this.Sunday.Name = "Sunday";
            this.Sunday.Size = new System.Drawing.Size(62, 15);
            this.Sunday.TabIndex = 0;
            this.Sunday.Text = "Sunday";
            this.Sunday.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Sunday.UseSelectable = true;
            // 
            // Monday
            // 
            this.Monday.AutoSize = true;
            this.Monday.Location = new System.Drawing.Point(155, 125);
            this.Monday.Name = "Monday";
            this.Monday.Size = new System.Drawing.Size(67, 15);
            this.Monday.TabIndex = 0;
            this.Monday.Text = "Monday";
            this.Monday.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Monday.UseSelectable = true;
            // 
            // Tuesday
            // 
            this.Tuesday.AutoSize = true;
            this.Tuesday.Location = new System.Drawing.Point(155, 168);
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.Size = new System.Drawing.Size(67, 15);
            this.Tuesday.TabIndex = 0;
            this.Tuesday.Text = "Tuesday";
            this.Tuesday.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Tuesday.UseSelectable = true;
            // 
            // Wednesday
            // 
            this.Wednesday.AutoSize = true;
            this.Wednesday.Location = new System.Drawing.Point(155, 209);
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.Size = new System.Drawing.Size(84, 15);
            this.Wednesday.TabIndex = 0;
            this.Wednesday.Text = "Wednesday";
            this.Wednesday.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Wednesday.UseSelectable = true;
            // 
            // Thursday
            // 
            this.Thursday.AutoSize = true;
            this.Thursday.Location = new System.Drawing.Point(155, 248);
            this.Thursday.Name = "Thursday";
            this.Thursday.Size = new System.Drawing.Size(72, 15);
            this.Thursday.TabIndex = 0;
            this.Thursday.Text = "Thursday";
            this.Thursday.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Thursday.UseSelectable = true;
            // 
            // Friday
            // 
            this.Friday.AutoSize = true;
            this.Friday.Location = new System.Drawing.Point(155, 285);
            this.Friday.Name = "Friday";
            this.Friday.Size = new System.Drawing.Size(55, 15);
            this.Friday.TabIndex = 0;
            this.Friday.Text = "Friday";
            this.Friday.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Friday.UseSelectable = true;
            // 
            // Saterday
            // 
            this.Saterday.AutoSize = true;
            this.Saterday.Location = new System.Drawing.Point(155, 331);
            this.Saterday.Name = "Saterday";
            this.Saterday.Size = new System.Drawing.Size(68, 15);
            this.Saterday.TabIndex = 0;
            this.Saterday.Text = "Saterday";
            this.Saterday.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Saterday.UseSelectable = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(113, 381);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(159, 29);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "Ok";
            this.btn_OK.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_OK.UseSelectable = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // WeekHolidaysForUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 449);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.Saterday);
            this.Controls.Add(this.Friday);
            this.Controls.Add(this.Thursday);
            this.Controls.Add(this.Wednesday);
            this.Controls.Add(this.Tuesday);
            this.Controls.Add(this.Monday);
            this.Controls.Add(this.Sunday);
            this.Name = "WeekHolidaysForUsersForm";
            this.Text = "Add Holidays for this employee...";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroCheckBox Sunday;
        private MetroFramework.Controls.MetroCheckBox Monday;
        private MetroFramework.Controls.MetroCheckBox Tuesday;
        private MetroFramework.Controls.MetroCheckBox Wednesday;
        private MetroFramework.Controls.MetroCheckBox Thursday;
        private MetroFramework.Controls.MetroCheckBox Friday;
        private MetroFramework.Controls.MetroCheckBox Saterday;
        private MetroFramework.Controls.MetroButton btn_OK;
    }
}