using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using System.Threading;

namespace FPM
{
    public partial class NewEmployeeForm : MetroForm
    {
        private int fid;
        DeviceConnection dc = null;
        OnlineConnection oc = null;
        bool firstStep;
        string deviceBuilding = "";
        string q = "";
        public NewEmployeeForm(DeviceConnection _dc, string cd)
        {
            InitializeComponent();
            oc = new OnlineConnection();
            if (_dc == null || cd == null || cd.Length == 0)
                throw new ArgumentNullException();
            dc = _dc;
            reset();
            deviceBuilding = cd;
            workingbuildingText.Text = cd;
        }
        private void editControls(bool s)
        {
            metroLabel1.Enabled = s;
            metroLabel2.Enabled = s;
            metroLabel3.Enabled = s;
            metroLabel4.Enabled = s;
            metroLabel5.Enabled = s;
            name_text.Enabled = s;
            address_text.Enabled = s;
            rank_box.Enabled = s;
            workingbuildingText.Enabled = s;
            male_radio.Enabled = s;
            female_radio.Enabled = s;
            other_radio.Enabled = s;
            btn_Send_server.Enabled = s;
            btn_Cancel.Enabled = s;
            holicheck.Enabled = s;

            shiftEnd.Enabled = s;
            shiftStart.Enabled = s;

            q = "";
        }

        private void btn_Enroll_Click(object sender, EventArgs e)
        {
            btn_Enroll.Enabled = false;
            btn_Enroll.Update();
            wait_Label.Visible = true;
            ProgressBar.Value = 0;
            Cursor.Current = Cursors.WaitCursor;
            bool ok = EnrollProcess();
            Cursor.Current = Cursors.Default;
            Application.DoEvents();
            if (!btn_Enroll.IsDisposed)
                btn_Enroll.Enabled = true;
            wait_Label.Visible = false;
            if (fid == -100 || !ok)
            {
                updateLabel("Retry Enrollment Process...");
                reset();
                return;
            }
            editControls(true);
            btn_Enroll.Enabled = false;
            firstStep = true;
            Label_Status.Text = "Got FingerPrint ID: " + fid.ToString() + "\nNow fill in the form below...";
        }

        private bool EnrollProcess()
        {
            bool f = dc.send("ENROLL\n");
            if (!f)
            {
                fid = -100;
                MetroFramework.MetroMessageBox.Show(this, "Couldn't send command to device\nForm is closing...", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }
            updateLabel("Waiting...");
            while (true)
            {
                string ws = dc.wait();
                if (ws.Equals("Time Limit"))
                {
                    fid = -100;
                    MetroFramework.MetroMessageBox.Show(this, "Sorry !!!\nThe device is not responding", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Close();
                    return false;
                }
                else if (ws != "OK")
                {
                    fid = -100;
                    MetroFramework.MetroMessageBox.Show(this, "Exception occured!!!\n" + ws + "\nForm is closing...", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Close();
                    return false;
                }
                string line = dc.get();
                string[] arr = line.Split(' ');
                if (arr.Length <= 1)
                {
                    fid = -100;
                    MetroFramework.MetroMessageBox.Show(this, "Unknown Behaviour !!!", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Close();
                    return false;
                }
                if (arr[0].Equals("Success"))
                {
                    updateLabel("Success: " + arr[1]);
                    fid = Convert.ToInt32(arr[1]);
                    updateLabel(fid.ToString());
                    Refresh();
                    return true;
                }
                else if (arr[0].Equals("ERROR"))
                {
                    updateLabel(arr[1] + " Error\nRetry");
                    Refresh();
                    MetroFramework.MetroMessageBox.Show(this, arr[1] + " Error", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (arr[0].Equals("Failed"))
                {
                    updateLabel("Fingerprint didn't match\nRetry");
                    Refresh();
                    MetroFramework.MetroMessageBox.Show(this, "Fingerprint didn't match", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    updateLabel(line);
                    if(!arr[0].Equals("Waiting") && !arr[0].Equals("Free") && !arr[0].Equals("Remove") && !arr[0].Equals("Place"))
                        ProgressBar.Value += 10;
                }
                Refresh();
            }
        }

        bool sf;
        private void btn_Send_server_Click(object sender, EventArgs e)
        {
            if (!isValid())
                return;
            if(!oc.hasConnection())
            {
                MetroFramework.MetroMessageBox.Show(this, "No Internet Connection :(", "STOP !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sf = false;

            string sex = male_radio.Checked ? "Male" : female_radio.Checked ? "Female" : "Other";
            string ff = fid.ToString();
            if (fid < 10)
                ff = "00" + ff;
            else if (fid < 100)
                ff = "0" + ff;
            q = "INSERT INTO employee (name, sex, address, building, building_id, rank, fid, holiday, shift_start, shift_end) VALUES ('" + name_text.Text + "', '" + sex + "', '" + address_text.Text + "', '" + workingbuildingText.Text + "', '" + workingbuildingText.Text.Substring(0, 3) + "', '" + rank_box.Text + "', '" + deviceBuilding.Substring(0, 3) + ff + "', '" + holis + "', '" + shiftStart.Text + "', '" + shiftEnd.Text + "')";

            using (WaitForm wf = new WaitForm(waitAndSend, "Registering..."))
            {
                wf.ShowDialog();
            }
            if (!sf)
            {
                MetroFramework.MetroMessageBox.Show(this, "Sending Failed :(", "STOP !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroFramework.MetroMessageBox.Show(this, "Saved successfully :)", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
        }

        private void waitAndSend()
        {
            sf = oc.insert(q);
        }

        private bool isValid()
        {
            name_text.Text = name_text.Text.Trim();
            if (name_text.Text == null || name_text.Text.Length == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid name !", "SORRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(male_radio.Checked == false && female_radio.Checked == false && other_radio.Checked == false)
            {
                MetroFramework.MetroMessageBox.Show(this, "Select gender please...", "SORRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            address_text.Text = address_text.Text.Trim();
            if (address_text.Text == null || address_text.Text.Length == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Address !", "SORRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (workingbuildingText.Text == null || workingbuildingText.Text.Length < 3)
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Building Name", "SORRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            rank_box.Text = rank_box.Text.Trim();
            if (rank_box.Text == null || rank_box.Text.Length == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Rank/Position", "SORRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            shiftStart.Text = shiftStart.Text.Trim();
            if(shiftStart.Text == null || shiftStart.Text.Length == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Select shift start time please", "SORRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            shiftEnd.Text = shiftEnd.Text.Trim();
            if (shiftEnd.Text == null || shiftEnd.Text.Length == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Select shift end time please", "SORRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void reset()
        {
            editControls(false);
            btn_Enroll.Enabled = true;
            wait_Label.Visible = false;
            fid = -100;
            firstStep = false;
            ProgressBar.Value = 0;
            Label_Status.Text = "";

            name_text.Text = address_text.Text = rank_box.Text = "";
            male_radio.Checked = female_radio.Checked = other_radio.Checked = false;

            shiftStart.Text = shiftEnd.Text = "";

            holis = "56";
            holicheck.Checked = true;
        }

        private void updateLabel(string s)
        {
            Label_Status.Text = s;
        }

        private void NewEmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (firstStep && fid != -100)
            {
                if (dc.deleteRequest(fid))
                {
                    string w = dc.wait();
                    if(w != "OK")
                    {
                        MetroFramework.MetroMessageBox.Show(this, "ERROR\n" + w, "SORRY !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MetroFramework.MetroMessageBox.Show(this, dc.get(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string holis = "56";

        private void holicheck_CheckedChanged(object sender, EventArgs e)
        {
            if(holicheck.Checked)
            {
                holis = "56";
                holicheck.Text = "Default Weekly Holidays ( Friday and Saterday )";
            }
            else
            {
                using (WeekHolidaysForUsersForm wf = new WeekHolidaysForUsersForm())
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
