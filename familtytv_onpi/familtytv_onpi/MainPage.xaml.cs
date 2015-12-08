using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MySql.Data.MySqlClient.RT;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace familtytv_onpi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private const string csMySQL = "Server=192.168.1.150;Database=IoTApps;Uid=IoTApplication;Pwd=xxxx;SslMode=None;";
        private const string connString = "Server=160.153.33.38;Database=familytv_database1;Uid=familyTvOwner;Pwd=familyTvProject;SslMode=None;charset=utf8;";
        string query1 = "SELECT userid FROM UserDevices WHERE device_id = AND user_id = ";
        string query2 = "SELECT image FROM UserPics3 WHERE userid = 12 ";
    
        MySqlConnection conn;
        MySqlCommand command;
        MySqlDataReader dr;
        String DeviceID = "11111";
        //System.Text.EncodingProvider ppp;
        //ppp = System.Text.CodePagesEncodingProvider.Instance;
        //Encoding.RegisterProvider(ppp);
        

        public MainPage()
        {
            this.InitializeComponent();
            ConnectDB();
        }

        private void ClickMe_Click(object sender, RoutedEventArgs e)
        {
            this.HelloMessage.Text = "Hello, Windows IoT Core!";


        }

        public void ConnectDB()
        {
            try {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();            
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //MessageBox.Show(ex.Message);
            }
            String ur = "https://pbs.twimg.com/profile_images/378800000532546226/dbe5f0727b69487016ffd67a6689e75a.jpeg";
            image.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new System.Uri(ur)); 

        }

        public void display()
        {
            command = new MySqlCommand(query, conn);
            byte[] img = (byte[]) command.ExecuteScalar();
            MemoryStream ms = new MemoryStream(img);

          
           // imageView.v
           // ima
           // Image returnImage = Image.FromStream(ms);
        }
    }
}

//https://bytes.com/topic/c-sharp/answers/875257-get-image-sql-put-picture-box
//http://www.c-sharpcorner.com/UploadFile/47548d/how-to-retrieve-data-from-mysql-database-in-C-Sharp/
//http://stackoverflow.com/questions/12131087/display-an-image-stored-in-mysql-databse-in-blob-format-using-c-sharp
// photo album http://www.codeproject.com/Articles/2113/C-Photo-Album-Viewer


//string query = "SELECT image FROM UserPics2 WHERE userid = 12 ";
//command = new MySqlCommand(query, conn);
//adapter2 = new MySqlDataAdapter(command);

//dt = new DataTable();
//adapter2.Fill(dt);


//byte[] img = (byte[])dt.Rows[0][0];
//memStream = new MemoryStream(img);
//pictureBox1.Image = Image.FromStream(memStream);
//            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
