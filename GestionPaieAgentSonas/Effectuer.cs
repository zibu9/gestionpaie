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
    public partial class Effectuer : Form
    {
        public Effectuer()
        {
            InitializeComponent();
        }

        private void Effectuer_Load(object sender, EventArgs e)
        {

        }
        public void Effectuer_text(string text)
        {
            label1.Text = text;
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
