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
    public partial class Employees : MetroForm
    {
        OnlineConnection oc = null;
        string deviceBuilding = "";
        DeviceConnection dc = null;
        DataTable dt = null;
        public static int v = -1;

        DataTable attendanceTable = null;

        public Employees(OnlineConnection _oc, string _db, DeviceConnection _dc)
        {
            InitializeComponent();
            if (_dc == null || _oc == null)
                throw new ArgumentNullException();
            oc = _oc;
            dc = _dc;
            deviceBuilding = _db;
            Label_Wait.Visible = true;
            dataGrid.Visible = false;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGrid.AutoSize = true;
            dataGrid.MultiSelect = false;

        }

        private void Employees_Shown(object sender, EventArgs e)
        {
            LoadData();
            if(dt == null || attendanceTable == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "Loading Data Failed !!!", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }
        }

        List<string> holis = new List<string>();
        private void LoadData()
        {
            try
            {
                Label_Wait.Visible = true;
                dataGrid.Visible = false;

                using (WaitForm wf = new WaitForm(waitAndLoad))
                {
                    wf.ShowDialog();
                }
                dataGrid.DataSource = dt;
                extractHolidays();
                dataGrid.AutoResizeColumns();
                dataGrid.AutoResizeColumn(4);
                Label_Wait.Visible = false;
                dataGrid.Visible = true;
                dataGrid.Columns["id"].Visible = false;
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
            }
        }

        private void extractHolidays()
        {
            holis.Clear();
            int cnt = dataGrid.RowCount;
            for(int i = 0; i < cnt; ++i)
            {
                string ph = dataGrid.Rows[i].Cells["holiday"].Value.ToString();
                holis.Add(ph);
                string h = "";
                for(int j = 0; j < ph.Length; ++j)
                {
                    if (j > 0)
                        h += ", ";
                    if(ph[j] == '0')
                    {
                        h += "Sunday";
                    }
                    else if(ph[j] == '1')
                    {
                        h += "Monday";
                    }
                    else if (ph[j] == '2')
                    {
                        h += "Tuesday";
                    }
                    else if (ph[j] == '3')
                    {
                        h += "Wednesday";
                    }
                    else if (ph[j] == '4')
                    {
                        h += "Thursday";
                    }
                    else if (ph[j] == '5')
                    {
                        h += "Friday";
                    }
                    else
                    {
                        h += "Saterday";
                    }
                }
                dataGrid.Rows[i].Cells["holiday"].Value = h;
            }
        }

        private void waitAndLoad()
        {
            string q = "";
            if (deviceBuilding == "")
                q = "SELECT * FROM employee";
            else
                q = "SELECT * FROM employee WHERE building_id='" + deviceBuilding.Substring(0, 3) + "'";
            dt = oc.query(q);
            attendanceTable = oc.query("SELECT * FROM attendance ORDER BY work_date");
            //MessageBox.Show("Query: " + q);
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount < 1)
                return;
            try
            {
                DataGridViewRow row = dataGrid.CurrentRow;
                UpdateUserForm uf = new UpdateUserForm(
                    oc, Convert.ToInt32(row.Cells["id"].Value), row.Cells["name"].Value.ToString(),
                    row.Cells["sex"].Value.ToString(), row.Cells["address"].Value.ToString(),
                    row.Cells["rank"].Value.ToString(),
                    row.Cells["shift_start"].Value.ToString(), row.Cells["shift_end"].Value.ToString(),
                    holis[dataGrid.CurrentRow.Index]
                    );
                v = -1;
                uf.ShowDialog();
                if (v == 1)
                {
                    LoadData();
                }
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message + "\nYou may not have selected any item...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        int df;

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if(deviceBuilding == "")
            {
                //MessageBox.Show("No supported device found");
                MetroFramework.MetroMessageBox.Show(this, "No supported device found", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGrid.RowCount < 1)
                return;
            if(MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to delete this employee?", "WARNING !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            df = 0;
            using (WaitForm wf = new WaitForm(performDelete, "Deleting..."))
            {
                wf.ShowDialog();
            }
            if(df == 2)
            {
                MetroFramework.MetroMessageBox.Show(this, "Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else if(df == 1)
            {
                MetroFramework.MetroMessageBox.Show(this, "Couldn't delete from device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Couldn't delete !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void performDelete()
        {
            DataGridViewRow row = dataGrid.CurrentRow;
            string q = "DELETE FROM employee WHERE id='" + row.Cells["id"].Value.ToString() + "'";
            if(oc.insert(q))
            {
                df++;
            }
            else
            {
                df = 0;
                return;
            }
            dc.deleteRequest(Convert.ToInt32(row.Cells["fid"].Value.ToString().Substring(3)));
            dc.wait();
            if(dc.get() == "Deleted!")
            {
                df++;
            }
        }

        private void btn_GLeave_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount < 1)
            {
                MetroFramework.MetroMessageBox.Show(this, "No employee found...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (GrantLeave gl = new GrantLeave(oc, dataGrid.CurrentRow.Cells["fid"].Value.ToString()))
                {
                    gl.ShowDialog();
                }
            }
            catch(Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "No employee selected... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btn_Report_Click(object sender, EventArgs e)
        //{
        //    string fid = dataGrid.CurrentRow.Cells["fid"].Value.ToString();
        //    string name = dataGrid.CurrentRow.Cells["name"].Value.ToString();
        //    string sex = dataGrid.CurrentRow.Cells["sex"].Value.ToString();
        //    string address = dataGrid.CurrentRow.Cells["address"].Value.ToString();
        //    string building = dataGrid.CurrentRow.Cells["building"].Value.ToString();
        //    string rank = dataGrid.CurrentRow.Cells["rank"].Value.ToString();
        //    string holiday = dataGrid.CurrentRow.Cells["holiday"].Value.ToString();

        //    string q = "SELECT * FROM attendance WHERE user_id='" + fid + "'";

        //    DataTable dt = null;
        //    try
        //    {
        //        dt = oc.query(q);
        //    }
        //    catch(Exception)
        //    {
        //        dt = null;
        //        return;
        //    }
        //    if (dt == null)
        //        return;
            
        //    ReportForm rf = new ReportForm(dt, fid, name, sex, address, building, rank, holiday);
        //    rf.ShowDialog();
        //}

        private void btn_Report_Click(object sender, EventArgs e)
        {
            try
            {
  
                string fid = dataGrid.SelectedRows[0].Cells["fid"].Value.ToString();
                string name = dataGrid.SelectedRows[0].Cells["name"].Value.ToString();
                string sex = dataGrid.SelectedRows[0].Cells["sex"].Value.ToString();
                string address = dataGrid.SelectedRows[0].Cells["address"].Value.ToString();
                string building = dataGrid.SelectedRows[0].Cells["building"].Value.ToString();
                string rank = dataGrid.SelectedRows[0].Cells["rank"].Value.ToString();
                string holiday = dataGrid.SelectedRows[0].Cells["holiday"].Value.ToString();
                //ReportQuery rf = new ReportQuery(attendanceTable.Select("user_id = '" + fid + "'"), fid);
                ReportQuery rf = new ReportQuery(attendanceTable.Select("user_id = '" + fid + "'"), fid, name, sex, address, building, rank, holiday);
                rf.ShowDialog();
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
