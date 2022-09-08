using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace GestionPaieAgentSonas
{

    public partial class Auth : Form
    {
        MySqlDataAdapter cmd;
        Connexion connect = new Connexion();
       
        public Auth()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Task ProcessData(List<String> list, IProgress<Progress> progresse)
        {
            int i = 1;
            int totalProcess = list.Count;
            var progress = new Progress();
            return Task.Run(() =>
            {
                for(int j = 0; j < totalProcess; j++)
                {
                    progress.Complete = i++ * 100 / totalProcess;
                    progresse.Report(progress);
                    Thread.Sleep(2);
                }
            });
        }

        private async  void iconButton2_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text == string.Empty || passwordTxt.Text == string.Empty)
            {
                lbl.Visible = true;
                lbl.ForeColor = Color.Red;
                lbl.Text = "remplissez tout les champs";
                usernameTxt.Focus();
            }
            else 
            {
                
                
                lbl.ForeColor = System.Drawing.Color.FromArgb(33, 150, 243);
                string usn = usernameTxt.Text;
                string pwd = passwordTxt.Text;
                lbl.Visible = true;
                iconButton2.Enabled = false;

                cmd = connect.getadmin(usn, pwd);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    List<string> list = new List<string>();
                    for (int i = 0; i < 200; i++)
                    {
                        list.Add(i.ToString());
                    }
                    prgrsBar.Visible = true;
                    lbl.Text = "connexion en cours ...";
                    var progresse = new Progress<Progress>();
                    progresse.ProgressChanged += (o, report) =>
                        {
                            lbl.Text = String.Format("Connexion...{0}%", report.Complete);
                            prgrsBar.Value = report.Complete;
                            prgrsBar.Update();
                        };
                    await ProcessData(list, progresse);
                    lbl.Text = "connecté";
                    Home hm = new Home();
                    this.Hide();
                    hm.Show();
                    lbl.Text = "bien";
                }
                else
                {
                    lbl.ForeColor = Color.Red;
                    lbl.Text = "indentifiants incorrect";
                    usernameTxt.Text = "";
                    passwordTxt.Text = "";
                    iconButton2.Enabled = true;
                }

            }
       

        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            this.passwordTxt.PasswordChar = '\0';
            iconPictureBox8.Visible = true;
            iconPictureBox7.Visible = false;
        }

        private void iconPictureBox8_Click(object sender, EventArgs e)
        {
            this.passwordTxt.PasswordChar = '*';
            iconPictureBox7.Visible = true;
            iconPictureBox8.Visible = false;
        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {
            iconPictureBox7.Visible = true;
        }
    }
}
