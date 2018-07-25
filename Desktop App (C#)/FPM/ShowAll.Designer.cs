namespace FPM
{
    partial class Employees
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new MetroFramework.Controls.MetroGrid();
            this.Label_Wait = new MetroFramework.Controls.MetroLabel();
            this.btn_Update = new MetroFramework.Controls.MetroButton();
            this.btn_Delete = new MetroFramework.Controls.MetroButton();
            this.btn_Report = new MetroFramework.Controls.MetroButton();
            this.btn_GLeave = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGrid.EnableHeadersVisualStyles = false;
            this.dataGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGrid.Location = new System.Drawing.Point(12, 76);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(1085, 384);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Label_Wait
            // 
            this.Label_Wait.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label_Wait.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.Label_Wait.Location = new System.Drawing.Point(221, 76);
            this.Label_Wait.Name = "Label_Wait";
            this.Label_Wait.Size = new System.Drawing.Size(324, 156);
            this.Label_Wait.TabIndex = 1;
            this.Label_Wait.Text = "Please Wait...";
            this.Label_Wait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_Wait.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(606, 27);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(118, 23);
            this.btn_Update.TabIndex = 3;
            this.btn_Update.Text = "Update Info";
            this.btn_Update.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_Update.UseSelectable = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(815, 27);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(155, 23);
            this.btn_Delete.TabIndex = 4;
            this.btn_Delete.Text = "Delete Selected Employee";
            this.btn_Delete.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_Delete.UseSelectable = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Report
            // 
            this.btn_Report.Location = new System.Drawing.Point(199, 27);
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(117, 23);
            this.btn_Report.TabIndex = 5;
            this.btn_Report.Text = "Report";
            this.btn_Report.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_Report.UseSelectable = true;
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            // 
            // btn_GLeave
            // 
            this.btn_GLeave.Location = new System.Drawing.Point(408, 27);
            this.btn_GLeave.Name = "btn_GLeave";
            this.btn_GLeave.Size = new System.Drawing.Size(123, 23);
            this.btn_GLeave.TabIndex = 6;
            this.btn_GLeave.Text = "Grant Leave";
            this.btn_GLeave.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_GLeave.UseSelectable = true;
            this.btn_GLeave.Click += new System.EventHandler(this.btn_GLeave_Click);
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 530);
            this.Controls.Add(this.btn_GLeave);
            this.Controls.Add(this.btn_Report);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.Label_Wait);
            this.Controls.Add(this.dataGrid);
            this.Name = "Employees";
            this.Text = "Employee List";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Shown += new System.EventHandler(this.Employees_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroGrid dataGrid;
        private MetroFramework.Controls.MetroLabel Label_Wait;
        private MetroFramework.Controls.MetroButton btn_Update;
        private MetroFramework.Controls.MetroButton btn_Delete;
        private MetroFramework.Controls.MetroButton btn_Report;
        private MetroFramework.Controls.MetroButton btn_GLeave;
    }
}