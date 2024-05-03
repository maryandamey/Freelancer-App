using FreelancerApp.Connections;
using Microsoft.VisualBasic;
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
    public partial class Reviews : Form
    {
        public Reviews()
        {
            InitializeComponent();
            LoadCompletedProjects();
        }

        private void LoadCompletedProjects()
        {
            string mySQL = "SELECT L.Username AS Username, P.Description AS ProjectDescription ";
            mySQL += "FROM Projects P ";
            mySQL += "JOIN Login L ON P.User_ID = L.Auto_Id ";
            mySQL += "WHERE P.Completed = 1";

            DataTable completedProjectsData = ServerConnection.executeSQL(mySQL);
            if (completedProjectsData.Rows.Count > 0)
            {
                ReviewDataGridView.DataSource = completedProjectsData;
                DataGridViewButtonColumn reviewButtonColumn = new DataGridViewButtonColumn();
                reviewButtonColumn.HeaderText = "Write Review";
                reviewButtonColumn.Text = "Write Review";
                reviewButtonColumn.UseColumnTextForButtonValue = true;
                ReviewDataGridView.Columns.Add(reviewButtonColumn);
            }
            else
            {
                MessageBox.Show("No completed projects found.", "Completed Projects", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReviewDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex < ReviewDataGridView.Columns.Count && ReviewDataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Get the project description from the selected row
                string projectDescription = ReviewDataGridView.Rows[e.RowIndex].Cells["ProjectDescription"].Value.ToString();

                // Show a dialog for the client to write and post a review
                string review = Interaction.InputBox("Write your review for the project:\n" + projectDescription, "Write Review", "");

                if (!string.IsNullOrEmpty(review))
                {
                    // Update the Projects table to add the review
                    string updateSQL = $"UPDATE Projects SET Reviews = '{review}' WHERE Description = '{projectDescription}'";
                    ServerConnection.executeSQL(updateSQL);

                    MessageBox.Show("Review posted successfully.", "Review Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
