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
    public partial class WeekHolidaysForUsersForm : MetroForm
    {
        private string h = "";
        public WeekHolidaysForUsersForm()
        {
            InitializeComponent();
            h = "56";
            Friday.Checked = Saterday.Checked = true;
        }

        public WeekHolidaysForUsersForm(string _h)
        {
            InitializeComponent();
            h = _h;
            Sunday.Checked = Monday.Checked = Tuesday.Checked = Wednesday.Checked = Tuesday.Checked = Friday.Checked = Saterday.Checked = false;
            for(char i = '0'; i < '7'; ++i)
            {
                if(h != null && h.IndexOf(i) >= 0)
                {
                    if (i == '0')
                        Sunday.Checked = true;
                    else if (i == '1')
                        Monday.Checked = true;
                    else if (i == '2')
                        Tuesday.Checked = true;
                    else if (i == '3')
                        Wednesday.Checked = true;
                    else if (i == '4')
                        Thursday.Checked = true;
                    else if (i == '5')
                        Friday.Checked = true;
                    else
                        Saterday.Checked = true;
                }
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            h = "";
            if (Sunday.Checked)
                h += '0';
            if (Monday.Checked)
                h += '1';
            if (Tuesday.Checked)
                h += '2';
            if (Wednesday.Checked)
                h += '3';
            if (Thursday.Checked)
                h += '4';
            if (Friday.Checked)
                h += '5';
            if (Saterday.Checked)
                h += '6';
            Close();
        }

        public string getHoli()
        {
            return h;
        }
    }
}
