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
    public partial class CompletedProjects : Form
    {
        public CompletedProjects()
        {
            InitializeComponent();
            LoadCompletedProjects();
        }
        private void LoadCompletedProjects()
        {
            string mySQL = "SELECT L.Username AS Username, P.Description AS ProjectDescription, 'Completed' AS Status ";
            mySQL += "FROM Projects P ";
            mySQL += "JOIN Login L ON P.User_ID = L.Auto_Id ";
            mySQL += "WHERE P.Completed = 1";

            DataTable completedProjectsData = ServerConnection.executeSQL(mySQL);
            if (completedProjectsData.Rows.Count > 0)
            {
                completeDataGridView.DataSource = completedProjectsData;
            }
            else
            {
                MessageBox.Show("No completed projects found.", "Completed Projects", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    
    private void completeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
