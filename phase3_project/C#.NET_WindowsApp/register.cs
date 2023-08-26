using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;

namespace Claysys_WinFormsApp
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-V3KGRPP\\SQLEXPRESS;Initial Catalog=Management;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader rdr;
        SqlDataAdapter adp;

        string sql, gen, date, userName, userPassword;
        private void register_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {


            if (radiobtn_female.Checked)
            {
                gen = "Female";
            }
            else if (radiobtn_male.Checked)
            {
                gen = "Male";
            }
            else
            {
                gen = "Others";
            }

            date = dateTimePicker.Value.ToString("dd-MM-YYYY");

            try
            {

                sql = "insert into register values('" + txtfname.Text + "','" + txtlname.Text + "','" + date + "','" + txtage.Text + "','" + gen + "','" + txtphone.Text + "','" + txtemail.Text + "','" + comboBox_state.SelectedItem.ToString() + "','" + comboBox_city.SelectedItem.ToString() + "','" + txtusername.Text + "','" + txtpassword.Text + "','" + txtcpassword.Text + "') ";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();


                sql = "insert into login values('" + txtusername.Text + "','" + txtcpassword.Text + "','user') ";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                userName = txtusername.Text;
                userPassword = txtpassword.Text;


                DialogResult result = MessageBox.Show("Your Account has been created", "Registration Sucess", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


                if (result == DialogResult.OK)
                {
                    login_new obj = new login_new();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    txtfname.Text = "";
                    txtlname.Text = "";
                    date = "";
                    txtage.Text = "";
                    gen = "";
                    txtphone.Text = "";
                    txtemail.Text = "";
                    comboBox_state.Items.Clear();
                    comboBox_city.Items.Clear();
                    txtusername.Text = "";
                    txtpassword.Text = "";
                    txtcpassword.Text = "";

                    txtfname.Focus();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //validations
        private void txtfname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtfname.Text))
            {
                e.Cancel = true;
                txtfname.Focus();
                errorProvider1.SetError(txtfname, "First name is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtfname, "");

            }
        }

        private void txtlname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtlname.Text))
            {
                e.Cancel = true;
                txtlname.Focus();
                errorProvider2.SetError(txtlname, "Last name is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txtlname, "");

            }

        }

        private void txtphone_validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtphone.Text))
            {
                e.Cancel = true;
                txtphone.Focus();
                errorProvider3.SetError(txtphone, "Phone number is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(txtphone, "");

            }
        }

        private void txtemail_validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtemail.Text))
            {
                e.Cancel = true;
                txtemail.Focus();
                errorProvider5.SetError(txtemail, "Email is required!");
            }
            else if (!IsValidEmail())
            {
                e.Cancel = true;
                errorProvider5.SetError(txtemail, "Invalid email address.");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(txtemail, "");
            }
        }

        private bool IsValidEmail()
          {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            return Regex.IsMatch(txtemail.Text, pattern);
          }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtusername_validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text))
            {
                e.Cancel = true;
                txtusername.Focus();
                errorProvider4.SetError(txtusername, "Username is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(txtusername, "");

            }
        }

        private void txtpassword_validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                e.Cancel = true;
                txtpassword.Focus();
                errorProvider6.SetError(txtphone, "Password is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider6.SetError(txtpassword, "");

            }
        }

        private void txtcpassword_Validating(object sender, CancelEventArgs e)
        {
              if (string.IsNullOrWhiteSpace(txtcpassword.Text))
                {
                    e.Cancel = true;
                    txtcpassword.Focus();
                    errorProvider7.SetError(txtcpassword, "Confirm Password is required!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider7.SetError(txtcpassword, "");

                }
            }
        //email validation
 



    }
}
