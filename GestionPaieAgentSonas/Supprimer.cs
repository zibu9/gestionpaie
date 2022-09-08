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
    public partial class Supprimer : Form
    {
        bool etat;
        Agent agent = new Agent();
        Yesno yesno = new Yesno();
        Connexion connect = new Connexion();
        Effectuer effectuer = new Effectuer();
        Fail fail = new Fail();
        public Supprimer()
        {
            InitializeComponent();
        }

        public void seeA()
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                GroupBox1.Visible = true;

            }
            else
            {
                fail.Fail_text("Ce matricule n\'existe pas");
                fail.ShowDialog();
                searchTxt.Focus();
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (searchTxt.Text == string.Empty)
            {
                fail.Fail_text("Veuillez entrer le matricule");
                fail.ShowDialog();
                searchTxt.Focus();
            }
            else
            {
                seeA();
            }

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
                try
                {
                    yesno.Yesno_text("Voulez vous supprimer cet agent?");
                    yesno.ShowDialog();
                    etat = yesno.test();
                    if (etat == true)
                    {
                        agent.matricule = searchTxt.Text;
                        connect.supp(agent);
                        effectuer.Effectuer_text("Supprimer avec success");
                        effectuer.ShowDialog();
                        GroupBox1.Visible = false;
                    }



                }
                catch (Exception)
                {
                    fail.Fail_text("Erreur inconnue");
                    fail.ShowDialog();
                }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            GroupBox1.Visible = false;
        }
    }
}
