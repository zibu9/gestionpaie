using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPaieAgentSonas
{
    class Connexion
    {
        Fail fail = new Fail();
        MySqlConnection con;
        MySqlCommand com;
        MySqlDataAdapter cmd;
        public Connexion()
        {
            try
            {
                 con = new MySqlConnection("server=127.0.0.1;user id=root;database=sonas");
                 con.Open();
            }catch(Exception)
            {
                fail.Fail_text("connexion impossible verifier votre \n connexion");
                fail.ShowDialog();
                Application.Exit();

            }
       
        }

        public void Klose()
        {
            con.Close();
        }
        public MySqlDataAdapter getadmin(string usn, string pwd)
        {
            cmd = new MySqlDataAdapter("select count(*) from admin where username ='" + usn + "' and password = '" + pwd + "'", con);
            return cmd;
        }

        public MySqlCommand PaieA()
        {
            com = new MySqlCommand("SELECT agent.id, agent.supp, agent.matricule, agent.code_grade, agent.code_Aff, agent.Allocation_fam, agent.enfant,diplome.prime as primeDiplome,grade.salaire_ba as salaire,grade.indeminites_logement as indeminites,grade.allocation_familliale AS allocations,grade.nom AS grade,affectation.nom as affectation, agent.nom, agent.postnom, agent.prenom FROM `agent` LEFT JOIN diplome ON(agent.id_diplome = diplome.id) LEFT JOIN grade ON(agent.code_grade = grade.code)LEFT JOIN affectation ON(agent.code_aff = affectation.codeAff) GROUP BY agent.id HAVING(agent.supp = 'non')", con);
            return com;
        }

        string paieall = "zibu@Kabuya1999 SELECT agent.id, agent.supp, agent.matricule, agent.code_grade, agent.code_Aff, agent.Allocation_fam, agent.enfant,diplome.prime as primeDiplome,grade.salaire_ba as salaire,grade.indeminites_logement as indeminites,grade.allocation_familliale AS allocations,grade.nom AS grade,affectation.nom as affectation FROM `agent` LEFT JOIN diplome ON(agent.id_diplome = diplome.id) LEFT JOIN grade ON(agent.code_grade = grade.code)LEFT JOIN affectation ON(agent.code_aff = affectation.codeAff) GROUP BY agent.id HAVING(agent.supp='non')";

        public MySqlDataAdapter check(string matricule)
        {
            cmd = new MySqlDataAdapter("select count(*) from agent where matricule ='" + matricule  + "'AND supp='non'", con);
            return cmd;
        }

        public MySqlCommand getAffectation()
        {
            com = new MySqlCommand("select nom from Affectation where id < 100",con);
            return com;
        }

        public MySqlCommand getGrade()
        {
            com = new MySqlCommand("select nom from grade where id < 100", con);
            return com;
        }

        public MySqlCommand getCodegrade(string grade)
        {
            com = new MySqlCommand("select code from grade where nom = '" + grade + "'",con);
            return com;
        }

        public MySqlCommand getCodeAff(string aff)
        {
            com = new MySqlCommand("select codeAff from affectation where nom = '" + aff + "'", con);
            return com;
        }

        public void InsertAgent(Agent agent)
        {
            com = new MySqlCommand("insert into agent values('" + agent.id + "','" + agent.matricule + "','" + agent.nom + "','" + agent.postnom + "','" + agent.prenom + "','" + agent.sexe + "','" + agent.nationalite + "','" + agent.Etat_civil + "','" + agent.id_diplome + "','" + agent.code_grade + "','" + agent.allocation_fam + "','" + agent.enfant + "','" + agent.verou + "','" + agent.code_aff + "','" + agent.supp + "' ,\"" + agent.photo + "\" )", con);
            com.ExecuteNonQuery();
        }

        public MySqlCommand getLastinsertAgent()
        {
            com = new MySqlCommand("select nom, postnom, prenom, matricule, sexe from agent where id = (select(max(id)) FROM agent) and supp = 'non'", con);
            return com;
        }

        public MySqlCommand select()
        {
            com = new MySqlCommand("select nom, postnom, prenom, matricule, sexe from agent where supp='non'", con);
            return com;
        }

        public MySqlCommand selectA(Agent agent)
        {
            com = new MySqlCommand("SELECT agent.*,grade.nom AS grade,affectation.nom AS affectation,diplome.nom AS diplome FROM `agent` LEFT JOIN grade ON(agent.code_grade = grade.code) LEFT JOIN affectation ON (agent.code_aff = affectation.codeAff) LEFT JOIN diplome ON (agent.id_diplome = diplome.id) GROUP BY agent.id HAVING agent.matricule = '" + agent.matricule+"'AND supp='non'", con);
            return com;
        }

        public MySqlCommand search(string matricule)
        {
            com = new MySqlCommand("select nom, postnom, prenom, sexe, Etat_civil,photo from agent where matricule = '" + matricule + "' and supp = 'non'", con);
            return com;
        }

        public void Delete(Agent agent)
        {
            com = new MySqlCommand(" DELETE FROM agent where (matricule='" + agent.matricule +"'AND supp='non')" , con);
            com.ExecuteNonQuery();
        }

        public void supp(Agent agent)
        {
            com = new MySqlCommand(" UPDATE agent set supp = 'oui' where matricule=" + agent.matricule, con);
            com.ExecuteNonQuery();
        }

        public void Update(Agent agent)
        {
            com = new MySqlCommand("UPDATE agent SET nom = '" + agent.nom + "', postnom = '" + agent.postnom + "', prenom = '" + agent.prenom + "',sexe= '" + agent.sexe + "', nationalite = '" + agent.nationalite + "',Etat_civil = '" + agent.Etat_civil + "', id_diplome ='" + agent.id_diplome + "',code_grade = '" + agent.code_grade + "',allocation_fam = '" + agent.allocation_fam + "',enfant = '" + agent.enfant + "',verou = '" + agent.verou + "',code_aff='" + agent.code_aff + "',photo = '" + agent.photo + "' WHERE matricule = '"+agent.matricule+"'",con);
            com.ExecuteNonQuery();
        }


    }
}
