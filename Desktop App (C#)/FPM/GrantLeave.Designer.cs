namespace FPM
{
    partial class GrantLeave
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
            this.sDateTime = new MetroFramework.Controls.MetroDateTime();
            this.eDateTime = new MetroFramework.Controls.MetroDateTime();
            this.Label_Start = new MetroFramework.Controls.MetroLabel();
            this.Label_End = new MetroFramework.Controls.MetroLabel();
            this.btn_Grant = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // sDateTime
            // 
            this.sDateTime.Location = new System.Drawing.Point(58, 103);
            this.sDateTime.MinimumSize = new System.Drawing.Size(0, 29);
            this.sDateTime.Name = "sDateTime";
            this.sDateTime.Size = new System.Drawing.Size(200, 29);
            this.sDateTime.TabIndex = 0;
            this.sDateTime.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // eDateTime
            // 
            this.eDateTime.Location = new System.Drawing.Point(58, 177);
            this.eDateTime.MinimumSize = new System.Drawing.Size(0, 29);
            this.eDateTime.Name = "eDateTime";
            this.eDateTime.Size = new System.Drawing.Size(200, 29);
            this.eDateTime.TabIndex = 1;
            this.eDateTime.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Label_Start
            // 
            this.Label_Start.AutoSize = true;
            this.Label_Start.Location = new System.Drawing.Point(55, 81);
            this.Label_Start.Name = "Label_Start";
            this.Label_Start.Size = new System.Drawing.Size(106, 19);
            this.Label_Start.TabIndex = 2;
            this.Label_Start.Text = "Select Start Date";
            this.Label_Start.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Label_End
            // 
            this.Label_End.AutoSize = true;
            this.Label_End.Location = new System.Drawing.Point(55, 155);
            this.Label_End.Name = "Label_End";
            this.Label_End.Size = new System.Drawing.Size(100, 19);
            this.Label_End.TabIndex = 3;
            this.Label_End.Text = "Select End Date";
            this.Label_End.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btn_Grant
            // 
            this.btn_Grant.Location = new System.Drawing.Point(58, 241);
            this.btn_Grant.Name = "btn_Grant";
            this.btn_Grant.Size = new System.Drawing.Size(200, 36);
            this.btn_Grant.TabIndex = 4;
            this.btn_Grant.Text = "Grant";
            this.btn_Grant.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_Grant.UseSelectable = true;
            this.btn_Grant.Click += new System.EventHandler(this.btn_Grant_Click);
            // 
            // GrantLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 346);
            this.Controls.Add(this.btn_Grant);
            this.Controls.Add(this.Label_End);
            this.Controls.Add(this.Label_Start);
            this.Controls.Add(this.eDateTime);
            this.Controls.Add(this.sDateTime);
            this.Name = "GrantLeave";
            this.Resizable = false;
            this.Text = "Grant Leave";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroDateTime sDateTime;
        private MetroFramework.Controls.MetroDateTime eDateTime;
        private MetroFramework.Controls.MetroLabel Label_Start;
        private MetroFramework.Controls.MetroLabel Label_End;
        private MetroFramework.Controls.MetroButton btn_Grant;
    }
}