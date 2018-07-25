namespace FPM
{
    partial class EditHolidayForm
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
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.eDateBox = new MetroFramework.Controls.MetroComboBox();
            this.eMonthBox = new MetroFramework.Controls.MetroComboBox();
            this.sDateBox = new MetroFramework.Controls.MetroComboBox();
            this.sMonthBox = new MetroFramework.Controls.MetroComboBox();
            this.name_text = new MetroFramework.Controls.MetroTextBox();
            this.btn_Add = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(257, 226);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(62, 19);
            this.metroLabel5.TabIndex = 23;
            this.metroLabel5.Text = "End Date";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(82, 226);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(73, 19);
            this.metroLabel4.TabIndex = 22;
            this.metroLabel4.Text = "End Month";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(259, 155);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(68, 19);
            this.metroLabel3.TabIndex = 21;
            this.metroLabel3.Text = "Start Date";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(83, 155);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(79, 19);
            this.metroLabel2.TabIndex = 20;
            this.metroLabel2.Text = "Start Month";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // eDateBox
            // 
            this.eDateBox.FormattingEnabled = true;
            this.eDateBox.ItemHeight = 23;
            this.eDateBox.Location = new System.Drawing.Point(261, 248);
            this.eDateBox.Name = "eDateBox";
            this.eDateBox.Size = new System.Drawing.Size(121, 29);
            this.eDateBox.TabIndex = 19;
            this.eDateBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.eDateBox.UseSelectable = true;
            // 
            // eMonthBox
            // 
            this.eMonthBox.FormattingEnabled = true;
            this.eMonthBox.ItemHeight = 23;
            this.eMonthBox.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.eMonthBox.Location = new System.Drawing.Point(85, 248);
            this.eMonthBox.Name = "eMonthBox";
            this.eMonthBox.Size = new System.Drawing.Size(133, 29);
            this.eMonthBox.TabIndex = 18;
            this.eMonthBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.eMonthBox.UseSelectable = true;
            this.eMonthBox.SelectedIndexChanged += new System.EventHandler(this.eMonthBox_SelectedIndexChanged);
            this.eMonthBox.Click += new System.EventHandler(this.eMonthBox_Click);
            // 
            // sDateBox
            // 
            this.sDateBox.FormattingEnabled = true;
            this.sDateBox.ItemHeight = 23;
            this.sDateBox.Location = new System.Drawing.Point(261, 177);
            this.sDateBox.Name = "sDateBox";
            this.sDateBox.Size = new System.Drawing.Size(121, 29);
            this.sDateBox.TabIndex = 17;
            this.sDateBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.sDateBox.UseSelectable = true;
            // 
            // sMonthBox
            // 
            this.sMonthBox.FormattingEnabled = true;
            this.sMonthBox.ItemHeight = 23;
            this.sMonthBox.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.sMonthBox.Location = new System.Drawing.Point(85, 177);
            this.sMonthBox.Name = "sMonthBox";
            this.sMonthBox.Size = new System.Drawing.Size(133, 29);
            this.sMonthBox.TabIndex = 16;
            this.sMonthBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.sMonthBox.UseSelectable = true;
            this.sMonthBox.SelectedIndexChanged += new System.EventHandler(this.sMonthBox_SelectedIndexChanged);
            this.sMonthBox.Click += new System.EventHandler(this.sMonthBox_Click);
            // 
            // name_text
            // 
            // 
            // 
            // 
            this.name_text.CustomButton.Image = null;
            this.name_text.CustomButton.Location = new System.Drawing.Point(273, 1);
            this.name_text.CustomButton.Name = "";
            this.name_text.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.name_text.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.name_text.CustomButton.TabIndex = 1;
            this.name_text.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.name_text.CustomButton.UseSelectable = true;
            this.name_text.CustomButton.Visible = false;
            this.name_text.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.name_text.Lines = new string[0];
            this.name_text.Location = new System.Drawing.Point(87, 114);
            this.name_text.MaxLength = 32767;
            this.name_text.Name = "name_text";
            this.name_text.PasswordChar = '\0';
            this.name_text.PromptText = "Enter name of the holiday...";
            this.name_text.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.name_text.SelectedText = "";
            this.name_text.SelectionLength = 0;
            this.name_text.SelectionStart = 0;
            this.name_text.ShortcutsEnabled = true;
            this.name_text.Size = new System.Drawing.Size(295, 23);
            this.name_text.TabIndex = 15;
            this.name_text.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.name_text.UseSelectable = true;
            this.name_text.WaterMark = "Enter name of the holiday...";
            this.name_text.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.name_text.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(85, 308);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(297, 29);
            this.btn_Add.TabIndex = 14;
            this.btn_Add.Text = "Update Holiday";
            this.btn_Add.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_Add.UseSelectable = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(84, 92);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(93, 19);
            this.metroLabel1.TabIndex = 13;
            this.metroLabel1.Text = "Holiday Name";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // EditHolidayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 428);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.eDateBox);
            this.Controls.Add(this.eMonthBox);
            this.Controls.Add(this.sDateBox);
            this.Controls.Add(this.sMonthBox);
            this.Controls.Add(this.name_text);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.metroLabel1);
            this.Name = "EditHolidayForm";
            this.Text = "Update Holiday";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox eDateBox;
        private MetroFramework.Controls.MetroComboBox eMonthBox;
        private MetroFramework.Controls.MetroComboBox sDateBox;
        private MetroFramework.Controls.MetroComboBox sMonthBox;
        private MetroFramework.Controls.MetroTextBox name_text;
        private MetroFramework.Controls.MetroButton btn_Add;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}