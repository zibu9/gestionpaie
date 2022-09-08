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
    public partial class Modifier : Form
    {
        Effectuer effectuer = new Effectuer();
        Fail fail = new Fail();
        OpenFileDialog open = new OpenFileDialog();
        Agent agent = new Agent();
        Connexion connect = new Connexion();
        MySqlCommand cmd;
        MySqlDataReader lecteur;
        string img = "";
        public Modifier()
        {
            agent.photo = "";
            InitializeComponent();
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
                        agent.photo = pictureBox1.Image.ToString();
                    }

                }
            }
            catch (Exception)
            {
                fail.Fail_text("un probleme est survenu!!");
                fail.ShowDialog();
            }
            string photo = "";
            string filename = System.IO.Path.GetFileName(open.FileName);
            string pat = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
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
                photo = pat + "\\Images\\" + nom;
                System.IO.File.Copy(open.FileName, pat + "\\Images\\" + nom);
                agent.photo = photo.Replace("\\", "\\\\");

            }

            catch (Exception)
            {
                fail.Fail_text("aucune photo n\'est selectionné");
                fail.ShowDialog();
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (searchTxt.Text == string.Empty)
            {
                fail.Fail_text("entrer le matricule");
                fail.ShowDialog();
                searchTxt.Focus();
            }
            else
            {
                initAgent();
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

        public void initAgent()
        {
            MySqlDataAdapter cm = connect.check(searchTxt.Text);
            DataTable dt = new DataTable();
            cm.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                try
                {
                    agent.matricule = searchTxt.Text;
                    MySqlCommand cmd = connect.selectA(agent);
                    MySqlDataReader d;
                    d = cmd.ExecuteReader();
                    while (d.Read())
                    {
                        agent.id = d.GetValue(0).ToString();
                        searchTxt.Text = d.GetValue(1).ToString();
                        textBox1.Text = d.GetValue(2).ToString();
                        textBox2.Text = d.GetValue(3).ToString();
                        textBox3.Text = d.GetValue(4).ToString();
                        comboBox1.Text = d.GetValue(5).ToString();
                        textBox4.Text = d.GetValue(6).ToString();
                        comboBox2.Text = d.GetValue(7).ToString();
                        comboBox5.Text = d.GetValue(18).ToString();
                        comboBox7.Text = d.GetValue(16).ToString();
                        comboBox4.Text = d.GetValue(10).ToString();
                        comboBox8.Text = d.GetValue(11).ToString();
                        comboBox3.Text = d.GetValue(12).ToString();
                        comboBox6.Text = d.GetValue(17).ToString();
                        img = d.GetValue(15).ToString();
                        FileStream fs = new FileStream(@d.GetValue(15).ToString(), FileMode.Open);
                        pictureBox1.Image = Image.FromStream(fs);
                        fs.Close();
                       
                    }
                    d.Close();


                }
                catch (Exception)
                {
                    fail.Fail_text("Echec une erreur est survenu");
                    fail.ShowDialog();
                }

                panel3.Visible = true;

            }
            else
            {
                fail.Fail_text("Ce matricule n\'existe pas ou deja \nsupprime ");

                fail.ShowDialog();
                initialise();
                searchTxt.Focus();
            }
        }


        private void iconButton5_Click(object sender, EventArgs e)
        {
            Liste ls = new Liste();
            ls.ShowDialog();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            initAgent();
        }

        private void Modifier_Load(object sender, EventArgs e)
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

            for (int i = 0; i < 26; i++)
            {
                comboBox8.Items.Add(i);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (searchTxt.Text == string.Empty || textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || comboBox1.Text == string.Empty || comboBox2.Text == string.Empty || comboBox3.Text == string.Empty || comboBox4.Text == string.Empty || comboBox5.Text == string.Empty || comboBox6.Text == string.Empty || comboBox7.Text == string.Empty || comboBox8.Text == string.Empty)
            {
                Fail fail = new Fail();
                fail.Fail_text("Veuillez remplir tout les champs de saisie  !!");
                fail.ShowDialog();
                searchTxt.Focus();

            }
            else
            {

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
                    cmd = connect.getCodegrade(comboBox7.Text);
                    lecteur = cmd.ExecuteReader();
                    while (lecteur.Read())
                    {
                        agent.code_grade = lecteur[0].ToString();
                        
                    } lecteur.Close();
                    


                    cmd = connect.getCodeAff(comboBox6.Text);
                    lecteur = cmd.ExecuteReader();
                    while (lecteur.Read())
                    {
                        agent.code_aff = lecteur[0].ToString();
                        
                    }lecteur.Close();
                     
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
                    if(agent.photo == string.Empty)
                    {
                        agent.photo = img.Replace("\\", "\\\\");
                    }
                    connect.Update(agent);
                    effectuer.Effectuer_text("Modifier avec success");
                    effectuer.ShowDialog();
                    initAgent();
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
