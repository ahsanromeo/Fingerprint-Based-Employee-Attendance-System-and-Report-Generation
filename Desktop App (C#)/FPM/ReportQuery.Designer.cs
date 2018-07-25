namespace FPM
{
    partial class ReportQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.startDate = new MetroFramework.Controls.MetroDateTime();
            this.endDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.holicheck = new MetroFramework.Controls.MetroCheckBox();
            this.leaveCheck = new MetroFramework.Controls.MetroCheckBox();
            this.dataGrid = new MetroFramework.Controls.MetroGrid();
            this.btn_Build = new MetroFramework.Controls.MetroButton();
            this.label_No_Data = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(225, 67);
            this.startDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(200, 29);
            this.startDate.TabIndex = 1;
            this.startDate.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.startDate.CloseUp += new System.EventHandler(this.startDate_CloseUp);
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(225, 145);
            this.endDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(200, 29);
            this.endDate.TabIndex = 2;
            this.endDate.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.endDate.CloseUp += new System.EventHandler(this.endDate_CloseUp);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(223, 45);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(116, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Choose Start Date";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(222, 123);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(110, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Choose End Date";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // holicheck
            // 
            this.holicheck.AutoSize = true;
            this.holicheck.Location = new System.Drawing.Point(225, 210);
            this.holicheck.Name = "holicheck";
            this.holicheck.Size = new System.Drawing.Size(147, 15);
            this.holicheck.TabIndex = 5;
            this.holicheck.Text = "Include Weekly Holiday";
            this.holicheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.holicheck.UseSelectable = true;
            this.holicheck.CheckedChanged += new System.EventHandler(this.holicheck_CheckedChanged);
            // 
            // leaveCheck
            // 
            this.leaveCheck.AutoSize = true;
            this.leaveCheck.Location = new System.Drawing.Point(225, 241);
            this.leaveCheck.Name = "leaveCheck";
            this.leaveCheck.Size = new System.Drawing.Size(100, 15);
            this.leaveCheck.TabIndex = 6;
            this.leaveCheck.Text = "Include Leaves";
            this.leaveCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.leaveCheck.UseSelectable = true;
            this.leaveCheck.CheckedChanged += new System.EventHandler(this.leaveCheck_CheckedChanged);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGrid.EnableHeadersVisualStyles = false;
            this.dataGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGrid.Location = new System.Drawing.Point(41, 279);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(562, 150);
            this.dataGrid.TabIndex = 7;
            this.dataGrid.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btn_Build
            // 
            this.btn_Build.Location = new System.Drawing.Point(225, 455);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Size = new System.Drawing.Size(200, 36);
            this.btn_Build.TabIndex = 8;
            this.btn_Build.Text = "Build Report";
            this.btn_Build.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_Build.UseSelectable = true;
            this.btn_Build.Click += new System.EventHandler(this.btn_Build_Click);
            // 
            // label_No_Data
            // 
            this.label_No_Data.AutoSize = true;
            this.label_No_Data.Location = new System.Drawing.Point(289, 361);
            this.label_No_Data.Name = "label_No_Data";
            this.label_No_Data.Size = new System.Drawing.Size(58, 19);
            this.label_No_Data.TabIndex = 9;
            this.label_No_Data.Text = "No Data";
            this.label_No_Data.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // ReportQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 542);
            this.Controls.Add(this.label_No_Data);
            this.Controls.Add(this.btn_Build);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.leaveCheck);
            this.Controls.Add(this.holicheck);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Name = "ReportQuery";
            this.Resizable = false;
            this.Text = "Adjust Query";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.ReportQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroDateTime startDate;
        private MetroFramework.Controls.MetroDateTime endDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroCheckBox holicheck;
        private MetroFramework.Controls.MetroCheckBox leaveCheck;
        private MetroFramework.Controls.MetroGrid dataGrid;
        private MetroFramework.Controls.MetroButton btn_Build;
        private MetroFramework.Controls.MetroLabel label_No_Data;
    }
}