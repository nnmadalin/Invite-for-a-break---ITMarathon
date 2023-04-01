using ITMarathon.error;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ITMarathon.uc_home
{
    public partial class profil : UserControl
    {
        public profil()
        {
            InitializeComponent();
        }

        public static string cine = "";

        byte[] imageData = null;

        void load_db()
        {
            SqlCommand cmd = new SqlCommand("SELECT * from users where nume = @cine or prenume = @cine or username = @cine", app.conn);
            cmd.Parameters.Add("@cine", SqlDbType.NVarChar).Value = cine;
            SqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read() != null)
                {
                    if (read["nume"] != DBNull.Value)
                        guna2TextBox1.Text = read["nume"].ToString();
                    if (read["prenume"] != DBNull.Value)
                        guna2TextBox2.Text = read["prenume"].ToString();
                    if (read["username"] != DBNull.Value)
                        guna2TextBox3.Text = read["username"].ToString();
                    if (read["departament"] != DBNull.Value)
                        guna2TextBox4.Text = read["departament"].ToString();
                    if (read["birou"] != DBNull.Value)
                        guna2TextBox5.Text = read["birou"].ToString();
                    if (read["echipa"] != DBNull.Value)
                        guna2TextBox6.Text = read["echipa"].ToString();
                    if (read["etaj"] != DBNull.Value)
                        guna2TextBox7.Text = read["etaj"].ToString();
                    if (File.Exists(Application.StartupPath + @"\assets\foto_avatar\" + guna2TextBox3.Text + ".png"))
                        guna2CirclePictureBox1.Image = Image.FromFile(Application.StartupPath + @"\assets\foto_avatar\" + guna2TextBox3.Text + ".png");
                    if(read["interval_st"] != DBNull.Value)
                        guna2TrackBar2.Value = Convert.ToInt32(read["interval_st"].ToString());
                    else
                        guna2TrackBar2.Value = 0;
                    if (read["interval_dr"] != DBNull.Value)
                        guna2TrackBar1.Value = Convert.ToInt32(read["interval_dr"].ToString());
                    else
                        guna2TrackBar1.Value = 0;
                    load_graph();


                    break;
                }
            }
        }

        void load_me()
        {
            SqlCommand cmd = new SqlCommand("SELECT data from users where username = @me", app.conn);
            cmd.Parameters.Add("@me", app.username);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                read.Read();
                string data = read[0].ToString();
                string[] multiple = data.Split(',');
                for(int i = 0; i < multiple.Length; i++)
                {
                    if (multiple[i] == guna2TextBox3.Text)
                    {
                        guna2Button1.Text = "Sterge de la favorite";
                    }
                }

            }
        }
        void load_graph()
        {
            Bitmap bmp = new Bitmap(660, 30);
            Graphics g = Graphics.FromImage(bmp);


            Pen myPen = new Pen(Color.Red);
            Pen myPen2 = new Pen(Color.Green);
            myPen.Width = 15;
            myPen2.Width = 15;
            g.DrawLine(myPen2, 0, 7, guna2TrackBar2.Value, 7);

            g.DrawLine(myPen, guna2TrackBar2.Value, 7, guna2TrackBar1.Value, 7);
            g.DrawLine(myPen2, guna2TrackBar1.Value, 7, 660, 7);
            guna2PictureBox1.Image = bmp;

            if(guna2TrackBar2.Value % 60 < 10)
                label21.Text = "De la: " + (guna2TrackBar2.Value / 60 + 8).ToString() + ":0" + (guna2TrackBar2.Value % 60).ToString();
            else
                label21.Text = "De la: " + (guna2TrackBar2.Value / 60 + 8).ToString() + ":" + (guna2TrackBar2.Value % 60).ToString();
            if (guna2TrackBar1.Value % 60 < 10)
                label22.Text = "Pana la: " + (guna2TrackBar1.Value / 60 + 8).ToString() + ":0" + (guna2TrackBar1.Value % 60).ToString();
            else
                label22.Text = "Pana la: " + (guna2TrackBar1.Value / 60 + 8).ToString() + ":" + (guna2TrackBar1.Value % 60).ToString();
        }

        private void profil_Load(object sender, EventArgs e)
        {
            guna2TextBox3.Text = app.username;
            if (cine == app.username)
            {
                guna2TextBox1.ReadOnly = false;
                guna2TextBox2.ReadOnly = false;
                guna2TextBox4.ReadOnly = false;
                guna2TextBox5.ReadOnly = false;
                guna2TextBox6.ReadOnly = false;
                guna2TextBox7.ReadOnly = false;
                guna2Button1.Visible = false;
                guna2Button2.Visible = true;
                guna2Button3.Visible = true;
                guna2Button4.Visible = true;
                guna2TrackBar1.Visible = true;
                guna2TrackBar2.Visible = true;
            }
            else
            {
                guna2TextBox1.ReadOnly = true;
                guna2TextBox2.ReadOnly = true;
                guna2TextBox3.ReadOnly = true;
                guna2TextBox4.ReadOnly = true;
                guna2TextBox5.ReadOnly = true;
                guna2TextBox6.ReadOnly = true;
                guna2TextBox7.ReadOnly = true;
                guna2Button1.Visible = true;
                guna2Button2.Visible = false;
                guna2Button3.Visible = false;
                guna2Button4.Visible = false;
                guna2TrackBar1.Visible = false;
                guna2TrackBar2.Visible = false;
            }

            load_db();
            load_me();
            load_graph();
        }
        string fileurl;
       

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            
            
            if (cine == app.username)
            {
                openFileDialog1.FileName = "";
                openFileDialog1.DefaultExt = "Files|*.jpg;*.jpeg;*.png";
                openFileDialog1.Filter = "Files|*.jpg;*.jpeg;*.png";
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                DialogResult dialog =  openFileDialog1.ShowDialog();
                if(dialog == DialogResult.OK)
                {
                    //pregateste foto;
                    guna2CirclePictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    fileurl = openFileDialog1.FileName;
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            api_db db = new api_db();
            SqlCommand cmd;
            if (db.in_db(app.username) == true)
            {
                    cmd = new SqlCommand("UPDATE users set [nume] = @nume, [prenume] = @prenume, [departament] = @departament, [birou] = @birou, [echipa] = @echipa, [etaj] = @etaj where username = @brutusername", app.conn);
                    cmd.Parameters.Add("@nume", SqlDbType.NVarChar).Value = guna2TextBox1.Text;
                    cmd.Parameters.Add("@prenume", SqlDbType.NVarChar).Value = guna2TextBox2.Text;
                    cmd.Parameters.Add("@departament", SqlDbType.NVarChar).Value = guna2TextBox4.Text;
                    cmd.Parameters.Add("@birou", SqlDbType.NVarChar).Value = guna2TextBox5.Text;
                    cmd.Parameters.Add("@echipa", SqlDbType.NVarChar).Value = guna2TextBox6.Text;
                    cmd.Parameters.Add("@etaj", SqlDbType.NVarChar).Value = guna2TextBox7.Text;
                    cmd.Parameters.Add("@brutusername", SqlDbType.NVarChar).Value = app.username;

                try
                {
                    if (File.Exists(Application.StartupPath + @"\assets\foto_avatar\" + app.username + ".png"))
                    {
                        File.Delete(Application.StartupPath + @"\assets\foto_avatar\" + app.username + ".png");
                    }
                    guna2CirclePictureBox1.Image.Save(Application.StartupPath + @"\assets\foto_avatar\" + app.username + ".png");
                }
                catch { };

                cmd.ExecuteNonQuery();
                success.message = "Salvat cu succes!";
                var frm = new error.success();
                frm.ShowDialog();
            }
            else
            {
                ///insert
                    cmd = new SqlCommand("insert into users ([nume], [prenume], [username], [departament], [birou], [echipa], [etaj]) values (@nume, @prenume, @username, @departament, @nume_birou, @nume_echipa, @etaj)", app.conn);
                    cmd.Parameters.Add("nume", guna2TextBox1.Text);
                    cmd.Parameters.Add("prenume", guna2TextBox2.Text);
                    cmd.Parameters.Add("username", guna2TextBox3.Text);
                    cmd.Parameters.Add("departament", guna2TextBox4.Text);
                    cmd.Parameters.Add("nume_birou", guna2TextBox5.Text);
                    cmd.Parameters.Add("nume_echipa", guna2TextBox6.Text);
                    cmd.Parameters.Add("etaj", guna2TextBox7.Text);
                try
                {
                    if (File.Exists(Application.StartupPath + @"\assets\foto_avatar\" + app.username + ".png"))
                    {
                        File.Delete(Application.StartupPath + @"\assets\foto_avatar\" + app.username + ".png");
                    }
                    guna2CirclePictureBox1.Image.Save(Application.StartupPath + @"\assets\foto_avatar\" + app.username + ".png");
                }
                catch { };
                cmd.ExecuteNonQuery();
                success.message = "Salvat cu succes!";
                var frm = new error.success();
                frm.ShowDialog();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2Button1.Text == "Adauga la favorite")
            {
                SqlCommand cmd = new SqlCommand("select data from users where username = @user", app.conn);
                cmd.Parameters.Add("@user", app.username);
                SqlDataReader read = cmd.ExecuteReader();
                string str = "";
                if (read.Read() != null)
                {
                    str = read[0].ToString();
                    str += (guna2TextBox3.Text + ",");
                }

                cmd = new SqlCommand("update users set [data] = @data where username = @user", app.conn);
                cmd.Parameters.Add("@data", str);
                cmd.Parameters.Add("@user", app.username);
                cmd.ExecuteNonQuery();

                success.message = "Adaugat cu succes!";
                var frm = new error.success();
                frm.ShowDialog();

                guna2Button1.Text = "Sterge de la favorite";
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select data from users where username = @user", app.conn);
                cmd.Parameters.Add("@user", app.username);
                SqlDataReader read = cmd.ExecuteReader();
                string str = "", final = "";
                string[] multiple;
                if (read.Read() != null)
                {
                    str = read[0].ToString();
                }

                multiple = str.Split(',');
                for (int i = 0; i < multiple.Length; i++)
                {
                    if (multiple[i] != guna2TextBox3.Text)
                    {
                        final += multiple[i];
                        final += ",";
                    }
                }

                Console.WriteLine(final);


                cmd = new SqlCommand("update users set [data] = @data where username = @user", app.conn);
                cmd.Parameters.Add("@data", final);
                cmd.Parameters.Add("@user", app.username);
                cmd.ExecuteNonQuery();

                success.message = "Adaugat cu succes!";
                var frm = new error.success();
                frm.ShowDialog();

                guna2Button1.Text = "Adauga la favorite";
            }
        }

        

        private void guna2TrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if(guna2TrackBar2.Value > guna2TrackBar1.Value)
            {
                guna2TrackBar2.Value = guna2TrackBar1.Value;
            }
            load_graph();
        }

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (guna2TrackBar1.Value < guna2TrackBar2.Value)
            {
                guna2TrackBar1.Value = guna2TrackBar2.Value;
            }
            load_graph();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update users SET interval_st = 0,  interval_dr = 0 where username = @user", app.conn);
            cmd.Parameters.Add("@user", app.username);
            cmd.ExecuteNonQuery();
            success.message = "Interval sters cu succes!";
            var frm = new error.success();
            frm.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update users SET interval_st = @st,  interval_dr = @dr where username = @user", app.conn);
            cmd.Parameters.Add("@st", guna2TrackBar2.Value);
            cmd.Parameters.Add("@dr", guna2TrackBar1.Value);
            cmd.Parameters.Add("@user", app.username);
            cmd.ExecuteNonQuery();
            success.message = "Interval adaugat cu succes!";
            var frm = new error.success();
            frm.ShowDialog();
        }
    }
}
