using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPaieAgentSonas
{
    public partial class Recherche : Form
    {
        Effectuer effectuer = new Effectuer();
        Fail fail = new Fail();
        Connexion connect = new Connexion();

        public Recherche()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GroupBox1.Visible = false;
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            GroupBox1.Visible = true;
        }

        private void iconPictureBox1_Click_1(object sender, EventArgs e)
        {
            MySqlDataAdapter cm = connect.check(searchTxt.Text);
            DataTable dt = new DataTable();
            cm.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                try
                {
                    MySqlCommand cmd = connect.search(searchTxt.Text);
                    MySqlDataReader d;
                    d = cmd.ExecuteReader();
                    while (d.Read())
                    {
                        lblNom.Text = d.GetValue(0).ToString();
                        lblPostnom.Text = d.GetValue(1).ToString();
                        lblPrenom.Text = d.GetValue(2).ToString();
                        lblSexe.Text = d.GetValue(3).ToString();
                        lbletatciv.Text = d.GetValue(4).ToString();
                        FileStream fs = new FileStream(@d.GetValue(5).ToString(), FileMode.Open);
                        pictureBox1.Image = Image.FromStream(fs);
                        fs.Close();


                    }
                    d.Close();

                }
                catch (Exception)
                {
                    fail.Fail_text("une erreur est survenue");
                    fail.ShowDialog();
                }

                GroupBox1.Visible = true;

            }
            else
            {
                fail.Fail_text("Ce matricule n\'existe pas ");
                fail.ShowDialog();
                searchTxt.Focus();
            }

           
        }

        private void Recherche_Load(object sender, EventArgs e)
        {

        }
    }
}
