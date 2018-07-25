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
    public partial class EditHolidayForm : MetroForm
    {
        OnlineConnection oc = null;
        int id;
        public EditHolidayForm(OnlineConnection _oc, int _id, string _name, string _start, string _end)
        {
            InitializeComponent();
            if (id < 0 || _oc == null || _name.Length == 0 || _start.Length == 0 || _end.Length == 0)
                throw new ArgumentNullException();
            oc = _oc;
            id = _id;
            name_text.Text = _name;
            sMonthBox.SelectedIndex = Convert.ToInt32(_start.Substring(3)) - 1;
            eMonthBox.SelectedIndex = Convert.ToInt32(_end.Substring(3)) - 1;
            sDateBox.Text = _start.Substring(0, 2);
            eDateBox.Text = _end.Substring(0, 2);
        }

        private string convMonth(string m)
        {
            int i = Convert.ToInt32(m);
            if (i == 1) return "January";
            if (i == 2) return "February";
            if (i == 3) return "March";
            if (i == 4) return "April";
            if (i == 5) return "May";
            if (i == 6) return "June";
            if (i == 7) return "July";
            if (i == 8) return "August";
            if (i == 9) return "September";
            if (i == 10) return "October";
            if (i == 11) return "November";
            return "December";
        }

        bool done = false;
        string ss, ee, q;
        private void btn_Add_Click(object sender, EventArgs e)
        {
       
            DateTime sdt, edt;
            try
            {
                name_text.Text = name_text.Text.Trim();
                if (name_text.Text.Length == 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid Name !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (sMonthBox.Text == "" || sDateBox.Text == "" || eMonthBox.Text == "" || eDateBox.Text == "")
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid Months/Dates !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                sdt = new DateTime(2000, sMonthBox.SelectedIndex + 1, Convert.ToInt32(sDateBox.SelectedItem));
                edt = new DateTime(2000, eMonthBox.SelectedIndex + 1, Convert.ToInt32(eDateBox.SelectedItem));
                if (sdt > edt)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Start date can't be greater than End date !", "STOP !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!oc.hasConnection())
                {
                    MetroFramework.MetroMessageBox.Show(this, "Couldn't connect to internet !!!\nTry agan...", "STOP !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                done = false;
                if (sdt.Day < 10)
                    ss = "0" + sdt.Day.ToString();
                else
                    ss = sdt.Day.ToString();
                ss += "/";
                if (sdt.Month < 10)
                    ss += ("0" + sdt.Month.ToString());
                else
                    ss += sdt.Month.ToString();

                if (edt.Day < 10)
                    ee = "0" + edt.Day.ToString();
                else
                    ee = edt.Day.ToString();
                ee += "/";
                if (edt.Month < 10)
                    ee += ("0" + edt.Month.ToString());
                else
                    ee += edt.Month.ToString();

                //q = "INSERT INTO holidays (holiday_name, start_date, end_date) VALUES ('" + name_text.Text + "', '" + ss + "', '" + ee + "')";
                q = "UPDATE holidays SET holiday_name='" + name_text.Text + "', start_date='" + ss + "', end_date='" + ee + "' WHERE id='" + id.ToString() + "'";
                using (var wf = new WaitForm(performAction, "Updating..."))
                {
                    wf.ShowDialog();
                }

                if (done)
                {
                    //MessageBox.Show("");
                    MetroFramework.MetroMessageBox.Show(this, "Holiday updated successfully :)", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Updating Failed... !!!\nTry agan...", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void performAction()
        {
            done = oc.insert(q);
        }

        private void sMonthBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int en = -1;
            string m = sMonthBox.Text;
            if (m == "January" || m == "March" || m == "May" || m == "July" || m == "August" || m == "October" || m == "December")
            {
                en = 31;
            }
            else if (m == "February")
            {
                en = 29;
            }
            else // April, June, September, November
            {
                en = 30;
            }

            sDateBox.Items.Clear();
            for (int i = 1; i <= en; ++i)
            {
                sDateBox.Items.Add(i.ToString());
            }
        }

        private void eMonthBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int en = -1;
            string m = eMonthBox.Text;
            if (m == "January" || m == "March" || m == "May" || m == "July" || m == "August" || m == "October" || m == "December")
            {
                en = 31;
            }
            else if (m == "February")
            {
                en = 29;
            }
            else // April, June, September, November
            {
                en = 30;
            }

            eDateBox.Items.Clear();
            for (int i = 1; i <= en; ++i)
            {
                eDateBox.Items.Add(i.ToString());
            }
        }

        private void sMonthBox_Click(object sender, EventArgs e)
        {
            sDateBox.Items.Clear();
        }

        private void eMonthBox_Click(object sender, EventArgs e)
        {
            eDateBox.Items.Clear();
        }
    }
}
