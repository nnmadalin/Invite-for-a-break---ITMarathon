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
    public partial class persoane : Form
    {
        public persoane()
        {
            InitializeComponent();
        }

        void load_ant()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                for (int j = 0; j < trimite_cerere.l; j++)
                {
                    if (checkedListBox1.Items[i].ToString() == trimite_cerere.arr[j])
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }

            
        }

        private void persoane_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            

            api_db db = new api_db();
            SqlCommand cmd = new SqlCommand("SELECT data from users where username = @me", app.conn);
            cmd.Parameters.Add("@me", app.username);
            SqlDataReader read = cmd.ExecuteReader();
            string[] multiple = new string[1000];
            if (read.HasRows)
            {
                read.Read();
                string data = read[0].ToString();
                if (data.Trim() != "")
                {
                    multiple = data.Split(',');

                    Array.Sort(multiple);

                    for (int i = 0; i < multiple.Length; i++)
                    {
                        if (multiple[i].Trim() != "")
                        {
                            checkedListBox1.Items.Add("✨" + db.name_get(multiple[i]));
                        }
                    }
                }
            }
            cmd = new SqlCommand("SELECT * from users order by [nume] ASC", app.conn);
            cmd.Parameters.Add("@me", app.username);
            read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    bool ok = false;
                    for (int i = 0; i < multiple.Length; i++)
                    {
                        if (read["username"].ToString() == multiple[i])
                        {
                            ok = true;
                        }
                    }
                    if (ok == false)
                    {
                        checkedListBox1.Items.Add(read["nume"].ToString() + " " + read["prenume"]);
                    }

                }
            }
            load_ant();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int k = 0;
            for(int i = 0; i< checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i) == true)
                {
                    trimite_cerere.arr[k++] = checkedListBox1.Items[i].ToString();
                    trimite_cerere.l = k;
                }
            }
            this.Close();
        }
    }
}
