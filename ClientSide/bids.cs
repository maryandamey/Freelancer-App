using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FreelancerApp.Connections;

namespace FreelancerApp.ClientSide
{
    public partial class bids : Form
    {
        private int clientUserID; // Add a field to store the client's User_ID
        private List<int> approvedBids; // Store the approved bid IDs

        public bids(int userID)
        {
            InitializeComponent();
            this.clientUserID = userID; // Store the client's User_ID
            this.approvedBids = new List<int>();
            LoadBids();
        }

        private void LoadBids()
        {
            string mySQL = "SELECT B.BidID, L.Username AS Username, P.Description AS ProjectDescription, B.BidAmount, B.BidDate, FP.Past_Work, B.Approved ";
            mySQL += "FROM Bid B ";
            mySQL += "JOIN Projects P ON B.ProjectID = P.ProjectID ";
            mySQL += "JOIN Login L ON B.User_ID = L.Auto_Id ";
            mySQL += "JOIN FreelancerProfile FP ON B.User_ID = FP.User_ID ";
            mySQL += "WHERE P.User_ID = " + clientUserID; // Filter projects by client's User_ID

            DataTable bidsData = ServerConnection.executeSQL(mySQL);
            if (bidsData.Rows.Count > 0)
            {
                // Add a button column for each bid
                for (int i = 0; i < bidsData.Rows.Count; i++)
                {
                    int bidID = Convert.ToInt32(bidsData.Rows[i]["BidID"]);
                    bool approved = bidsData.Rows[i]["Approved"] != DBNull.Value && Convert.ToBoolean(bidsData.Rows[i]["Approved"]);

                    DataGridViewButtonColumn approveButtonColumn = new DataGridViewButtonColumn();
                    approveButtonColumn.HeaderText = "Approve";
                    approveButtonColumn.Text = approved ? "Approved" : "Approve";
                    approveButtonColumn.UseColumnTextForButtonValue = true;
                    bidsDataGridView.Columns.Add(approveButtonColumn);

                    // Add bid ID to the approved list if already approved
                    if (approved)
                    {
                        approvedBids.Add(bidID);
                    }
                }

                bidsDataGridView.DataSource = bidsData;
            }
            else
            {
                MessageBox.Show("No bids found.", "Bids", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bidsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is the "Approve" button
            if (e.RowIndex >= 0 && e.ColumnIndex < bidsDataGridView.Columns.Count && bidsDataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Get the bid ID from the selected row
                int bidID = Convert.ToInt32(bidsDataGridView.Rows[e.RowIndex].Cells["BidID"].Value);

                // Check if the bid is already approved
                if (approvedBids.Contains(bidID))
                {
                    MessageBox.Show("This bid has already been approved.", "Already Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Update the Bid table to mark the bid as approved
                string updateSQL = $"UPDATE Bid SET Approved = 1 WHERE BidID = {bidID}";
                ServerConnection.executeSQL(updateSQL);

                MessageBox.Show("Bid approved.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Add the bid ID to the approved list
                approvedBids.Add(bidID);

                // Update the button text to "Approved"
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)bidsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                buttonCell.Value = "Approved";
                buttonCell.FlatStyle = FlatStyle.Flat;
                buttonCell.Style.BackColor = Color.LightGreen;
            }
        }
    }
}
