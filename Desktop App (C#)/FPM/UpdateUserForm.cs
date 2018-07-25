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
    public partial class UpdateUserForm : MetroForm
    {
        OnlineConnection oc = null;
        int id;
        private string holis = "56";

        bool isInit = true;

        public UpdateUserForm()
        {
            InitializeComponent();
        }
        public UpdateUserForm(OnlineConnection _oc, int _id, string _name, string _sex, string _address, string _rank, string _s, string _e, string _h)
        {
            InitializeComponent();
            if (_oc == null || id < 0)
                throw new ArgumentNullException();
            oc = _oc;
            id = _id;
            name_text.Text = _name;
            address_text.Text = _address;
            rank_text.Text = _rank;
            if (_sex == "Male")
                Male_Radio.Checked = true;
            else if (_sex == "Female")
                Female_Radio.Checked = true;
            else
                Other_Radio.Checked = true;
            shiftStart.Text = _s;
            shiftEnd.Text = _e;

            holis = _h;

            if (holis == "56")
            {
                holicheck.Checked = true;
                holicheck.Text = "Default Weekly Holidays ( Friday and Saterday )";
            }
            else
            {
                holicheck.Checked = false;
                holicheck.Text = "Custom weekly holidays selected";
            }

            isInit = false;
        }

        bool sf = false;

        string q = "";

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (!isValid())
                return;
            if (!oc.hasConnection())
            {
                MetroFramework.MetroMessageBox.Show(this, "No Internet Connection !!!", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sex = Male_Radio.Checked ? "Male" : Female_Radio.Checked ? "Female" : "Other";
            q = "UPDATE employee SET name='" + name_text.Text + "', sex='" + sex + "', address='" + address_text.Text + "', rank='" + rank_text.Text + "', holiday='" + holis + "', shift_start='" + shiftStart.Text + "', shift_end='" + shiftEnd.Text +  "' WHERE id='" + id.ToString() + "'";

            sf = false;

            using (WaitForm wf = new WaitForm(waitAndUpadate, "Updating..."))
            {
                wf.ShowDialog();
            }
            if(sf)
            {
                Employees.v = 1;
                MetroFramework.MetroMessageBox.Show(this, "Successfully Updated", "SUCCESS !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                Employees.v = -1;
                MetroFramework.MetroMessageBox.Show(this, "Update Failed", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void waitAndUpadate()
        {
            sf = oc.insert(q);
        }

        private bool isValid()
        {
            name_text.Text = name_text.Text.Trim();
            if(name_text.Text.Length == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Name", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Male_Radio.Checked && !Female_Radio.Checked && !Other_Radio.Checked)
            {
                MetroFramework.MetroMessageBox.Show(this, "Select Sex", "Sorry !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            address_text.Text = address_text.Text.Trim();
            if (address_text.Text.Length == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Address", "Sorry !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            rank_text.Text = rank_text.Text.Trim();
            if (rank_text.Text.Length == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Rank", "Sorry !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            shiftStart.Text = shiftStart.Text.Trim();
            if (shiftStart.Text == null || shiftStart.Text.Length == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Select shift start time please...", "Sorry !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            shiftEnd.Text = shiftEnd.Text.Trim();
            if (shiftEnd.Text == null || shiftEnd.Text.Length == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Select shift end time please...", "Sorry !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        
        private void holicheck_CheckedChanged(object sender, EventArgs e)
        {
            if (isInit)
                return;
            if (holicheck.Checked)
            {
                holis = "56";
                holicheck.Text = "Default Weekly Holidays ( Friday and Saterday )";
            }
            else
            {
                using (WeekHolidaysForUsersForm wf = new WeekHolidaysForUsersForm(holis))
                {
                    wf.ShowDialog();
                    holis = wf.getHoli();
                    if (holis == "56")
                    {
                        holicheck.Checked = true;
                        holicheck.Text = "Default Weekly Holidays ( Friday and Saterday )";
                    }
                    else
                    {
                        holicheck.Text = "Custom weekly holidays selected";
                    }
                    wf.Dispose();
                }
            }
        }
    }
}
