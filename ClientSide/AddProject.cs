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
    public partial class AddProject : Form
    {
        private int userID;

        public AddProject(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void budgetTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void addprojectButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Save Data : FreelancerApp";

            if (string.IsNullOrEmpty(descriptionTextBox.Text))
            {
                MessageBox.Show("Please Enter the Description", caption, btn, ico);
                descriptionTextBox.Select();
                return;
            }
            if (string.IsNullOrEmpty(budgetTextBox.Text))
            {
                MessageBox.Show("Please Enter the Budget", caption, btn, ico);
                budgetTextBox.Select();
                return;
            }
            if (string.IsNullOrEmpty(startDatePicker.Text))
            {
                MessageBox.Show("Please Enter the Start Date", caption, btn, ico);
                startDatePicker.Select();
                return;
            }
            if (string.IsNullOrEmpty(endDatePicker.Text))
            {
                MessageBox.Show("Please Enter the End Date", caption, btn, ico);
                endDatePicker.Select();
                return;
            }
            DialogResult result = MessageBox.Show("Do you want to save your Profile Info ?", "Save Data:FreelancerApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string mySQL = string.Empty;
                mySQL += "INSERT INTO Projects (User_ID, Description, Budget, StartDate, EndDate) VALUES ";
                mySQL += "(" + userID + ", '" + descriptionTextBox.Text + "', '" + budgetTextBox.Text + "', '" + startDatePicker.Value.ToString("yyyy-MM-dd") + "', '" + endDatePicker.Value.ToString("yyyy-MM-dd") + "') ";

                ServerConnection.executeSQL(mySQL);

                MessageBox.Show("Your Project has been saved ", "SaveData: FreeLancerApp", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
    }

