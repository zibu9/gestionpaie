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
    public partial class Yesno : Form
    {
        bool etat = false;
        public Yesno()
        {
            InitializeComponent();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Yesno_Load(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.etat = false;
            this.Close();
        }

        public bool test()
        {
            return this.etat;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.etat = true;
            this.Close();
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            this.etat = true;
            this.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }



        public void Yesno_text(string text)
        {
            label1.Text = text;
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
