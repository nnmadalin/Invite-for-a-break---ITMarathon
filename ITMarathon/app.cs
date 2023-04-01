using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMarathon
{
    public partial class app : Form
    {
        public app()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessge(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        
        public static string dbstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\assets\database.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
        public static SqlConnection conn = new SqlConnection(dbstring);
        public static string username, password;

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(1);
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void app_Load(object sender, EventArgs e)
        {            
            var db = new api_db();
            db.start_db();

            db.last_connect();
            if(api_db.user.Trim() == "" || api_db.password.Trim() == "")
            {
                var urs = new login();
                guna2Panel1.Controls.Clear();
                guna2Panel1.Controls.Add(urs);
                GC.Collect();
            }
            else
            {
                
                if (db.session(api_db.user, api_db.password) == true)
                {
                    var home = new home();
                    username = api_db.user;
                    password = api_db.password;
                    guna2Panel1.Controls.Clear();
                    guna2Panel1.Controls.Add(home);
                    GC.Collect();
                    
                }
                else
                {
                    var urs = new login();
                    guna2Panel1.Controls.Clear();
                    guna2Panel1.Controls.Add(urs);
                    GC.Collect();
                }
            }
            
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessge(this.Handle, 0x112, 0xf012, 0);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
