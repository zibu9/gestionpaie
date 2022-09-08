using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace GestionPaieAgentSonas
{
    public partial class Home : Form
    {
        bool etat;
        Yesno yesno = new Yesno();
        Effectuer effectuer = new Effectuer();
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form CurrentChildForm;
        private UserControl CurrentUserctrl;

        public Home()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 40);
            panelMenu.Controls.Add(leftBorderBtn);
        }

        private struct RGBcolors
        {
            public static Color color1 = Color.FromArgb(248, 187, 208);/*pink*/
            public static Color color2 = Color.FromArgb(173, 20, 87);/*mauve*/
            public static Color color3 = Color.FromArgb(255, 235, 59);/*jaune*/
            public static Color color4 = Color.FromArgb(0, 200, 81);/*green*/
            public static Color color5 = Color.FromArgb(204, 0, 0);/*red*/
        }

        public void ActivateButton(object senderBtn, Color color)
        {
            DisableButton();
            if (senderBtn != null)
            {
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.Black;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;


                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = Color.White;
            }
        }

        public void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(33, 150, 243);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        public void reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.White;
            LblTitleChildForm.Text = "Home";
        }

        public void si()
        {          
            if (CurrentUserctrl != null)
            {
                CurrentUserctrl.Hide();
            }

            if (CurrentChildForm != null)
            {
                CurrentChildForm.Close();
            }

        }
        public void OpenChildForm(Form ChildForm)
        {
            si();
            panel2.Visible = false;
            pictureBox2.Visible = false;
            CurrentChildForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(ChildForm);
            panelDesktop.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            LblTitleChildForm.Text = ChildForm.Text;
        }

        public void OpenUserctrl(UserControl ChildForm)
        {
            si();
            panel2.Visible = false;
            pictureBox2.Visible = false;
            CurrentUserctrl = ChildForm;
            ChildForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(ChildForm);
            panelDesktop.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            LblTitleChildForm.Text = ChildForm.Name;
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color3);
            panel2.Visible = true;
            pictureBox2.Visible = true;
            si();
            reset();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            
            ActivateButton(sender, RGBcolors.color3);
            OpenChildForm(new Recherche());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color4);
            OpenChildForm(new Ajouter());
            
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color3);
            OpenChildForm(new Modifier());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color5);
            OpenChildForm(new Supprimer());
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color2);
            OpenChildForm(new Liste());
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color4);
            OpenChildForm(new Paie());
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            pictureBox2.Visible = true;
            si();
            reset();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color3);
            Auth auth = new Auth();
            this.Close();
            auth.Show();
        }

        private void opaque_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            etat = yesno.test();
            yesno.Yesno_text("Voulez-vous vraiment fermer le programme ?");
            yesno.ShowDialog();
            if (etat == true)
            {
                Application.Exit();
            }
                
        }
        private void iconButton11_Click_1(object sender, EventArgs e)
        {
            etat = yesno.test();
            yesno.Yesno_text("Voulez-vous vraiment fermer le programme ?");
            yesno.ShowDialog();
            if (etat == true)
            {
                Application.Exit();
            }

        }
    }
}
