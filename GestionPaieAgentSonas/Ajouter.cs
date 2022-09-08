using MySql.Data.MySqlClient;
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
    public partial class Ajouter : Form
    {
        Effectuer effectuer = new Effectuer();
        Fail fail = new Fail();
        Agent agent = new Agent();
        MySqlCommand cmd;
        MySqlDataAdapter cm;
        MySqlDataReader lecteur;
        Connexion connect = new Connexion();
        Home h = new Home();
        OpenFileDialog open = new OpenFileDialog();

        public Ajouter()
        {
            InitializeComponent();
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ajouter_Load(object sender, EventArgs e)
        {

            cmd = connect.getGrade();
            lecteur = cmd.ExecuteReader();
            while (lecteur.Read())
            {
                comboBox7.Items.Add(lecteur[0]);
            }
            lecteur.Close();
            cmd = connect.getAffectation();
            lecteur = cmd.ExecuteReader();
            while (lecteur.Read())
            {
                comboBox6.Items.Add(lecteur[0]);
            }
            lecteur.Close();

            for (int i=0;i < 26; i++)
            {
                comboBox8.Items.Add(i);
            }
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            open.Title = "Selectionner une image ....";
            open.FilterIndex = 1;
            open.Filter = "Uniquement(*.jpg; *jpeg; *.png; *gif; *.bmp;)|*jpg; *.jpeg; *.png; *.gif; *.bmp";
            try
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    if (open.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(open.FileName);
                        
                        pictureBox1.Image = new Bitmap(open.FileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        
                        fail.Fail_text("Veuillez Choisir l'image !!");
                        fail.ShowDialog();
                    }
                        
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string filename = System.IO.Path.GetFileName(open.FileName);
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            System.IO.File.Copy(open.FileName, path + "\\Images\\" + filename);
            
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            if (searchTxt.Text == string.Empty || textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || comboBox1.Text == string.Empty || comboBox2.Text == string.Empty || comboBox3.Text == string.Empty || comboBox4.Text == string.Empty || comboBox5.Text == string.Empty || comboBox6.Text == string.Empty || comboBox7.Text == string.Empty || comboBox8.Text == string.Empty)
            {
                fail.Fail_text("Veuillez remplir tout les champs");
                fail.ShowDialog();
                searchTxt.Focus();

            }
            else
            {
                string photo = "";
                string filename = System.IO.Path.GetFileName(open.FileName);
                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                cm = connect.check(searchTxt.Text);
                DataTable dt = new DataTable();
                cm.Fill(dt);
                if (dt.Rows[0][0].ToString() == "0")
                {
                    try
                    {

                        Random random = new Random();
                        int l = 10;

                        string nom = "IMG-";
                        for (var i = 0; i < l; i++)
                        {
                            nom += ((char)(random.Next(1, 26) + 64)).ToString().ToUpper();
                        }
                        DateTime da = new DateTime();
                        DateTime dat = da.Date;
                        string d = DateTime.Now.ToString("MMddyyyyHHmmss");
                        nom += d;
                        nom += filename;
                        photo = path + "\\Images\\" + nom;
                        System.IO.File.Copy(open.FileName, path + "\\Images\\" + nom);
                        


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    switch (comboBox5.Text)
                    {
                        case "Diplome":
                            agent.id_diplome = 1;
                            break;
                        case "Graduat":
                            agent.id_diplome = 2;
                            break;
                        case "Licence":
                            agent.id_diplome = 3;
                            break;

                    }
                   

                    agent.photo =photo.Replace("\\", "\\\\");
                    cmd = connect.getCodegrade(comboBox7.Text);
                    lecteur = cmd.ExecuteReader();
                    while (lecteur.Read())
                    {
                        agent.code_grade = lecteur[0].ToString();
                    }
                    lecteur.Close();


                    cmd = connect.getCodeAff(comboBox6.Text);
                    lecteur = cmd.ExecuteReader();
                    while (lecteur.Read())
                    {
                        agent.code_aff = lecteur[0].ToString();
                    }
                    lecteur.Close();

                    agent.id += 0;
                    agent.matricule = searchTxt.Text;
                    agent.nom = textBox1.Text;
                    agent.postnom = textBox2.Text;
                    agent.prenom = textBox3.Text;
                    agent.sexe = comboBox1.Text;
                    agent.nationalite = textBox4.Text;
                    agent.Etat_civil = comboBox2.Text;
                    agent.allocation_fam = comboBox4.Text;
                    agent.enfant = comboBox8.Text;
                    agent.verou = comboBox3.Text;
                    agent.supp = "non";
                    connect.InsertAgent(agent);
                    
                    effectuer.Effectuer_text("Ajouter avec success ");
                    effectuer.ShowDialog();
                    initialise();
                }
                else
                {
                    fail.Fail_text("Ce matricule appartient à un autre Agent ");
                    fail.ShowDialog();
                    searchTxt.Focus();
                }
            }

        }

        void initialise()
        {
            searchTxt.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            pictureBox1.Image = global::GestionPaieAgentSonas.Properties.Resources.AUTH_autho;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {

            Liste lst = new Liste();
            lst.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            initialise();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
