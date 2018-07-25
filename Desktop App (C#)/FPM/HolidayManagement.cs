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
    public partial class HolidayManagement : MetroForm
    {
        OnlineConnection oc = null;
        DataTable dt;
        public HolidayManagement(OnlineConnection _oc)
        {
            InitializeComponent();
            if (_oc == null)
                throw new ArgumentNullException();
            oc = _oc;
        }

        private void HolidayManagement_Shown(object sender, EventArgs e)
        {
            LoadHolidays();
        }

        private void LoadHolidays()
        {
            dataGrid.Visible = false;
            dt = null;
            using (var wf = new WaitForm(WaitAndLoad, "Loading..."))
            {
                wf.ShowDialog();
            }
            if(dt == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "Data Loading Failed !", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            dataGrid.DataSource = dt;
            dataGrid.Visible = true;
            dataGrid.AutoResizeColumns();
        }

        private void WaitAndLoad()
        {
            string q = "SELECT * FROM holidays";
            dt = oc.query(q);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddHolidayForm af = new AddHolidayForm(oc);
            af.FormClosed += Af_FormClosed;
            af.ShowDialog();
        }

        private void Af_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (oc.hasConnection())
                LoadHolidays();
            else
                MetroFramework.MetroMessageBox.Show(this, "Couldn't connect to Internet !!!\nTry agan...", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (oc.hasConnection())
                LoadHolidays();
            else
                MetroFramework.MetroMessageBox.Show(this, "Couldn't connect to Internet !!!\nTry agan...", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount < 1)
                return;
            try
            {
                DataGridViewRow row = dataGrid.CurrentRow;
                EditHolidayForm eh = new EditHolidayForm(oc,
                    Convert.ToInt32(row.Cells["id"].Value.ToString()),
                    row.Cells["holiday_name"].Value.ToString(),
                    row.Cells["start_date"].Value.ToString(),
                    row.Cells["end_date"].Value.ToString()
                    );
                eh.ShowDialog();
                LoadHolidays();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool done = false;
        string q;

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount < 1)
                return;
            if(MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to delete this holiday ?", "Warning !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;
            //if (MessageBox.Show("Are you sure you want to delete this holiday ?", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                //return;
            q = "DELETE FROM holidays WHERE id='" + dataGrid.SelectedRows[0].Cells["id"].Value.ToString() + "'";
            done = false;
            using (var wf = new WaitForm(performeDelete, "Deleting..."))
            {
                wf.FormClosed += Wf_FormClosed;
                wf.ShowDialog();
            }
            if(done)
            {
                MetroFramework.MetroMessageBox.Show(this, "The holiday has been deleted", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Couldn't delete...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Wf_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (oc.hasConnection())
                LoadHolidays();
            else
                MetroFramework.MetroMessageBox.Show(this, "Couldn't connect to Internet !!!\nTry agan...", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void performeDelete()
        {
            done = oc.insert(q);
        }
    }
}
