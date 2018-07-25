using MetroFramework.Forms;
using System.Windows.Forms;
using System;

namespace FPM
{
    public partial class Main : MetroForm
    {
        bool hasDevice;
        DeviceConnection dc = null;
        OnlineConnection oc = null;
        string deviceBuilding = "";
        public Main()
        {
            InitializeComponent();
            hasDevice = false;
            Connect.Enabled = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            hasDevice = false;
            dc = new DeviceConnection();
            oc = new OnlineConnection();

            port_box.Items.Clear();
            string[] ports = dc.getAvailablePorts();
            if (ports == null || ports.Length == 0)
            {
                port_box.Enabled = false;
                port_label.Enabled = false;
                Connect.Enabled = false;

                //MetroFramework.MetroMessageBox.Show(this, "No COM port found\nApplication is exiting...", "STOP !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Exit();
            }
            else
            {
                foreach (string p in ports)
                {
                    port_box.Items.Add(p);
                }
                port_box.SelectedItem = ports[0];
                Connect.Enabled = true;
            }

            //device_dashboard.Enabled = false;
            tabs.SelectedTab = device_connection;
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            
            if (hasDevice)
            {
                dc.disconnect();
                hasDevice = false;
                deviceBuilding = "";
                Connect.Text = "Connect";
                connection_label.Text = "         No Device Connected";
                port_box.Enabled = true;
                //device_dashboard.Enabled = false;
            }
            else
            {
                if (dc.connect(port_box.GetItemText(port_box.SelectedItem)))
                {
                    string w = dc.wait();
                    if(w != "OK")
                    {
                        MetroFramework.MetroMessageBox.Show(this, w, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    deviceBuilding = dc.get();
                    hasDevice = true;
                    Connect.Text = "Disonnect";
                    port_box.Enabled = false;
                    //btn_time.Enabled = btn_empty_database.Enabled = btn_add_new_employee.Enabled = true;
                    device_dashboard.Enabled = true;
                    connection_label.Text = deviceBuilding + " device is now connected at " + port_box.GetItemText(port_box.SelectedItem);
                }
                else
                {
                    hasDevice = false;
                    deviceBuilding = "";
                    port_box.Enabled = true;
                    Connect.Text = "Connect";
                    connection_label.Text = "           No Device Connected";
                    device_dashboard.Enabled = false;
                }
            }
        }
        public static void dbg(dynamic x)
        {
            MessageBox.Show(Convert.ToString(x));
        }

        private bool checkDevice()
        {
            if(deviceBuilding == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "ERROR !\nNo supported device found !!!", "STOP !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btn_time_Click(object sender, EventArgs e)
        {
            if (!checkDevice())
                return;
            DateTime dt = DateTime.Now;
            string t = "SETTIME ";
            if (dt.Day < 10)
                t += "0";
            t += dt.Day;
            if (dt.Month < 10)
                t += "0";
            t += dt.Month;
            t += dt.Year;
            if (dt.Hour < 10)
                t += "0";
            t += dt.Hour;
            if (dt.Minute < 10)
                t += "0";
            t += dt.Minute;
            if (dt.Second < 10)
                t += "0";
            t += dt.Second;
            t += "\n";
            if(!dc.send(t))
            {
                MetroFramework.MetroMessageBox.Show(this, "Error\nDevice may not be connected", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string w = dc.wait();
                if (w != "OK")
                {
                    MetroFramework.MetroMessageBox.Show(this, "Error\n" + w, "STOP !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        t = dc.get();
                        //MessageBox.Show(t);
                        string[] arr = t.Split('_');
                        int dif = 1000;
                        try
                        {
                            dif = Convert.ToInt32(Math.Floor(Math.Abs(new DateTime(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]), Convert.ToInt32(arr[2]), Convert.ToInt32(arr[3]), Convert.ToInt32(arr[4]), Convert.ToInt32(arr[5])).Subtract(dt).TotalSeconds)));
                        }
                        catch(Exception ex)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Time Set Error", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MetroFramework.MetroMessageBox.Show(this, ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (dif <= 5)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Time set and checked successfully on the device", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Error !!!\nDevice took too long to respond", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch(Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            dc.disconnect();
        }

        private void btn_empty_database_Click(object sender, EventArgs e)
        {
            if (!checkDevice())
                return;
            if (MetroFramework.MetroMessageBox.Show(this, "You are about to clear the entire database\nAre you sure you want to proceed ?", "Warning !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if(!oc.hasConnection())
                {
                    MetroFramework.MetroMessageBox.Show(this, "Error\nNo Internet Connection !!!", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string ds = deviceBuilding.Substring(0, 3);
                string q1 = "DELETE FROM employee WHERE building_id='" + ds + "'";
                string q2 = "DELETE FROM attendance WHERE building_id='" + ds + "'";
                string q3 = "DELETE FROM leaves WHERE building_id='" + ds + "'";
                if (!oc.insert(q1) || !oc.insert(q2) || !oc.insert(q3))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Error\nCouldn't empty online database !!!\nMay be it's partially hampered.\nTry agan...", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(!dc.send("EMPTY\n"))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Error\nDevice may not be connected", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string w = dc.wait();
                if(w != "OK")
                {
                    MetroFramework.MetroMessageBox.Show(this, "Error\n" + w, "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string t = dc.get();
                if (t.Equals("Success"))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Success !!!\nDatabase Cleared", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Error\n" + t, "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_add_new_employee_Click(object sender, EventArgs e)
        {
            if (!checkDevice())
                return;
            using (var nf = new NewEmployeeForm(dc, deviceBuilding))
            {
                nf.ShowDialog();
            }
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            if(oc.hasConnection())
            {
                using (var em = new Employees(oc, deviceBuilding, dc))
                {
                    em.ShowDialog();
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Error\nNo Internet Connection !!!", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Manage_Holidays_Click(object sender, EventArgs e)
        {
            if(oc.hasConnection())
            {
                using (var hm = new HolidayManagement(oc))
                {
                    hm.ShowDialog();
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "No Internet Connection", "STOP !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btn_CheckTime_Click(object sender, EventArgs e)
        {
            if (!checkDevice())
                return;
            if (!dc.send("CHECK_TIME\n"))
            {
                MetroFramework.MetroMessageBox.Show(this, "Error\nDevice may not be connected", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string w = dc.wait();
            if(w != "OK")
            {
                MetroFramework.MetroMessageBox.Show(this, "Error\n" + w, "STOP !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MetroFramework.MetroMessageBox.Show(this, "Device time is: " + dc.get(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Dev_Info_Click(object sender, EventArgs e)
        {
            if (!checkDevice())
                return;
            if(!dc.send("info\n"))
            {
                MetroFramework.MetroMessageBox.Show(this, "Couldn't send command !", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string w = dc.wait();
            if(w != "OK")
            {
                MetroFramework.MetroMessageBox.Show(this, w, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string t = dc.get();
            string[] arr = t.Split('_');
            if(arr.Length != 3)
            {
                MetroFramework.MetroMessageBox.Show(this, "Wrong response from device !", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string m = "Device Name: " + arr[0] + "\n";
                m += "Device Capacity: " + arr[1] + " Fingers.\n";
                m += "Number of stored fingers: " + arr[2] + ".\n";
                int fn = Convert.ToInt32(arr[1]) - Convert.ToInt32(arr[2]);
                m += "Number of free space for new finger: " + fn.ToString();
                MetroFramework.MetroMessageBox.Show(this, m, "Device Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void connection_label_Click(object sender, EventArgs e)
        {

        }
    }
}
