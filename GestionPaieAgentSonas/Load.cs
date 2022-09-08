using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPaieAgentSonas
{
    public partial class Load : Form
    {
        int i = 0;
        public Load()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i += 1;
            prgrsbar.Value = i;
            if(prgrsbar.Value == 100)
            {
                timer1.Stop();
                Auth a = new Auth();
                this.Hide();
                a.Show();
            }

        }

        private void Load_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 40;
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
