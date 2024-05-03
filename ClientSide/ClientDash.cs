using System;
using System.Data;
using System.Windows.Forms;
using FreelancerApp.Connections;
using static FreelancerApp.Register;

namespace FreelancerApp.ClientSide
{
    public partial class ClientDash : Form
    {
        private int userID;
        private UserType userType;

        public ClientDash(int userID, UserType userType)
        {
            InitializeComponent();
            this.userID = userID;
            this.userType = userType;
            LoadSkills();
        }

        private void LoadSkills()
        {
            // Load skills from FreelancerProfile table
            string mySQL = "SELECT DISTINCT Skills FROM FreelancerProfile";
            DataTable skillsData = ServerConnection.executeSQL(mySQL);

            if (skillsData.Rows.Count > 0)
            {
                foreach (DataRow row in skillsData.Rows)
                {
                    chooseskillDropdown.Items.Add(row["Skills"].ToString());
                }
            }
        }

        private void chooseskillDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSkill = chooseskillDropdown.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedSkill))
            {
                MessageBox.Show("Please select a skill.", "Select Skill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string mySQL = "SELECT Username, Skills, Expertise, Portfolio, Past_Work FROM Login INNER JOIN FreelancerProfile ON Login.Auto_Id = FreelancerProfile.User_ID WHERE FreelancerProfile.Skills = '" + selectedSkill + "' AND FreelancerProfile.User_ID != " + userID;
            DataTable freelancerData = ServerConnection.executeSQL(mySQL);

            if (freelancerData.Rows.Count > 0)
            {
                freelancerDataGridView.DataSource = freelancerData;
            }
            else
            {
                freelancerDataGridView.DataSource = null;
                MessageBox.Show("No freelancers found with the selected skill.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void freelancerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click if needed
        }
    }
}
