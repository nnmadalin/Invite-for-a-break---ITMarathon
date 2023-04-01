using ITMarathon.error;
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
    public partial class trimite_cerere : UserControl
    {
        public trimite_cerere()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var frm = new persoane();
            frm.ShowDialog();
            label5.Text = "Ai invitat: "+ l +" persoane";
        }
        public static string[] arr = new string[1000];
        public static int l = 0;
        string pers = "";

        private void trimite_cerere_Load(object sender, EventArgs e)
        {

        }

        void make()
        {
            for(int i = 0; i < l; i++)
            {
                if (arr[i][0] == '✨')
                {
                    arr[i].Remove(0, 1);
                    arr[i].Trim();
                }
                pers += (arr[i] + ",");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(l == 0)
            {
                var frm = new error.error_auth();
                error_auth.message = "Adaugati persoane!";
                frm.ShowDialog();
            }
            if(guna2TextBox1.Text.Trim() == "")
            {
                var frm = new error.error_auth();
                error_auth.message = "Completati caseta loc!";
                frm.ShowDialog();
            }
            else
            {
                make();
                SqlCommand cmd = new SqlCommand("insert into cereri (username, interval_st, loc, comentariu, persoane) values (@username, @st, @loc, @comm, @pers)", app.conn);
                cmd.Parameters.Add("@username", app.username);
                cmd.Parameters.Add("@st", dateTimePicker1.Value);
                cmd.Parameters.Add("@loc", guna2TextBox1.Text);
                cmd.Parameters.Add("@comm", guna2TextBox2.Text);
                cmd.Parameters.Add("@pers", pers);
                cmd.ExecuteNonQuery();
                success.message = "Trimis cu succes!";
                var frm = new error.success();
                frm.ShowDialog();
                home.go = "home";
            }
        }
    }
}
