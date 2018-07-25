namespace FPM
{
    partial class Main
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
            this.tabs = new MetroFramework.Controls.MetroTabControl();
            this.device_connection = new MetroFramework.Controls.MetroTabPage();
            this.connection_label = new MetroFramework.Controls.MetroLabel();
            this.port_label = new MetroFramework.Controls.MetroLabel();
            this.port_box = new MetroFramework.Controls.MetroComboBox();
            this.Connect = new MetroFramework.Controls.MetroButton();
            this.device_dashboard = new MetroFramework.Controls.MetroTabPage();
            this.btn_Dev_Info = new MetroFramework.Controls.MetroButton();
            this.btn_CheckTime = new MetroFramework.Controls.MetroButton();
            this.btn_Manage_Holidays = new MetroFramework.Controls.MetroButton();
            this.btn_ShowAll = new MetroFramework.Controls.MetroButton();
            this.btn_add_new_employee = new MetroFramework.Controls.MetroButton();
            this.btn_empty_database = new MetroFramework.Controls.MetroButton();
            this.btn_time = new MetroFramework.Controls.MetroButton();
            this.tabs.SuspendLayout();
            this.device_connection.SuspendLayout();
            this.device_dashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.device_connection);
            this.tabs.Controls.Add(this.device_dashboard);
            this.tabs.Location = new System.Drawing.Point(160, 102);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 1;
            this.tabs.Size = new System.Drawing.Size(432, 356);
            this.tabs.TabIndex = 1;
            this.tabs.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabs.UseSelectable = true;
            // 
            // device_connection
            // 
            this.device_connection.Controls.Add(this.connection_label);
            this.device_connection.Controls.Add(this.port_label);
            this.device_connection.Controls.Add(this.port_box);
            this.device_connection.Controls.Add(this.Connect);
            this.device_connection.HorizontalScrollbarBarColor = true;
            this.device_connection.HorizontalScrollbarHighlightOnWheel = false;
            this.device_connection.HorizontalScrollbarSize = 10;
            this.device_connection.Location = new System.Drawing.Point(4, 38);
            this.device_connection.Name = "device_connection";
            this.device_connection.Size = new System.Drawing.Size(424, 314);
            this.device_connection.TabIndex = 0;
            this.device_connection.Text = "Device Connection";
            this.device_connection.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.device_connection.VerticalScrollbarBarColor = true;
            this.device_connection.VerticalScrollbarHighlightOnWheel = false;
            this.device_connection.VerticalScrollbarSize = 10;
            // 
            // connection_label
            // 
            this.connection_label.Location = new System.Drawing.Point(-4, 180);
            this.connection_label.Name = "connection_label";
            this.connection_label.Size = new System.Drawing.Size(425, 19);
            this.connection_label.TabIndex = 10;
            this.connection_label.Text = "No Device Connected";
            this.connection_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.connection_label.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.connection_label.Click += new System.EventHandler(this.connection_label_Click);
            // 
            // port_label
            // 
            this.port_label.AutoSize = true;
            this.port_label.Enabled = false;
            this.port_label.Location = new System.Drawing.Point(3, 44);
            this.port_label.Name = "port_label";
            this.port_label.Size = new System.Drawing.Size(188, 19);
            this.port_label.TabIndex = 9;
            this.port_label.Text = "Select COM port of the device";
            this.port_label.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // port_box
            // 
            this.port_box.FormattingEnabled = true;
            this.port_box.ItemHeight = 23;
            this.port_box.Location = new System.Drawing.Point(289, 39);
            this.port_box.Name = "port_box";
            this.port_box.Size = new System.Drawing.Size(121, 29);
            this.port_box.TabIndex = 8;
            this.port_box.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.port_box.UseSelectable = true;
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(-4, 103);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(428, 40);
            this.Connect.TabIndex = 7;
            this.Connect.Text = "Connect";
            this.Connect.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Connect.UseSelectable = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // device_dashboard
            // 
            this.device_dashboard.Controls.Add(this.btn_Dev_Info);
            this.device_dashboard.Controls.Add(this.btn_CheckTime);
            this.device_dashboard.Controls.Add(this.btn_Manage_Holidays);
            this.device_dashboard.Controls.Add(this.btn_ShowAll);
            this.device_dashboard.Controls.Add(this.btn_add_new_employee);
            this.device_dashboard.Controls.Add(this.btn_empty_database);
            this.device_dashboard.Controls.Add(this.btn_time);
            this.device_dashboard.HorizontalScrollbarBarColor = true;
            this.device_dashboard.HorizontalScrollbarHighlightOnWheel = false;
            this.device_dashboard.HorizontalScrollbarSize = 10;
            this.device_dashboard.Location = new System.Drawing.Point(4, 38);
            this.device_dashboard.Name = "device_dashboard";
            this.device_dashboard.Size = new System.Drawing.Size(424, 314);
            this.device_dashboard.TabIndex = 1;
            this.device_dashboard.Text = "Dashboard";
            this.device_dashboard.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.device_dashboard.VerticalScrollbarBarColor = true;
            this.device_dashboard.VerticalScrollbarHighlightOnWheel = false;
            this.device_dashboard.VerticalScrollbarSize = 10;
            // 
            // btn_Dev_Info
            // 
            this.btn_Dev_Info.Location = new System.Drawing.Point(4, 16);
            this.btn_Dev_Info.Name = "btn_Dev_Info";
            this.btn_Dev_Info.Size = new System.Drawing.Size(420, 26);
            this.btn_Dev_Info.TabIndex = 8;
            this.btn_Dev_Info.Text = "Device Information";
            this.btn_Dev_Info.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_Dev_Info.UseSelectable = true;
            this.btn_Dev_Info.Click += new System.EventHandler(this.btn_Dev_Info_Click);
            // 
            // btn_CheckTime
            // 
            this.btn_CheckTime.Location = new System.Drawing.Point(4, 56);
            this.btn_CheckTime.Name = "btn_CheckTime";
            this.btn_CheckTime.Size = new System.Drawing.Size(421, 23);
            this.btn_CheckTime.TabIndex = 7;
            this.btn_CheckTime.Text = "Check Time";
            this.btn_CheckTime.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_CheckTime.UseSelectable = true;
            this.btn_CheckTime.Click += new System.EventHandler(this.btn_CheckTime_Click);
            // 
            // btn_Manage_Holidays
            // 
            this.btn_Manage_Holidays.Location = new System.Drawing.Point(4, 254);
            this.btn_Manage_Holidays.Name = "btn_Manage_Holidays";
            this.btn_Manage_Holidays.Size = new System.Drawing.Size(420, 25);
            this.btn_Manage_Holidays.TabIndex = 6;
            this.btn_Manage_Holidays.Text = "Manage Holidays";
            this.btn_Manage_Holidays.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_Manage_Holidays.UseSelectable = true;
            this.btn_Manage_Holidays.Click += new System.EventHandler(this.btn_Manage_Holidays_Click);
            // 
            // btn_ShowAll
            // 
            this.btn_ShowAll.Location = new System.Drawing.Point(4, 173);
            this.btn_ShowAll.Name = "btn_ShowAll";
            this.btn_ShowAll.Size = new System.Drawing.Size(420, 25);
            this.btn_ShowAll.TabIndex = 5;
            this.btn_ShowAll.Text = "Show Employees";
            this.btn_ShowAll.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_ShowAll.UseSelectable = true;
            this.btn_ShowAll.Click += new System.EventHandler(this.btn_ShowAll_Click);
            // 
            // btn_add_new_employee
            // 
            this.btn_add_new_employee.Location = new System.Drawing.Point(4, 133);
            this.btn_add_new_employee.Name = "btn_add_new_employee";
            this.btn_add_new_employee.Size = new System.Drawing.Size(420, 24);
            this.btn_add_new_employee.TabIndex = 4;
            this.btn_add_new_employee.Text = "Add New Employee";
            this.btn_add_new_employee.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_add_new_employee.UseSelectable = true;
            this.btn_add_new_employee.Click += new System.EventHandler(this.btn_add_new_employee_Click);
            // 
            // btn_empty_database
            // 
            this.btn_empty_database.Location = new System.Drawing.Point(3, 214);
            this.btn_empty_database.Name = "btn_empty_database";
            this.btn_empty_database.Size = new System.Drawing.Size(421, 24);
            this.btn_empty_database.TabIndex = 3;
            this.btn_empty_database.Text = "Empty Database";
            this.btn_empty_database.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_empty_database.UseSelectable = true;
            this.btn_empty_database.Click += new System.EventHandler(this.btn_empty_database_Click);
            // 
            // btn_time
            // 
            this.btn_time.Location = new System.Drawing.Point(3, 94);
            this.btn_time.Name = "btn_time";
            this.btn_time.Size = new System.Drawing.Size(421, 24);
            this.btn_time.TabIndex = 2;
            this.btn_time.Text = "Adjust Device Time";
            this.btn_time.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_time.UseSelectable = true;
            this.btn_time.Click += new System.EventHandler(this.btn_time_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 492);
            this.Controls.Add(this.tabs);
            this.Name = "Main";
            this.Resizable = false;
            this.Text = "FingerPrint Based Employee Attendace System for Khulna University";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabs.ResumeLayout(false);
            this.device_connection.ResumeLayout(false);
            this.device_connection.PerformLayout();
            this.device_dashboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tabs;
        private MetroFramework.Controls.MetroTabPage device_connection;
        private MetroFramework.Controls.MetroLabel connection_label;
        private MetroFramework.Controls.MetroLabel port_label;
        private MetroFramework.Controls.MetroComboBox port_box;
        private MetroFramework.Controls.MetroButton Connect;
        private MetroFramework.Controls.MetroTabPage device_dashboard;
        private MetroFramework.Controls.MetroButton btn_add_new_employee;
        private MetroFramework.Controls.MetroButton btn_empty_database;
        private MetroFramework.Controls.MetroButton btn_time;
        private MetroFramework.Controls.MetroButton btn_ShowAll;
        private MetroFramework.Controls.MetroButton btn_Manage_Holidays;
        private MetroFramework.Controls.MetroButton btn_CheckTime;
        private MetroFramework.Controls.MetroButton btn_Dev_Info;
    }
}

