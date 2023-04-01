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
    public partial class cereri : UserControl
    {
        public cereri()
        {
            InitializeComponent();
        }

        bool check(string x)
        {
            string[] lines = x.Split(',');
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == app.username)
                {
                    return true;
                }
            }
            return false;
        }

        private void cereri_Load(object sender, EventArgs e)
        {
            int k = 0;
            SqlCommand cmd = new SqlCommand("select * from cereri", app.conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (check(read["persoane"].ToString()) == true || read["username"].ToString() == app.username)
                {
                    guna2DataGridView1.Rows.Insert(k++, read["id"].ToString(), read["username"].ToString(), read["interval_st"].ToString(), read["loc"].ToString(), read["comentariu"].ToString());
                }
            }
        }
        public static string id, pers;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int row = e.RowIndex;
                if(e.ColumnIndex == 5)
                {
                    SqlCommand cmd = new SqlCommand("insert into cereri_true([id_cerere], [username], [true]) values (@id, @user, @true)", app.conn);
                    cmd.Parameters.Add("@id", guna2DataGridView1.Rows[row].Cells[0].Value.ToString());
                    cmd.Parameters.Add("@user", app.username);
                    cmd.Parameters.Add("@true", "true");
                    cmd.ExecuteNonQuery();
                    success.message = "Trimis cu succes!";
                    var frm = new error.success();
                    frm.ShowDialog();
                    home.go = "home";
                }
                else if(e.ColumnIndex == 6)
                {
                    SqlCommand cmd = new SqlCommand("insert into cereri_true([id_cerere], [username], [true]) values (@id, @user, @true)", app.conn);
                    cmd.Parameters.Add("@id", guna2DataGridView1.Rows[row].Cells[0].Value.ToString());
                    cmd.Parameters.Add("@user", app.username);
                    cmd.Parameters.Add("@true", "no");
                    cmd.ExecuteNonQuery();
                    success.message = "Trimis cu succes!";
                    var frm = new error.success();
                    frm.ShowDialog();
                    home.go = "home";
                }
                else if(e.ColumnIndex == 7)
                {
                    id = guna2DataGridView1.Rows[row].Cells[0].Value.ToString();
                    var frm = new show_pers();
                    frm.Show();
                }
            }
        }
    }
}
