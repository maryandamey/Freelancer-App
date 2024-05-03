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

namespace FreelancerApp.FreelancerSide
{
    public partial class BrowseProjects : Form
    {
        public BrowseProjects()
        {
            InitializeComponent();
            LoadProjects();
        }

        private void LoadProjects()
        {
            string mySQL = "SELECT P.ProjectID, L.Username, P.Description, P.Budget, P.StartDate, P.EndDate FROM Projects P ";
            mySQL += "JOIN Login L ON P.User_ID = L.Auto_Id";

            DataTable projectsData = ServerConnection.executeSQL(mySQL);
            if (projectsData.Rows.Count > 0)
            {
                // Add a button column for bidding
                DataGridViewButtonColumn bidButtonColumn = new DataGridViewButtonColumn();
                bidButtonColumn.HeaderText = "Bid";
                bidButtonColumn.Text = "Bid";
                bidButtonColumn.UseColumnTextForButtonValue = true;
                ProjectsDataGridView.Columns.Add(bidButtonColumn);

                ProjectsDataGridView.DataSource = projectsData;
            }
            else
            {
                MessageBox.Show("No projects found.", "Browse Projects", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProjectsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is the "Bid" button
            if (e.RowIndex >= 0 && e.ColumnIndex < ProjectsDataGridView.Columns.Count && ProjectsDataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex < ProjectsDataGridView.Rows.Count)
            {
                // Get the selected project's information
                int projectID = Convert.ToInt32(ProjectsDataGridView.Rows[e.RowIndex].Cells["ProjectID"].Value);
                string projectDescription = ProjectsDataGridView.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                decimal budget = Convert.ToDecimal(ProjectsDataGridView.Rows[e.RowIndex].Cells["Budget"].Value);
                DateTime startDate = Convert.ToDateTime(ProjectsDataGridView.Rows[e.RowIndex].Cells["StartDate"].Value);
                DateTime endDate = Convert.ToDateTime(ProjectsDataGridView.Rows[e.RowIndex].Cells["EndDate"].Value);

                // Prompt the user to enter a bid amount
                string input = Microsoft.VisualBasic.Interaction.InputBox("Enter your bid amount for the project:", "Bid Amount", "0");
                if (!string.IsNullOrEmpty(input))
                {
                    decimal bidAmount;
                    if (decimal.TryParse(input, out bidAmount))
                    {
                        // Insert the bid into the Bid table with the project ID
                        string insertSQL = $"INSERT INTO Bid (ProjectID, User_ID, BidAmount, BidDate) VALUES ({projectID}, {GlobalVariable.UserID}, {bidAmount}, GETDATE())";
                        ServerConnection.executeSQL(insertSQL);

                        MessageBox.Show($"Your bid of {bidAmount:C} for project {projectDescription} has been submitted.", "Bid Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Invalid bid amount. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
