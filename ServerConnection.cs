using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FreelancerApp.Connections
{
    internal class ServerConnection
    {
        public static string stringConnection = "Data source=Johnson\\SQLEXPRESS;Initial catalog = FreelancerApp; Integrated Security=True";
        public static DataTable executeSQL(string sql)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataAdapter adapter = default(SqlDataAdapter);
            DataTable dt = new DataTable();

            try
            {
                connection.ConnectionString = stringConnection;
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dt);
                connection.Close();
                connection = null;
                return dt;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred: " + ex.Message, "SQL Server connection Failed: FreeLancerApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt = null;
            }
            return dt;
        }

        internal static void CloseConnection()
        {
            throw new NotImplementedException();
        }

        internal static SqlConnection GetConnection()
        {
            throw new NotImplementedException();
        }

        internal static void OpenConnection()
        {
            throw new NotImplementedException();
        }
    }
    
}

