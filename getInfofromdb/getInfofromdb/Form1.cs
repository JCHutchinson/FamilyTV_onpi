using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace getInfofromdb
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        string connString;
        MySqlDataAdapter adapter;
        MySqlDataAdapter adapter2;
        MySqlCommand command;

        MemoryStream memStream;
        DataTable dt;
        DataSet ds;

        //used to navigate between pivtures
        int navigate = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //CONNECT TO SERVER
            connString = "SERVER = 160.153.33.38;PORT=3306;DATABASE=familytv_database1;UID=familyTvOwner;PASSWORD=familyTvProject";
            //GET IMAGES FUNCTION THAT CONTROLS RETIREVEING AND DISPLAYING IMAGES FROM dATABASE
         
            
        }

        private void getData()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM familytv_database1.pictures.title",conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "pictures");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                MessageBox.Show("connection success");

                adapter = new MySqlDataAdapter("SELECT * FROM familytv_database1.pictures", conn);
                ds = new DataSet();
                adapter.Fill(ds, "pictures");
                //dataGridView1.DataSource = ds.Tables["pictures.title"];
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                //MessageBox.Show("connection success");
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            //string query = "SELECT * FROM UserPics WHERE userid = 12";
            string query = "SELECT image FROM UserPics2 WHERE userid = 12 ";
            command = new MySqlCommand(query, conn);
            adapter2 = new MySqlDataAdapter(command);

            dt = new DataTable();
            adapter2.Fill(dt);

           // textBoxId.Text = dt.Rows[0][1].ToString();
           // textBoxTitle.Text = dt.Rows[0][2].ToString();

            byte[] img = (byte[])dt.Rows[0][0];
            memStream = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(memStream);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //adapter2.Dispose();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            navigate += 1;
            if (navigate == 4)
            {
                navigate = 0;
            }

            navigateImages(navigate);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            navigate -= 1;
            if (navigate < 0)
            {
                navigate = dt.Rows.Count-1;
            }
            navigateImages(navigate);
            
        }

        private void navigateImages(int nav)
        {
           // textBoxId.Text = dt.Rows[nav][1].ToString();
            //textBoxTitle.Text = dt.Rows[nav][2].ToString();

            byte[] img = (byte[])dt.Rows[nav][0];
            memStream = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(memStream);
        }
   
    }
}
