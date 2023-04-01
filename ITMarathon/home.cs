using ITMarathon.error;
using ITMarathon.uc_home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMarathon
{
    public partial class home : UserControl
    {
        public home()
        {
            InitializeComponent();
        }

        private void home_Load(object sender, EventArgs e)
        {
            app frm = (app)Application.OpenForms["app"];
            var title = frm.Controls["panel_app"].Controls["title_app"];
            title.Text = "Home";
            var init = new uc_home.initial();
            guna2Panel2.Controls.Add(init);
            timer1.Start();
        }
        

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            var db = new api_db();
            db.logout(app.username, app.password);
            app frm = (app)Application.OpenForms["app"];
            var panel = frm.Controls["guna2Panel1"];
            panel.Controls.Clear();

            var login = new login();
            panel.Controls.Add(login);
            GC.Collect();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            profil.cine = app.username;
            var init = new uc_home.profil();
            guna2Panel2.Controls.Clear();
            guna2Panel2.Controls.Add(init);
            app frm = (app)Application.OpenForms["app"];
            var title = frm.Controls["panel_app"].Controls["title_app"];
            title.Text = "Profil";
        }
        public static string go = "";

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            api_db db = new api_db();
            if (db.in_db(app.username) == false)
            {
                error_auth.message = "Inca nu ai configurat profilul!";
                var er = new error.error_auth();
                er.ShowDialog();
                app forum = (app)Application.OpenForms["app"];
                var tit = forum.Controls["panel_app"].Controls["title_app"];
                tit.Text = "Profil";
                profil.cine = app.username;
                var initi = new uc_home.profil();
                guna2Panel2.Controls.Clear();
                guna2Panel2.Controls.Add(initi);
            }
            else
            {
                var init = new uc_home.initial();
                guna2Panel2.Controls.Clear();
                guna2Panel2.Controls.Add(init);
                app frm = (app)Application.OpenForms["app"];
                var title = frm.Controls["panel_app"].Controls["title_app"];
                title.Text = "Home";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            api_db db = new api_db();
            timer1.Stop();
            if (db.in_db(app.username) == true)
            {
                ///cauta in db;
            }
            else
            {
                error_auth.message = "Inca nu ai configurat profilul!";
                var er = new error.error_auth();
                er.ShowDialog();
                app forum = (app)Application.OpenForms["app"];
                var tit = forum.Controls["panel_app"].Controls["title_app"];
                tit.Text = "Profil";
                profil.cine = app.username;
                var initi = new uc_home.profil();
                guna2Panel2.Controls.Clear();
                guna2Panel2.Controls.Add(initi);
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(go == "profil")
            {
                go = "";
                var initi = new uc_home.profil();
                guna2Panel2.Controls.Clear();
                guna2Panel2.Controls.Add(initi);
            }
            else if(go == "home")
            {
                go = "";
                var initi = new uc_home.initial();
                guna2Panel2.Controls.Clear();
                guna2Panel2.Controls.Add(initi);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var init = new uc_home.trimite_cerere();
            guna2Panel2.Controls.Clear();
            guna2Panel2.Controls.Add(init);
            app frm = (app)Application.OpenForms["app"];
            var title = frm.Controls["panel_app"].Controls["title_app"];
            title.Text = "Trimite cerere";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var init = new uc_home.cereri();
            guna2Panel2.Controls.Clear();
            guna2Panel2.Controls.Add(init);
            app frm = (app)Application.OpenForms["app"];
            var title = frm.Controls["panel_app"].Controls["title_app"];
            title.Text = "Cereri";
        }
    }
}
