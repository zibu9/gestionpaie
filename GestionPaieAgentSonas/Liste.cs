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
    public partial class Liste : Form
    {
        Fail fail = new Fail();
        Connexion connect = new Connexion();
        public Liste()
        {
            InitializeComponent();
        }

        private void Liste_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = connect.getLastinsertAgent();
                MySqlDataReader d;
                d = cmd.ExecuteReader();
                while (d.Read())
                {
                    gunaDataGridView1.Rows.Add(d.GetValue(0), d.GetValue(1), d.GetValue(2), d.GetValue(3), d.GetValue(4));
                }
                d.Close();
            }
            catch(Exception)
            {
                fail.Fail_text("Erreur");
                fail.ShowDialog();
            }
            Donnees();
            
        }

        public void Donnees()
        {
            try
            {
                MySqlCommand cmd = connect.select();
                MySqlDataReader d;
                d = cmd.ExecuteReader();
                int n = 1;
                while (d.Read())
                {
                    gunaDataGridView2.Rows.Add(n, d.GetValue(0), d.GetValue(1), d.GetValue(2), d.GetValue(3), d.GetValue(4));
                    n++;
                }
                d.Close();
            }
            catch (Exception)
            {
                fail.Fail_text("Erreur");
                fail.ShowDialog();
            }
        }
    }
}
