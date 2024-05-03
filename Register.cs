using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FreelancerApp;
using FreelancerApp.Connections;
using System.Security.Cryptography;


namespace FreelancerApp
{
    public partial class Register : Form
    {

        public Register()
        {
            InitializeComponent();
            userTypeComboBox.Items.Add("Select");
            userTypeComboBox.Items.AddRange(Enum.GetNames(typeof(UserType)));
            userTypeComboBox.SelectedIndex = 0;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            f1.ShowDialog();
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {
            firstnameTextBox.Select();
        }
        public enum UserType
        {
            Client,
            Freelancer
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Save Data : FreelancerApp";

            if (string.IsNullOrEmpty(firstnameTextBox.Text))
            {
                MessageBox.Show("Please Enter your First Name", caption, btn, ico);
                firstnameTextBox.Select();
                return;
            }
            if (string.IsNullOrEmpty(lastnameTextBox.Text))
            {
                MessageBox.Show("Please Enter your Last Name", caption, btn, ico);
                lastnameTextBox.Select();
                return;
            }
            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                MessageBox.Show("Please Enter your Email Address", caption, btn, ico);
                EmailTextBox.Select();
                return;
            }
            if (string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                MessageBox.Show("Please Enter your UserName", caption, btn, ico);
                UsernameTextBox.Select();
                return;
            }
            if (string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                MessageBox.Show("Please Enter your Password", caption, btn, ico);
                PasswordTextBox.Select();
                return;
            }
            if (String.IsNullOrEmpty(userTypeComboBox.Text))
            {
                MessageBox.Show("Please Enter The userType", caption, btn, ico);
                userTypeComboBox.Select();
                return;
            }
            if (string.IsNullOrEmpty(ConfirmPasswordTextBox.Text))
            {
                MessageBox.Show("Please Confirm your password", caption, btn, ico);
                ConfirmPasswordTextBox.Select();
                return;
            }
            if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
            {
                MessageBox.Show("Your Password does not match with the confirm password", caption, btn, ico);
                ConfirmPasswordTextBox.SelectAll();
                return;
            }
            if (PasswordTextBox.Text.Length < 8 || PasswordTextBox.Text.Length > 12)
            {
                MessageBox.Show("Password should be between 8-12 characters", caption, btn, ico);
                PasswordTextBox.Select();
                return;
            }
            if (!PasswordTextBox.Text.Any(char.IsLower) || !PasswordTextBox.Text.Any(char.IsUpper))
            {
                MessageBox.Show("Password should contain at least one lowercase and one uppercase character", caption, btn, ico);
                PasswordTextBox.Select();
                return;
            }
            //UserType integer
            int userTypeValue = userTypeComboBox.SelectedIndex; // 0 for "Select", 1 for Client, 2 for Freelancer
            if (userTypeValue == 0)
            {
                MessageBox.Show("Please select a user type.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //End
            string yourSQL = "SELECT username FROM Login WHERE Username = '" + UsernameTextBox.Text + "'";
            DataTable checkDuplicates = ServerConnection.executeSQL(yourSQL);

            if (checkDuplicates.Rows.Count > 0)
            {
                MessageBox.Show("The username already exist. Please try another username", "FreeLancer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UsernameTextBox.SelectAll();
                return;
            }
            DialogResult result;
            result = MessageBox.Show("Do you want to submit ?", "Save Data:Freelancer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string mySQL = string.Empty;

                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(PasswordTextBox.Text));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }

                    string hashedPassword = builder.ToString();

                    mySQL += "INSERT INTO Login (First_Name, Last_Name, Email_Address, Username, Password,UserType)";
                    mySQL += "VALUES ('" + firstnameTextBox.Text + "','" + lastnameTextBox.Text + "','" + EmailTextBox.Text + "',";
                    mySQL += "'" + UsernameTextBox.Text + "','" + hashedPassword + "','" + userTypeComboBox.SelectedItem.ToString() + "')";

                    ServerConnection.executeSQL(mySQL);

                    MessageBox.Show("The record has been saved ", "SaveData: FreeLancer", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    //loadUserData();
                    //ClearControls();
                }
            }
        }

        private void userTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
    