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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_new obj = new login_new();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            register obj = new register();
            obj.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
