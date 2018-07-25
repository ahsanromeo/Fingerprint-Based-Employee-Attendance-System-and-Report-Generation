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
    public partial class ReportQuery : MetroForm
    {
        DataRow[] attendanceData = null;
        string fid = "", name = "", sex = "", address = "", building = "", rank = "", holiday = "";
        DataTable dt = null;
        DataTable rdt = null;
        DateTime dat1; DateTime dat2;
        bool withLeave = false, withHoliday = false;
        public ReportQuery(DataRow[] _dr, string _fid, string _name, string _sex, string _address, string _building, string _rank, string _holiday)
        {
            InitializeComponent();
            if (_dr == null)
                throw new ArgumentNullException();
            attendanceData = _dr;
            fid = _fid;

            name = _name; sex = _sex; address = _address; building = _building; rank = _rank; holiday = _holiday;
        }


        private string queryBuilder()
        {
            dat1 = new DateTime(startDate.Value.Year, startDate.Value.Month, startDate.Value.Day);
            dat2 = new DateTime(endDate.Value.Year, endDate.Value.Month, endDate.Value.Day);
            //MessageBox.Show(dat1.ToLongDateString() + "\n" + dat2.ToLongDateString());
            if (dat1 > dat2)
            {
                //MessageBox.Show("Start Date can't be greater than End Date !!!");
                return "";
            }
            string sDate = "#" + startDate.Value.Month.ToString() + "/" + startDate.Value.Day.ToString() + "/" + startDate.Value.Year.ToString() + "#";
            string eDate = "#" + endDate.Value.Month.ToString() + "/" + endDate.Value.Day.ToString() + "/" + endDate.Value.Year.ToString() + "#";
            string q = "Date >= '" + sDate + "' AND Date <= '" + eDate + "'";
            q += " AND ( Presence_Status = 'Present' OR Presence_Status = 'Absent'";
            if (holicheck.Checked)
            {
                q += " OR Presence_Status = 'Weekly Holiday'";
            }
            if (leaveCheck.Checked)
            {
                q += " OR Presence_Status = 'In Leave'";
            }
            q += " )";
            return q;
        }

        private void DataUpdate()
        {
            try
            {
                string q = queryBuilder();
                if (q == "")
                {
                    dataGrid.Visible = false;
                    label_No_Data.Visible = true;
                    rdt = null;
                    return;
                }
                attendanceData = dt.Select(q);
                if (attendanceData.Length == 0)
                {
                    dataGrid.Visible = false;
                    rdt = null;
                    return;
                }
                rdt = attendanceData.CopyToDataTable();
                dataGrid.DataSource = rdt;
                if(dataGrid.Rows.Count == 0)
                {
                    dataGrid.Visible = false;
                    label_No_Data.Visible = true;
                    rdt = null;
                }
                else
                {
                    dataGrid.Visible = true;
                    label_No_Data.Visible = false;
                }
            }
            catch (Exception ex)
            {
                dataGrid.Visible = false;
                label_No_Data.Visible = true;
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportQuery_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Entry_Time", typeof(string));
            dt.Columns.Add("Late", typeof(string));
            dt.Columns.Add("Exit_Time", typeof(string));
            dt.Columns.Add("Presence_Status", typeof(string));

            for (int i = 0; i < attendanceData.Length; i++)
            {
                DataRow row = dt.NewRow();
                row["Date"] = Convert.ToDateTime(attendanceData[i]["work_date"].ToString());
                row["Entry_Time"] = modifyTime(attendanceData[i]["entry_time"].ToString());
                row["Late"] = NormalizeLate(attendanceData[i]["late_in_seconds"].ToString());
                row["Exit_Time"] = modifyTime(attendanceData[i]["exit_time"].ToString());
                row["Presence_Status"] = attendanceData[i]["presence"].ToString();
                dt.Rows.Add(row);
            }
        }

        private void startDate_CloseUp(object sender, EventArgs e)
        {
            DataUpdate();
        }
        private void endDate_CloseUp(object sender, EventArgs e)
        {
            DataUpdate();
        }
        private void holicheck_CheckedChanged(object sender, EventArgs e)
        {
            withHoliday = holicheck.Checked;
            DataUpdate();
        }
        private void leaveCheck_CheckedChanged(object sender, EventArgs e)
        {
            withLeave = leaveCheck.Checked;
            DataUpdate();
        }
        private void btn_Build_Click(object sender, EventArgs e)
        {
            if (rdt == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "Sorry !\nNo data !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (var rf = new ReportForm(rdt, fid, name, sex, address, building, rank, holiday, dat1, dat2, withHoliday, withLeave))
                {
                    rf.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //using (var wf = new WaitForm(doit, "Building Report..."))
            //{
            //    wf.ShowDialog();
            //}
        }

        private void doit()
        {
            using (var rf = new ReportForm(rdt, fid, name, sex, address, building, rank, holiday, dat1, dat2, withHoliday, withLeave))
            {
                rf.ShowDialog();
            }
        }
        private string NormalizeLate(string s)
        {
            try
            {
                if (s == "N/A")
                    return s;
                int x = Convert.ToInt32(s);
                int h = x / 3600;
                x -= (h * 3600);
                int m = x / 60;
                if (h == 0 && m == 0)
                    return x.ToString() + " Second(s)";
                else if (h > 0 && m == 0)
                    return h.ToString() + " Hour(s)";
                else if (h == 0 && m > 0)
                    return m.ToString() + " Minute(s)";
                else
                    return h.ToString() + " Hour(s), " + m.ToString() + " Minute(s)";
            }
            catch (Exception)
            {
                return "";
            }
        }
        private string modifyTime(string s)
        {
            try
            {
                if (s == "N/A")
                    return s;
                int hour = Convert.ToInt32(s.Substring(0, 2));
                string t = "";
                if (hour <= 12)
                    t += hour.ToString();
                else
                    t += (hour - 12).ToString();
                t += ":" + s.Substring(3, 2);
                t += ":" + s.Substring(6, 2);
                if (hour < 12)
                    t += " AM";
                else
                    t += " PM";
                return t;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
