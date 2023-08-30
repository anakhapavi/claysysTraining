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
using System.Windows.Forms.VisualStyles;

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

            comboBox_state.Items.Insert(0, "--select--");
            comboBox_state.SelectedIndex = 0;

            comboBox_city.Items.Insert(0,"--select--");
            comboBox_city.SelectedIndex = 0;
            comboBox_state.SelectedIndexChanged += comboBox_state_SelectedIndexChanged;



        }


        //insertion
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

            date = dateTimePicker.Value.ToString("yyyy-MM-dd");

            string selectedState = comboBox_state.SelectedItem.ToString();
            string selectedCity = comboBox_city.SelectedItem.ToString();


            if (selectedState == "Others")
            {
                selectedState = txt_otherstate.Text;
                selectedCity = txt_othercity.Text;
            }


            try
            {

                sql = "insert into register values('" + txtfname.Text + "','" + txtlname.Text + "','" + date + "','" + txtage.Text + "','" + gen + "','" + txtphone.Text + "','" + txtemail.Text + "','" + selectedState + "','" + selectedCity + "','" + txtusername.Text + "','" + txtpassword.Text + "','" + txtcpassword.Text + "') ";
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
                    txtfname.Text = string.Empty;
                    txtlname.Text = string.Empty;
                    txtemail.Text = string.Empty;
                    txtage.Text = string.Empty;
                    txtusername.Text = string.Empty;
                    txtpassword.Text = string.Empty;
                    txtcpassword.Text = string.Empty;
                    txtfname.Text = string.Empty;
                    date = string.Empty;
                    gen = string.Empty;
                    comboBox_state.Items.Clear();
                    comboBox_city.Items.Clear();

                    txtfname.Focus();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //validations

        //first name validation
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

        private bool IsValidFname()
        {
            string pattern = @"^[A-Z][a-zA-Z]*$";
            return Regex.IsMatch(txtfname.Text, pattern);
        }

        private void txtfname_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidFname())
            {
                errorProvider1.SetError(txtfname, "Fist letter in caps(only letters allowed)");
            }
            else
            {
                errorProvider1.SetError(txtfname, "");
            }
        }


        //last name validation
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

        private bool IsValidLname()
        {
            string pattern = @"^[A-Z][a-zA-Z]*$";
            return Regex.IsMatch(txtlname.Text, pattern);
        }

        private void txtlname_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidLname())
            {
                errorProvider2.SetError(txtlname, "Fist letter in caps(only letters allowed)");
            }
            else
            {
                errorProvider2.SetError(txtlname, "");
            }

        }


        //phone validation
        private void txtphone_validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtphone.Text))
            {
                e.Cancel = true;
                txtphone.Focus();
                errorProvider3.SetError(txtphone, "Phone number is required!");
            }
            else if (!IsValidPhone())
            {
                e.Cancel = true;
                errorProvider3.SetError(txtphone, "valid,10 digits ");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(txtphone, "");

            }
        }
        private bool IsValidPhone()
        {
            string pattern = @"^\d{10}$";
            return Regex.IsMatch(txtphone.Text, pattern);
        }



        //email validation
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


        //username validation
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
        private bool IsValidUsername()

        {
            string pattern = @"^[a-zA-Z0-9_]{4,}$"; ;
            return Regex.IsMatch(txtusername.Text, pattern);

        }

        private void txtusername_TextChanged(object sender, EventArgs e)

        {
            if (!IsValidUsername())
            {
                errorProvider4.SetError(txtusername, "Username must be at least 4 characters long and contain only letters, digits, and underscores.");
            }
            else
            {
                errorProvider4.SetError(txtusername, "");
            }
        }



        //password validation
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

        private bool IsValidPassword()

        {
            string pattern = @"^[a-zA-Z0-9]{6,}$"; ;
            return Regex.IsMatch(txtpassword.Text, pattern);

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidPassword())
            {
                errorProvider6.SetError(txtpassword, "Password must be 6 charcters lon include letters,digits");
            }
            else
            {
                errorProvider6.SetError(txtpassword, "");
            }

        }


        //confirm password validation
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

        private void txtcpassword_TextChanged(object sender, EventArgs e)
        {
            if (txtpassword.Text != txtcpassword.Text)
            {
                errorProvider7.SetError(txtcpassword, "Password not match!");
            }
            else
            {
                errorProvider7.SetError(txtcpassword, "");
            }

        }

        //button clear
        private void btn_login_Click(object sender, EventArgs e)
        {
            txtfname.Text = string.Empty;
            txtlname.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtphone.Text = string.Empty;
                        

            txtusername.Text = string.Empty;
            txtpassword.Text = string.Empty;
            txtcpassword.Text = string.Empty;
            txtusername.Focus();
        }



        //back to login
        private void label_bktlogin_Click(object sender, EventArgs e)
        {
            label_bktlogin.ForeColor = Color.Black;
            this.Hide();
            login_new obj = new login_new();
            obj.Show();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dob = dateTimePicker.Value;
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;

            if (today < dob.AddYears(age))
            {
                age--;
            }
            txtage.Text = age.ToString();

        }

        private void comboBox_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox_state.SelectedItem.ToString();
            string selectedCity = "";

            comboBox_city.Items.Clear(); // Clear existing items
            comboBox_city.Items.Add("--select--");

            if (selectedState == "Andra Pradesh")
            {
                comboBox_city.Items.Add("Vijaywada");
                comboBox_city.Items.Add("Vishakapattanam");
                comboBox_city.Items.Add("Nelloore");
            }
            else if (selectedState == "Goa")
            {
                comboBox_city.Items.Add("Margao");
                comboBox_city.Items.Add("Panaji");
                comboBox_city.Items.Add("Vasco");
            }
            else if (selectedState == "Karanataka")
            {
                comboBox_city.Items.Add("Bangalore");
                comboBox_city.Items.Add("Chickamanglore");
                comboBox_city.Items.Add("Uduppi");
            }

            else if (selectedState == "Kerala")
            {
                comboBox_city.Items.Add("Kochi");
                comboBox_city.Items.Add("Kottayam");
                comboBox_city.Items.Add("Thiruvanathapuram");
            }

            else if (selectedState == "Tamil Nadu")
            {
                comboBox_city.Items.Add("Chennai");
                comboBox_city.Items.Add("Coimbatore");
                comboBox_city.Items.Add("Madurai");
            }
            comboBox_city.SelectedIndex = 0;

            if (selectedState == "Others")
            {
                txt_otherstate.Visible = true;
                txt_othercity.Visible = true;
                comboBox_city.Visible = false; // Hide the city ComboBox

                selectedState = txt_otherstate.Text;
                selectedCity = txt_othercity.Text;
            }
            else
            {
                txt_otherstate.Visible = false;
                txt_othercity.Visible = false;
                comboBox_city.Visible = true; // Show the city ComboBox

                selectedCity = comboBox_city.SelectedItem?.ToString() ?? "";



            }

        }

        private void checkBox_pswd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_pswd.Checked)
            {
                txtpassword.PasswordChar = '\0';
                txtcpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
                txtcpassword.PasswordChar = '*';
            }
        }
    }
}

