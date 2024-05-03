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
using static FreelancerApp.Register;
using System.Security.Cryptography;



namespace FreelancerApp
{
    public partial class Login : Form
    {
        private UserType userType;
        

        public Login()
        {
            InitializeComponent();
          //  this.userID = userID;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            usernameTextBox.Select();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register f2 = new Register();
            f2.ShowDialog();
            
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFormControlBox1_HelpClicked(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(usernameTextBox.Text) && !string.IsNullOrEmpty(PasswordTextBox1.Text))
            {

                string mySQL = string.Empty;

                mySQL += "SELECT * FROM Login ";
                mySQL += "WHERE Username = '" + usernameTextBox.Text + "'";
                //mySQL += "AND Password = '" + PasswordTextBox1.Text + "'";

                DataTable userData = ServerConnection.executeSQL(mySQL);

                if (userData.Rows.Count > 0)
                {
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(PasswordTextBox1.Text));

                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        string hashedPassword = builder.ToString();

                        if (hashedPassword == userData.Rows[0]["Password"].ToString())
                        {
                            userType = (UserType)Enum.Parse(typeof(UserType), userData.Rows[0]["UserType"].ToString());

                            usernameTextBox.Clear();
                            PasswordTextBox1.Clear();
                            //showpasswordcheckBox.Checked = false;

                            int userTypeValue;
                            int.TryParse(userData.Rows[0]["UserType"].ToString(), out userTypeValue);
                            
                            if(userType == UserType.Freelancer)
                            {

                                GlobalVariable.UserID = Convert.ToInt32(userData.Rows[0]["Auto_Id"]);
                            }
                            if (userType == UserType.Client)
                            {

                                GlobalVariable.UserID = Convert.ToInt32(userData.Rows[0]["Auto_Id"]);
                            }

                            if (userTypeValue == 1)
                            {
                                userType = UserType.Client;
                                GlobalVariable.UserID = Convert.ToInt32(userData.Rows[0]["User_ID"]);
                            }
                            else if (userTypeValue == 2)
                            {
                                userType = UserType.Freelancer;
                                GlobalVariable.UserID = Convert.ToInt32(userData.Rows[0]["User_ID"]);
                            }

                            //this.Hide();
                            //FreelancerPage freelancerForm = new FreelancerPage();
                            //freelancerForm.ShowDialog();



                            if (userType == UserType.Client)
                            {
                                ClientPage clientForm = new ClientPage(GlobalVariable.UserID, userType);
                                clientForm.ShowDialog();

                            }
                            else if (userType == UserType.Freelancer)
                            {
                                FreelancerPage f3 = new FreelancerPage(GlobalVariable.UserID);
                                f3.ShowDialog();

                            }
                            //ClientPage formMain = new ClientPage();
                            // formMain.ShowDialog();
                            // formMain = null;

                            this.Show();
                            this.usernameTextBox.Select();
                        }
                        else
                        {
                            MessageBox.Show("The username or password is incorrect. Try Again.", "FreelancerAPP", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            usernameTextBox.Focus();
                            usernameTextBox.SelectAll();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter username and password.", "FreeLancerApp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    usernameTextBox.Select();
                }



                }
    }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void showpasswordCheckBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
          
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void ShowPassCheckBox_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (showpasswordCheckBox.Checked == true)
            {
                PasswordTextBox1.UseSystemPasswordChar = false;
            }

            else
            {
                PasswordTextBox1.UseSystemPasswordChar = true;
            }
        }
    }
}
