namespace FPM
{
    partial class ReportForm
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
            this.ReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReportDocument = new FPM.CrystalReportClass();
            this.SuspendLayout();
            // 
            // ReportViewer
            // 
            this.ReportViewer.ActiveViewIndex = -1;
            this.ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer.Location = new System.Drawing.Point(20, 60);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.Size = new System.Drawing.Size(729, 448);
            this.ReportViewer.TabIndex = 0;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 528);
            this.Controls.Add(this.ReportViewer);
            this.Name = "ReportForm";
            this.Text = "Report Form";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewer;
        private CrystalReportClass ReportDocument;
    }
}