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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionstring = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\ivail\Downloads\Fitnes.mdb";
        OleDbConnection dbconnect = new OleDbConnection();

        private void displaydata()
        {
           // string myselect = "select Client.ID_Client,Client.Client_Name,Full_Schedul.Full_Schedual_Name,Client.Client_Start_Date  from Client join Full_Schedual ON Client.Client_Schedule=Full_Schedul.ID_Full_Schedul";
            string myselect = "select Client.ID_Client, Client.Client_Name, Client.Client_Start_Date, Full_Schedul.Full_Schedul_Name FROM (Client INNER JOIN Full_Schedul ON Client.Client_Schedule=Full_Schedul.ID_Full_Schedul)";

            //string myselect = "select * from Client";

            dbconnect.ConnectionString = connectionstring;
            dbconnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(myselect, dbconnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            chart1.DataSource = dt;
            dbconnect.Close();
        }
        //
        private void chartControl() {
            string myselect = "";
            dbconnect.ConnectionString = connectionstring;
           
        }
        //chek for client apoitment
        private void chekIT() { 
        
        
        }
        //
        private void test() {
            string da;
            DateTime.UtcNow.ToString("yyyy-dd-MM");
        }
        //

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //label1.Text = DateTime.UtcNow.ToString("yyyy-dd-MM");
            //label1.Text="Today`s Clients:";
            label2.Text = "Monday";
            label3.Text = "Tuesday";
            label4.Text = "Wednesday";
            label5.Text = "Thursday";
            label6.Text = "Friday";
            label7.Text = "Saturday";
            label8.Text = "Sunday";
            label9.Text = "08:";
            label10.Text = "09:";
            label11.Text = "10:";
            label12.Text = "11:";
            label13.Text = "12:";
            label14.Text = "13:";
            label15.Text = "14:";
            label16.Text = "15:";
            label17.Text = "16:";
            label18.Text = "17:";
            label19.Text = "18:";
            label20.Text = "19:";
            


            displaydata();
        }

        private void newAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClient newForm = new AddClient();
            newForm.Show();
            this.Hide();
        }

        private void addNewExercisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddExercise newForm = new AddExercise();
            newForm.Show();
            this.Hide();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin newForm = new Admin();
            newForm.Show();
            this.Hide();
        }

        private void makeNewGrupsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}
