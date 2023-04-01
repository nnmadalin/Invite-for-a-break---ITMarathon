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
    public partial class success : Form
    {
        public success()
        {
            InitializeComponent();
        }
        public static string message = "";

        int k = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            k++;
            if (k == 300)
            {
                this.Close();
            }
            guna2ProgressBar1.Value++;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void success_Load(object sender, EventArgs e)
        {
            label1.Text = message;
        }
    }
}
