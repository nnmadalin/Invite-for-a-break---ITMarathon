using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMarathon.uc_home
{
    public partial class show_pers : Form
    {
        public show_pers()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string find_username(string x)
        {
            
            SqlCommand cmd = new SqlCommand("select * from users where username = @nume", app.conn);
            cmd.Parameters.Add("@nume", x);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                if (read.Read())
                {
                    return read["nume"].ToString() + " " + read["prenume"].ToString();
                }
            }
            return "";
        }

        int status(string x, string id)
        {
            SqlCommand cmd = new SqlCommand("select * from cereri_true where id_cerere = @id", app.conn);
            cmd.Parameters.Add("@id", id);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                
                if (find_username(read["username"].ToString()) == x)
                {
                    if (read["true"].ToString() == "true")
                        return 1;
                    else if (read["true"].ToString() == "no")
                        return 0;
                }
            }
            
            return -1;
        }

        private void show_pers_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from cereri where id = @id", app.conn);
            cmd.Parameters.Add("@id", cereri.id);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                string pers = read["persoane"].ToString();
                string[] x = pers.Split(',');
                for(int i = 0; i < x.Length; i++)
                {
                    if (x[i].Trim() != "")
                    {
                        int v = status(x[i], cereri.id);
                        if (v == 0)
                            listBox1.Items.Add(x[i] + "  -  refuzat ");
                        else if (v == 1)
                            listBox1.Items.Add(x[i] + "  -  acceptat  ");
                        else
                            listBox1.Items.Add(x[i] + "  -  în așteptare  ");
                    }
                }
            }
        }
    }
}
