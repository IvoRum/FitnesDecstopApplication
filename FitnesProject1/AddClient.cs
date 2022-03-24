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
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }
        string connectionstring = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\ivail\Downloads\Fitnes.mdb";
        OleDbConnection dbconnect = new OleDbConnection();
        private void displaydata()
        {
            string myselect = "select Client.ID_Client, Client.Client_Name, Client.Client_Start_Date, Full_Schedul.Full_Schedul_Name, Health.Health_StartKG, Health.Health_StartBMI  FROM ((Client INNER JOIN Full_Schedul ON Client.Client_Schedule=Full_Schedul.ID_Full_Schedul) INNER JOIN Health ON Client.Client_Health=Health.ID_Health)";
            dbconnect.ConnectionString = connectionstring;
            dbconnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(myselect, dbconnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbconnect.Close();
        }
        //
        private void displaydata1()
        {
            // string myselect = "select Client.ID_Client,Client.Client_Name,Full_Schedul.Full_Schedual_Name,Client.Client_Start_Date  from Client join Full_Schedual ON Client.Client_Schedule=Full_Schedul.ID_Full_Schedul";
            //string myselect = "select Schedule.ID_Schedule,Schedule.Schedule_Name, Schedule.Schedule_Week_Day,Week.Week_Day ,Group.Group_Name,  FROM ((Schedule INNER JOIN Full_Schedul ON Client.Client_Schedule=Full_Schedul.ID_Full_Schedul) INNER JOIN Health ON Client.Client_Health=Health.ID_Health)";
            string myselect = "SELECT Group.ID_Group, Group.Group_Name, Exercise.Exercise_Name, Exercise.Exercise_Description, Grorp_Of_Exercises.ID_GtoE FROM Exercise INNER JOIN ([Group] INNER JOIN Grorp_Of_Exercises ON Group.ID_Group = Grorp_Of_Exercises.Groupe_ID) ON Exercise.ID_Exercise = Grorp_Of_Exercises.Exercise_ID;";
            //string myselect = "select * from Client";

            dbconnect.ConnectionString = connectionstring;
            dbconnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(myselect, dbconnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            //chart1.DataSource = dt;
            dbconnect.Close();
        }
        //
        private void displaydata2()
        {
            string myselect = "SELECT * from Grorp_Of_Exercises";
            dbconnect.ConnectionString = connectionstring;
            dbconnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(myselect, dbconnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView4.DataSource = dt;
            dbconnect.Close();
        }
        //
        private void displaydata3()
        {
            string myselect = "SELECT * from Client";
            dbconnect.ConnectionString = connectionstring;
            dbconnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(myselect, dbconnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView4.DataSource = dt;
            dbconnect.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            dbconnect.ConnectionString = connectionstring;
            //string myselect = "Insert into Stock(Article_Code, Name_Article, MinCap, AvilableCap, NetPrice, DDS, Brand, Method_sale)Values(" + textBox2.Text + ",'" + textBox3.Text + "'," + textBox4.Text + "," + textBox5.Text + "," + textBox6.Text + "," + textBox7.Text + ",'" + textBox8.Text + "'," + textBox9.Text + ")";
            string myinsert = "Insert into Client(ID_Client,Client_Name,Client_Start_Date,Client_Health)Values("+textBox1.Text+",'"+textBox2.Text+"','"+dateTimePicker1.Text+"',"+textBox1.Text+")";
            string myinserth = "Insert into Health(ID_Health,Health_StartKG,Health_StartBMI)Values("+textBox1.Text+","+textBox3.Text+","+textBox4.Text+")";
            OleDbCommand dbcommand = new OleDbCommand(myinsert, dbconnect);
            dbconnect.Open();
            dbcommand.CommandText = myinsert;
            dbcommand.Connection = dbconnect;
            dbcommand.ExecuteNonQuery();
            dbconnect.Close();
            ///
            OleDbCommand dbcommand1 = new OleDbCommand(myinserth, dbconnect);
            dbconnect.Open();
            dbcommand.CommandText = myinserth;
            dbcommand.Connection = dbconnect;
            dbcommand.ExecuteNonQuery();
            ///
            MessageBox.Show("Record submit", "Congrats");
            dbconnect.Close();
            displaydata();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void AddClient_Load_1(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            groupBox1.Text = "ADD NEW CLIENT TO DATA BASE:";
            groupBox2.Text = "UPDATE CLIENT FULL SHEDUL:";
            label1.Text = "New Client`s Start Date:";
            label2.Text = "New Client`s ID:";
            label3.Text = "New Client`s Name:";
            label4.Text = "New Client`s Start KG: ";
            label6.Text = "New Client`s Start BMI:";
            label5.Text = dateTimePicker1.Text;
            label7.Text = "All clients:";
            label8.Text = "Clients With Schedul:";
            displaydata1();
            displaydata2();
            displaydata3();
            displaydata();
        }
        
        ///

    }
}
