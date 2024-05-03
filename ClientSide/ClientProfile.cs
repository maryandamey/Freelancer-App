using FreelancerApp.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreelancerApp.ClientSide
{
    public partial class ClientProfile : Form
    {
        private int userID;
        public ClientProfile(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            LoadProfile();
        }

        private void LoadProfile()
        {
            string mySQL = "SELECT * FROM ClientProfile WHERE User_ID = " + userID;
            DataTable profileData = ServerConnection.executeSQL(mySQL);

            if (profileData.Rows.Count > 0)
            {
                numberTextBox.Text = profileData.Rows[0]["PhoneNumber"].ToString();
                CompanyTextBox.Text = profileData.Rows[0]["Company"].ToString();
            }
            else
            {
                numberTextBox.Text = "";
                CompanyTextBox.Text = "";
                MessageBox.Show("Please insert your profile details", "Insert Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string caption = "Save Profile Info : FreelancerApp";

            if (string.IsNullOrEmpty(numberTextBox.Text))
            {
                MessageBox.Show("Please Enter your Phone Number", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                numberTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CompanyTextBox.Text))
            {
                MessageBox.Show("Please Enter your Company name", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CompanyTextBox.Focus();
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to save your Profile Info ?", "Save Data:FreelancerApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string mySQL = string.Empty;
                mySQL = "IF NOT EXISTS (SELECT * FROM ClientProfile WHERE User_ID = " + userID + ") ";
                mySQL += "INSERT INTO ClientProfile (User_ID, PhoneNumber, Company) VALUES ";
                mySQL += "(" + userID + ", '" + numberTextBox.Text + "', '" + CompanyTextBox.Text + "') ";
                mySQL += "ELSE ";
                mySQL += "UPDATE ClientProfile SET ";
                mySQL += "PhoneNumber = '" + numberTextBox.Text + "', ";
                mySQL += "Company = '" + CompanyTextBox.Text + "' ";
                mySQL += "WHERE User_ID = " + userID;

                ServerConnection.executeSQL(mySQL);

                MessageBox.Show("Your Profile Informations has been saved ", "SaveData: FreeLancerApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

