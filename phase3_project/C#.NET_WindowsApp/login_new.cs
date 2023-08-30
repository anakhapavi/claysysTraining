using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Claysys_WinFormsApp
{
    public partial class login_new : Form
    {
        public login_new()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-V3KGRPP\\SQLEXPRESS;Initial Catalog=Management;Integrated Security=True");

        private void login_new_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        private void btn_login_Click(object sender, EventArgs e)

        {
            string inputUsername = txtusername.Text;
            string inputPassword = txtpassword.Text;

            

           string sql = "SELECT usertype FROM login WHERE username = @Username AND password = @Password";


            using (SqlCommand cmd = new SqlCommand(sql, con))

            {
                cmd.Parameters.AddWithValue("@Username", inputUsername);
                cmd.Parameters.AddWithValue("@Password", inputPassword);

                using (SqlDataReader rdr = cmd.ExecuteReader())

                {
                    if (rdr.Read())
                    {
                        string userType = rdr.GetString(0);
                        if (userType == "admin")
                        {
                            this.Hide();
                            admin obj = new admin();
                            obj.Show();
                        }
                        else if (userType == "user")
                        {
                            this.Hide();
                            user obj = new user(inputUsername);
                            obj.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtusername.Text = string.Empty;
                        txtpassword.Text = string.Empty;
                    }
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtusername.Text = string.Empty;
            txtpassword.Text = string.Empty;
            txtusername.Focus();

        }

        private void label_crtaccount_Click(object sender, EventArgs e)
        {
            label_crtaccount.ForeColor = Color.Black;
            this.Hide();
            register obj = new register();
            obj.Show();
        }

        private void checkBox_pswd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_pswd.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else {
                txtpassword.PasswordChar = '*';
            }
        }
    }
}
