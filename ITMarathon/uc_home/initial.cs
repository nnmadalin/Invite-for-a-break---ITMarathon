using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ITMarathon.uc_home
{
    public partial class initial : UserControl
    {
        public initial()
        {
            InitializeComponent();
        }

        private void initial_Load(object sender, EventArgs e)
        {
            label1.Text = "Salut, " + app.username;
            api_db db = new api_db();
            if (File.Exists(Application.StartupPath + @"\assets\foto_avatar\" + app.username + ".png"))
                guna2CirclePictureBox1.Image = Image.FromFile(Application.StartupPath + @"\assets\foto_avatar\" + app.username + ".png");

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string cautat = "";
            listBox1.Items.Clear();
            if (guna2TextBox1.Text.Trim() != "")
            {
                
                SqlCommand cmd = new SqlCommand("SELECT * from users ", app.conn);
               
                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows)
                {
                    listBox1.Items.Clear();
                    cautat = guna2TextBox1.Text.ToLower();

                    while (read.Read())
                    {
                        if (read["nume"].ToString().ToLower().Contains(cautat) == true || read["prenume"].ToString().ToLower().Contains(cautat) == true || read["username"].ToString().ToLower().Contains(cautat) == true)
                        {
                            listBox1.Visible = true;
                            listBox1.Items.Add(read["nume"].ToString() + " " + read["prenume"].ToString() + " (" + read["username"].ToString() + ")");
                        }
                        
                    }
                }
                else
                    listBox1.Visible = false;
            }
            else
                listBox1.Visible = false;

        }

        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int startPoint = listBox1.GetItemText(listBox1.SelectedItem).IndexOf("(") + "(".Length;
            int endPOint = listBox1.GetItemText(listBox1.SelectedItem).LastIndexOf(")");

            if (listBox1.SelectedIndex < listBox1.Items.Count && listBox1.SelectedIndex > -1)
            {
                String result = listBox1.GetItemText(listBox1.SelectedItem).Substring(startPoint, endPOint - startPoint);
                profil.cine = result;
                app forum = (app)Application.OpenForms["app"];
                home.go = "profil";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
