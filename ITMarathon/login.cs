using ITMarathon.error;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ITMarathon
{
    public partial class login : UserControl
    {
        public login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text.Trim() == "" || guna2TextBox2.Text.Trim() == "")
            {
                var frm = new error.error_auth();
                error_auth.message = "Completati toate casetele!";
                frm.ShowDialog();
            }
            else
            {
                var db = new api_db();
                if (db.check(guna2TextBox1.Text, guna2TextBox2.Text) == true)
                {
                    var home = new home();
                    app.username = guna2TextBox1.Text;
                    app.password = guna2TextBox2.Text;

                    app frm = (app)Application.OpenForms["app"];
                    var panel = frm.Controls["guna2Panel1"];

                    db.add_last_connect(app.username, app.password);

                    panel.Controls.Clear();
                    panel.Controls.Add(home);
                    GC.Collect();
                }
                else
                {
                    guna2TextBox2.Text = "";
                    var frm = new error.error_auth();
                    error_auth.message = "Username sau parola gresita!";
                    frm.ShowDialog();
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            app frm = (app)Application.OpenForms["app"];
            var title = frm.Controls["panel_app"].Controls["title_app"];
            title.Text = "Login";
        }
    }
}
