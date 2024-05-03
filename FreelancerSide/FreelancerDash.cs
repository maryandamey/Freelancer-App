using FreelancerApp.Connections;
using System.Data;
using System.Windows.Forms;
using System;

namespace FreelancerApp.FreelancerSide
{
    public partial class FreelancerDash : Form
    {
        private int freelancerUserID; // Add a field to store the freelancer's User_ID

        public FreelancerDash(int userID)
        {
            InitializeComponent();
            this.freelancerUserID = userID; // Store the freelancer's User_ID
            LoadApprovedProjects();
        }

        private void LoadApprovedProjects()
        {
            string mySQL = "SELECT P.ProjectID, P.Description AS ProjectDescription, L.Username AS Username, P.StartDate, P.EndDate ";
            mySQL += "FROM Projects P ";
            mySQL += "JOIN Bid B ON P.ProjectID = B.ProjectID ";
            mySQL += "JOIN Login L ON P.User_ID = L.Auto_Id ";
            mySQL += "WHERE B.User_ID = " + freelancerUserID + " AND B.Approved = 1";

            DataTable projectsData = ServerConnection.executeSQL(mySQL);
            if (projectsData.Rows.Count > 0)
            {
                // Calculate and add the duration of the project
                projectsData.Columns.Add("Duration", typeof(string));
                for (int i = 0; i < projectsData.Rows.Count; i++)
                {
                    DateTime startDate = Convert.ToDateTime(projectsData.Rows[i]["StartDate"]);
                    DateTime endDate = Convert.ToDateTime(projectsData.Rows[i]["EndDate"]);
                    int durationDays = (int)(endDate - startDate).TotalDays;
                    projectsData.Rows[i]["Duration"] = durationDays.ToString() + " days";
                }

                // Add a button column for completing projects
                DataGridViewButtonColumn completeButtonColumn = new DataGridViewButtonColumn();
                completeButtonColumn.HeaderText = "Complete Project";
                completeButtonColumn.Text = "Complete";
                completeButtonColumn.UseColumnTextForButtonValue = true;
                OngoingDataGridView.Columns.Add(completeButtonColumn);

                OngoingDataGridView.DataSource = projectsData;
            }
            else
            {
                MessageBox.Show("No approved projects found.", "Approved Projects", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OngoingDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex < OngoingDataGridView.Columns.Count && OngoingDataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int projectID = Convert.ToInt32(OngoingDataGridView.Rows[e.RowIndex].Cells["ProjectID"].Value);

                // Update the Projects table to mark the project as completed
                string updateSQL = $"UPDATE Projects SET Completed = 1 WHERE ProjectID = {projectID}";
                ServerConnection.executeSQL(updateSQL);

                MessageBox.Show("Project completed.", "Completion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload the approved projects
                LoadApprovedProjects();
            }
        }
    }
}
