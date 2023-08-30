using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Claysys_WinFormsApp
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }
        int i;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i <= 100)
            {
                progressBar1.Value = i;
                label1.Text = i.ToString() + "%";
                i += 5;
            }
            else
            {
                timer1.Enabled = false;
                this.Hide();
                Home obj = new Home();
                obj.ShowDialog();
            }
        }
    }
}
