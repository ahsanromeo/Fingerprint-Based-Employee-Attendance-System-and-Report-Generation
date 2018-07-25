using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace FPM
{
    public partial class ReportForm : MetroForm
    {
        DataTable dt = null;
        string fid = "", name = "", sex = "", address = "", building = "", rank = "", holiday = "";
        DateTime dat1; DateTime dat2;
        bool withLeave = false, withHoliday = false;
        public ReportForm(DataTable _dt, string _fid, string _name, string _sex, string _address, string _building, string _rank, string _holiday, DateTime _dat1, DateTime _dat2, bool _withHoli, bool _withLeave)
        {
            InitializeComponent();
            if (_dt == null)
                throw new ArgumentNullException();
            modifyTable(_dt);
            fid = _fid;
            name = _name; sex = _sex; address = _address; building = _building; rank = _rank; holiday = _holiday;
            dat1 = _dat1;
            dat2 = _dat2;
            withLeave = _withLeave;
            withHoliday = _withHoli;
        }

        private void modifyTable(DataTable _dt)
        {
            try
            {
                dt = new DataTable();
                dt.Columns.Add("Work_Date", typeof(string));
                dt.Columns.Add("Entry_Time", typeof(string));
                dt.Columns.Add("Late", typeof(string));
                dt.Columns.Add("Exit_Time", typeof(string));
                dt.Columns.Add("Presence_Status", typeof(string));

                foreach (DataRow row in _dt.Rows)
                {
                    DataRow r = dt.NewRow();

                    r["Work_Date"] = DateTime.Parse(row["Date"].ToString()).ToLongDateString();
                    r["Entry_Time"] = row["Entry_Time"].ToString();
                    r["Late"] = row["Late"].ToString();
                    r["Exit_Time"] = row["Exit_Time"].ToString();
                    r["Presence_Status"] = row["Presence_Status"].ToString();

                    dt.Rows.Add(r);
                }
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }
        }

        private void setParameters()
        {
            ReportDocument.SetParameterValue("pName", name);
            ReportDocument.SetParameterValue("pGender", sex);
            ReportDocument.SetParameterValue("pAddress", address);
            ReportDocument.SetParameterValue("pBuilding", building);
            ReportDocument.SetParameterValue("pRank", rank);
            ReportDocument.SetParameterValue("pHolidays", holiday);
            ReportDocument.SetParameterValue("pStartDate", "From " + dat1.ToLongDateString());
            ReportDocument.SetParameterValue("pEndDate", "to " + dat2.ToLongDateString());
            ReportDocument.SetParameterValue("pIsWeeklyHoliday", withHoliday ? "Weekly Holiday Included" : "Weekly Holiday Excluded");
            ReportDocument.SetParameterValue("pIsInLeave", withLeave ? "Leave Included" : "Leave Excluded");
            ReportDocument.SetParameterValue("pCreated", "Report Creation Date: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());

        }


        private void ReportForm_Load(object sender, EventArgs e)
        {
            ReportDocument.SetDataSource(dt);
            setParameters();
            ReportViewer.ReportSource = ReportDocument;
            ReportViewer.Refresh();
        }
    }
}
