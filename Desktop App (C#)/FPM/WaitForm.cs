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
    public partial class WaitForm : MetroForm
    {
        public Action worker;
        public WaitForm(Action _)
        {
            InitializeComponent();
            if (_ == null)
                throw new ArgumentNullException();
            worker = _;
        }

        public WaitForm(Action _, string _m)
        {
            InitializeComponent();
            if (_ == null || _m.Length == 0)
                throw new ArgumentNullException();
            worker = _;
            Text = _m;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
