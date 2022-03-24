using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace FitnesProject1
{
    public partial class AddGroup : Form
    {
        public void bd() { 
        
        }
        public AddGroup()
        {
            InitializeComponent();
        }
        string connectionstring = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\ivail\Downloads\Fitnes.mdb";
        OleDbConnection dbconnect = new OleDbConnection();
        private void displaydata()

        private void AddGroup_Load(object sender, EventArgs e)
        {
            label1.Text = "ID of the Group";
            label2.Text = "Name of the Group";
            label3.Text = "ID of the Group";
            label4.Text = "Next exercise";

        }
        private static void RetrieveIdentity(string connectionString)
        {
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                // Create a SqlDataAdapter based on a SELECT query.
                SqlDataAdapter adapter =
                    new SqlDataAdapter(
                    "SELECT CategoryID, CategoryName FROM dbo.Categories",
                    connection);

                //Create the SqlCommand to execute the stored procedure.
                adapter.InsertCommand = new SqlCommand("dbo.InsertCategory",
                    connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                // Add the parameter for the CategoryName. Specifying the
                // ParameterDirection for an input parameter is not required.
                adapter.InsertCommand.Parameters.Add(
                   new SqlParameter("@CategoryName", SqlDbType.NVarChar, 15,
                   "CategoryName"));

                // Add the SqlParameter to retrieve the new identity value.
                // Specify the ParameterDirection as Output.
                SqlParameter parameter =
                    adapter.InsertCommand.Parameters.Add(
                    "@Identity", SqlDbType.Int, 0, "CategoryID");
                parameter.Direction = ParameterDirection.Output;

                // Create a DataTable and fill it.
                DataTable categories = new DataTable();
                adapter.Fill(categories);

                // Add a new row.
                DataRow newRow = categories.NewRow();
                newRow["CategoryName"] = "New Category";
                categories.Rows.Add(newRow);

                adapter.Update(categories);

                Console.WriteLine("List All Rows:");
                foreach (DataRow row in categories.Rows)
                {
                    {
                        Console.WriteLine("{0}: {1}", row[0], row[1]);
                    }
                }
            }
        }
    }
}
