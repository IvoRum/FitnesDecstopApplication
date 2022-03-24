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
    public partial class AddExercise : Form
    {
        public AddExercise()
        {
            InitializeComponent();
        }
        string connectionstring = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\ivail\Downloads\Fitnes.mdb";
        OleDbConnection dbconnect = new OleDbConnection();


        private void AddExercise_Load(object sender, EventArgs e)
        {
            label1.Text = "Exercise ID";
            //label1.Text = dataGridView1.SelectedCells.ToString() ;
            label2.Text = "Exercise Name";
            label3.Text = "Exercise Discription";
            button1.Text = "Input";
            button2.Text = "Update";
            button3.Text = "Delete";
            displaydata();
        }

        private void displaydata()
        {
            string myselect = "select * from Exercise";
            dbconnect.ConnectionString = connectionstring;
            dbconnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(myselect, dbconnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbconnect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbconnect.ConnectionString = connectionstring;
            //string myselect = "Insert into Stock(Article_Code, Name_Article, MinCap, AvilableCap, NetPrice, DDS, Brand, Method_sale)Values(" + textBox2.Text + ",'" + textBox3.Text + "'," + textBox4.Text + "," + textBox5.Text + "," + textBox6.Text + "," + textBox7.Text + ",'" + textBox8.Text + "'," + textBox9.Text + ")";
            string myselect = "Insert into Exercise(Exercise_Name, Exercise_Description) Values('" + textBox2.Text + "','" + textBox3.Text + "')";
            OleDbCommand dbcommand = new OleDbCommand(myselect, dbconnect);
            dbconnect.Open();
            dbcommand.CommandText = myselect;
            dbcommand.Connection = dbconnect;
            dbcommand.ExecuteNonQuery();
            MessageBox.Show("Record submit", "Congrats");
            dbconnect.Close();
            displaydata();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CanSelect==true){
                dbconnect.ConnectionString = connectionstring;
                string myselect = "UPDATE Exercise SET Exercise_Name='" + textBox2.Text + "', Exercise_Description='" + textBox3.Text + "' WHERE ID_Exercise=" + textBox1.Text +"";
                OleDbCommand dbcommand = new OleDbCommand(myselect, dbconnect);
                dbconnect.Open();
                dbcommand.CommandText = myselect;
                dbcommand.Connection = dbconnect;
                dbcommand.ExecuteNonQuery();
                MessageBox.Show("Record submit", "Congrats");
                dbconnect.Close();
                displaydata();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
