using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMarathon.error
{
    public partial class error_auth : Form
    {
        public error_auth()
        {
            InitializeComponent();
        }
        public static string message = "";
        private void error_auth_Load(object sender, EventArgs e)
        {
            label1.Text = message;
        }
        int k = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            k++;
            if(k == 300)
            {
                this.Close();
            }
            guna2ProgressBar1.Value++;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
