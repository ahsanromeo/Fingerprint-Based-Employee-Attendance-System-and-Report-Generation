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
    public partial class GrantLeave : MetroForm
    {
        OnlineConnection oc = null;
        string fid;

        public GrantLeave(OnlineConnection _oc, string _id)
        {
            InitializeComponent();
            if (_oc == null || _id.Length == 0)
                throw new ArgumentNullException();
            oc = _oc;
            fid = _id;
        }

        bool done;

        private void btn_Grant_Click(object sender, EventArgs e)
        {
            string s = sDateTime.Value.ToString("dd-MM-yyyy");
            string t = eDateTime.Value.ToString("dd-MM-yyyy");
            DateTime sd = new DateTime(Convert.ToInt32(s.Substring(6, 4)), Convert.ToInt32(s.Substring(3, 2)), Convert.ToInt32(s.Substring(0, 2)));
            DateTime ed = new DateTime(Convert.ToInt32(t.Substring(6, 4)), Convert.ToInt32(t.Substring(3, 2)), Convert.ToInt32(t.Substring(0, 2)));

            if (sd > ed)
            {
                MetroFramework.MetroMessageBox.Show(this, "Start date can't be later than end date !", "STOP !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            done = false;
            //performAction();
            using (var wf = new WaitForm(performAction, "Performing..."))
            {
                wf.ShowDialog();
            }
            if (done)
            {
                MetroFramework.MetroMessageBox.Show(this, "Leave Granted :)", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Couldn't connect\nPlease try again...", "STOP !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void performAction()
        {
            string s = sDateTime.Value.ToString("dd-MM-yyyy");
            string t = eDateTime.Value.ToString("dd-MM-yyyy");
            string q = "INSERT into leaves (uid, building_id, start_date, end_date) VALUES ('" + fid + "', '" + fid.Substring(0, 3) + "', '" + s + "', '" + t + "')";
            //MessageBox.Show(q);
            done = oc.insert(q);
        }
    }
}
