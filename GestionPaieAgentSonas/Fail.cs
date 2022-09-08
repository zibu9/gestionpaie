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
    public partial class Fail : Form
    {
        public Fail()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fail_Load(object sender, EventArgs e)
        {

        }
        public void Fail_text(string text)
        {
            label1.Text = text;
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
