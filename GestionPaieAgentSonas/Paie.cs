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
    public partial class Paie : Form
    {
        Connexion connect = new Connexion();
        Fail fail = new Fail();
        Effectuer effectuer = new Effectuer();
        Yesno yesno = new Yesno();
        MySqlCommand cmd;
        MySqlDataReader lecteur;

        private Panel panel1;
        private Panel panel3;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox1;
        private Guna.UI.WinForms.GunaTextBox gunaTextBox2;
        private Label label1;
        private Guna.UI.WinForms.GunaComboBox gunaComboBox1;
        private Label label5;
        private Guna.UI.WinForms.GunaComboBox gunaComboBox4;
        private Label label6;
        private Guna.UI.WinForms.GunaComboBox gunaComboBox2;
        private Label label2;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox2;
        private Panel panel12;
        private Panel panel13;
        private Guna.UI.WinForms.GunaComboBox gunaComboBox5;
        private Label label3;
        private Guna.UI.WinForms.GunaTextBox gunaTextBox3;
        private Label label8;
        private Panel panel11;
        private Panel panel10;
        private Guna.UI.WinForms.GunaComboBox gunaComboBox3;
        private Label label7;
        private Guna.UI.WinForms.GunaTextBox gunaTextBox1;
        private Label label4;
        private Panel panel5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label9;
        private PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Panel panel2;

        public Paie()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paie));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.gunaGroupBox2 = new Guna.UI.WinForms.GunaGroupBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.gunaComboBox5 = new Guna.UI.WinForms.GunaComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gunaTextBox3 = new Guna.UI.WinForms.GunaTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.gunaComboBox3 = new Guna.UI.WinForms.GunaComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gunaTextBox1 = new Guna.UI.WinForms.GunaTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gunaGroupBox1 = new Guna.UI.WinForms.GunaGroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gunaTextBox2 = new Guna.UI.WinForms.GunaTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaComboBox1 = new Guna.UI.WinForms.GunaComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gunaComboBox4 = new Guna.UI.WinForms.GunaComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gunaComboBox2 = new Guna.UI.WinForms.GunaComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.gunaGroupBox2.SuspendLayout();
            this.gunaGroupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.gunaGroupBox2);
            this.panel1.Controls.Add(this.gunaGroupBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 456);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.iconPictureBox3);
            this.panel5.Controls.Add(this.iconPictureBox2);
            this.panel5.Controls.Add(this.iconPictureBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 388);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(428, 68);
            this.panel5.TabIndex = 4;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.iconPictureBox3.BackColor = System.Drawing.Color.White;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.Red;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconPictureBox3.IconColor = System.Drawing.Color.Red;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 58;
            this.iconPictureBox3.Location = new System.Drawing.Point(333, 3);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(58, 62);
            this.iconPictureBox3.TabIndex = 2;
            this.iconPictureBox3.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.iconPictureBox2.BackColor = System.Drawing.Color.White;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 58;
            this.iconPictureBox2.Location = new System.Drawing.Point(185, 3);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(58, 62);
            this.iconPictureBox2.TabIndex = 1;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.Click += new System.EventHandler(this.iconPictureBox2_Click);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Lime;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Lime;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 58;
            this.iconPictureBox1.Location = new System.Drawing.Point(35, 3);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(58, 62);
            this.iconPictureBox1.TabIndex = 0;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // gunaGroupBox2
            // 
            this.gunaGroupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gunaGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox2.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox2.Controls.Add(this.panel12);
            this.gunaGroupBox2.Controls.Add(this.panel13);
            this.gunaGroupBox2.Controls.Add(this.gunaComboBox5);
            this.gunaGroupBox2.Controls.Add(this.label3);
            this.gunaGroupBox2.Controls.Add(this.gunaTextBox3);
            this.gunaGroupBox2.Controls.Add(this.label8);
            this.gunaGroupBox2.Controls.Add(this.panel11);
            this.gunaGroupBox2.Controls.Add(this.panel10);
            this.gunaGroupBox2.Controls.Add(this.gunaComboBox3);
            this.gunaGroupBox2.Controls.Add(this.label7);
            this.gunaGroupBox2.Controls.Add(this.gunaTextBox1);
            this.gunaGroupBox2.Controls.Add(this.label4);
            this.gunaGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGroupBox2.ForeColor = System.Drawing.Color.White;
            this.gunaGroupBox2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.gunaGroupBox2.Location = new System.Drawing.Point(0, 212);
            this.gunaGroupBox2.Name = "gunaGroupBox2";
            this.gunaGroupBox2.Size = new System.Drawing.Size(428, 189);
            this.gunaGroupBox2.TabIndex = 3;
            this.gunaGroupBox2.Text = "Primes";
            this.gunaGroupBox2.TextLocation = new System.Drawing.Point(190, 8);
            // 
            // panel12
            // 
            this.panel12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panel12.Location = new System.Drawing.Point(2, 168);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(427, 2);
            this.panel12.TabIndex = 23;
            // 
            // panel13
            // 
            this.panel13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panel13.Location = new System.Drawing.Point(3, 121);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(427, 2);
            this.panel13.TabIndex = 22;
            // 
            // gunaComboBox5
            // 
            this.gunaComboBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gunaComboBox5.BackColor = System.Drawing.Color.Transparent;
            this.gunaComboBox5.BaseColor = System.Drawing.Color.White;
            this.gunaComboBox5.BorderColor = System.Drawing.Color.Silver;
            this.gunaComboBox5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gunaComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gunaComboBox5.FocusedColor = System.Drawing.Color.Empty;
            this.gunaComboBox5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.gunaComboBox5.ForeColor = System.Drawing.Color.Black;
            this.gunaComboBox5.FormattingEnabled = true;
            this.gunaComboBox5.Location = new System.Drawing.Point(251, 129);
            this.gunaComboBox5.Name = "gunaComboBox5";
            this.gunaComboBox5.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.gunaComboBox5.OnHoverItemForeColor = System.Drawing.Color.White;
            this.gunaComboBox5.Radius = 10;
            this.gunaComboBox5.Size = new System.Drawing.Size(174, 28);
            this.gunaComboBox5.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label3.Location = new System.Drawing.Point(199, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Pour";
            // 
            // gunaTextBox3
            // 
            this.gunaTextBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gunaTextBox3.BackColor = System.Drawing.Color.Transparent;
            this.gunaTextBox3.BaseColor = System.Drawing.Color.White;
            this.gunaTextBox3.BorderColor = System.Drawing.Color.Silver;
            this.gunaTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTextBox3.FocusedBaseColor = System.Drawing.Color.White;
            this.gunaTextBox3.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.gunaTextBox3.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.gunaTextBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.gunaTextBox3.ForeColor = System.Drawing.Color.Black;
            this.gunaTextBox3.Location = new System.Drawing.Point(10, 129);
            this.gunaTextBox3.MaxLength = 20;
            this.gunaTextBox3.Name = "gunaTextBox3";
            this.gunaTextBox3.PasswordChar = '\0';
            this.gunaTextBox3.Radius = 10;
            this.gunaTextBox3.SelectedText = "";
            this.gunaTextBox3.Size = new System.Drawing.Size(185, 30);
            this.gunaTextBox3.TabIndex = 19;
            this.gunaTextBox3.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label8.Location = new System.Drawing.Point(124, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Reajustement Transport";
            // 
            // panel11
            // 
            this.panel11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panel11.Location = new System.Drawing.Point(4, 93);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(427, 2);
            this.panel11.TabIndex = 18;
            // 
            // panel10
            // 
            this.panel10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panel10.Location = new System.Drawing.Point(4, 55);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(427, 2);
            this.panel10.TabIndex = 17;
            // 
            // gunaComboBox3
            // 
            this.gunaComboBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gunaComboBox3.BackColor = System.Drawing.Color.Transparent;
            this.gunaComboBox3.BaseColor = System.Drawing.Color.White;
            this.gunaComboBox3.BorderColor = System.Drawing.Color.Silver;
            this.gunaComboBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gunaComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gunaComboBox3.FocusedColor = System.Drawing.Color.Empty;
            this.gunaComboBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.gunaComboBox3.ForeColor = System.Drawing.Color.Black;
            this.gunaComboBox3.FormattingEnabled = true;
            this.gunaComboBox3.Location = new System.Drawing.Point(253, 61);
            this.gunaComboBox3.Name = "gunaComboBox3";
            this.gunaComboBox3.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.gunaComboBox3.OnHoverItemForeColor = System.Drawing.Color.White;
            this.gunaComboBox3.Radius = 10;
            this.gunaComboBox3.Size = new System.Drawing.Size(172, 28);
            this.gunaComboBox3.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label7.Location = new System.Drawing.Point(201, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Pour";
            // 
            // gunaTextBox1
            // 
            this.gunaTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gunaTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaTextBox1.BaseColor = System.Drawing.Color.White;
            this.gunaTextBox1.BorderColor = System.Drawing.Color.Silver;
            this.gunaTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTextBox1.FocusedBaseColor = System.Drawing.Color.White;
            this.gunaTextBox1.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.gunaTextBox1.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.gunaTextBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.gunaTextBox1.ForeColor = System.Drawing.Color.Black;
            this.gunaTextBox1.Location = new System.Drawing.Point(12, 61);
            this.gunaTextBox1.MaxLength = 20;
            this.gunaTextBox1.Name = "gunaTextBox1";
            this.gunaTextBox1.PasswordChar = '\0';
            this.gunaTextBox1.Radius = 10;
            this.gunaTextBox1.SelectedText = "";
            this.gunaTextBox1.Size = new System.Drawing.Size(183, 30);
            this.gunaTextBox1.TabIndex = 7;
            this.gunaTextBox1.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label4.Location = new System.Drawing.Point(178, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Generale";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gunaGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Controls.Add(this.label9);
            this.gunaGroupBox1.Controls.Add(this.gunaTextBox2);
            this.gunaGroupBox1.Controls.Add(this.label1);
            this.gunaGroupBox1.Controls.Add(this.gunaComboBox1);
            this.gunaGroupBox1.Controls.Add(this.label5);
            this.gunaGroupBox1.Controls.Add(this.gunaComboBox4);
            this.gunaGroupBox1.Controls.Add(this.label6);
            this.gunaGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGroupBox1.ForeColor = System.Drawing.Color.White;
            this.gunaGroupBox1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.gunaGroupBox1.Location = new System.Drawing.Point(0, 53);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Size = new System.Drawing.Size(428, 153);
            this.gunaGroupBox1.TabIndex = 2;
            this.gunaGroupBox1.Text = "Type Paiement";
            this.gunaGroupBox1.TextLocation = new System.Drawing.Point(190, 8);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label9.Location = new System.Drawing.Point(366, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 24);
            this.label9.TabIndex = 7;
            this.label9.Text = "FC";
            // 
            // gunaTextBox2
            // 
            this.gunaTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gunaTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaTextBox2.BaseColor = System.Drawing.Color.White;
            this.gunaTextBox2.BorderColor = System.Drawing.Color.Silver;
            this.gunaTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTextBox2.FocusedBaseColor = System.Drawing.Color.White;
            this.gunaTextBox2.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.gunaTextBox2.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.gunaTextBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.gunaTextBox2.ForeColor = System.Drawing.Color.Black;
            this.gunaTextBox2.Location = new System.Drawing.Point(150, 116);
            this.gunaTextBox2.MaxLength = 5;
            this.gunaTextBox2.Name = "gunaTextBox2";
            this.gunaTextBox2.PasswordChar = '\0';
            this.gunaTextBox2.Radius = 10;
            this.gunaTextBox2.SelectedText = "";
            this.gunaTextBox2.Size = new System.Drawing.Size(210, 30);
            this.gunaTextBox2.TabIndex = 0;
            this.gunaTextBox2.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label1.Location = new System.Drawing.Point(72, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Taux";
            // 
            // gunaComboBox1
            // 
            this.gunaComboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gunaComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaComboBox1.BaseColor = System.Drawing.Color.White;
            this.gunaComboBox1.BorderColor = System.Drawing.Color.Silver;
            this.gunaComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gunaComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gunaComboBox1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaComboBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.gunaComboBox1.ForeColor = System.Drawing.Color.Black;
            this.gunaComboBox1.FormattingEnabled = true;
            this.gunaComboBox1.Location = new System.Drawing.Point(150, 72);
            this.gunaComboBox1.Name = "gunaComboBox1";
            this.gunaComboBox1.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.gunaComboBox1.OnHoverItemForeColor = System.Drawing.Color.White;
            this.gunaComboBox1.Radius = 10;
            this.gunaComboBox1.Size = new System.Drawing.Size(210, 28);
            this.gunaComboBox1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label5.Location = new System.Drawing.Point(73, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Année";
            // 
            // gunaComboBox4
            // 
            this.gunaComboBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gunaComboBox4.BackColor = System.Drawing.Color.Transparent;
            this.gunaComboBox4.BaseColor = System.Drawing.Color.White;
            this.gunaComboBox4.BorderColor = System.Drawing.Color.Silver;
            this.gunaComboBox4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gunaComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gunaComboBox4.FocusedColor = System.Drawing.Color.Empty;
            this.gunaComboBox4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.gunaComboBox4.ForeColor = System.Drawing.Color.Black;
            this.gunaComboBox4.FormattingEnabled = true;
            this.gunaComboBox4.Items.AddRange(new object[] {
            "Janvier",
            "Fevrier",
            "Mars",
            "Avril",
            "Mai",
            "Juin",
            "Juillet",
            "Aout",
            "Septembre",
            "Octobre",
            "Novembre",
            "Decembre"});
            this.gunaComboBox4.Location = new System.Drawing.Point(150, 32);
            this.gunaComboBox4.Name = "gunaComboBox4";
            this.gunaComboBox4.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.gunaComboBox4.OnHoverItemForeColor = System.Drawing.Color.White;
            this.gunaComboBox4.Radius = 10;
            this.gunaComboBox4.Size = new System.Drawing.Size(210, 28);
            this.gunaComboBox4.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label6.Location = new System.Drawing.Point(73, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Mois";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(428, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(168, 403);
            this.panel3.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::GestionPaieAgentSonas.Properties.Resources.m;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(168, 208);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::GestionPaieAgentSonas.Properties.Resources._2118f3cad66e58b4f5abadf49ce7bf07;
            this.pictureBox1.Location = new System.Drawing.Point(0, 214);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gunaComboBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 53);
            this.panel2.TabIndex = 0;
            // 
            // gunaComboBox2
            // 
            this.gunaComboBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gunaComboBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaComboBox2.BaseColor = System.Drawing.Color.White;
            this.gunaComboBox2.BorderColor = System.Drawing.Color.Silver;
            this.gunaComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gunaComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gunaComboBox2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaComboBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaComboBox2.ForeColor = System.Drawing.Color.Black;
            this.gunaComboBox2.FormattingEnabled = true;
            this.gunaComboBox2.Location = new System.Drawing.Point(249, 13);
            this.gunaComboBox2.Name = "gunaComboBox2";
            this.gunaComboBox2.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.gunaComboBox2.OnHoverItemForeColor = System.Drawing.Color.White;
            this.gunaComboBox2.Radius = 10;
            this.gunaComboBox2.Size = new System.Drawing.Size(210, 28);
            this.gunaComboBox2.TabIndex = 3;
            this.gunaComboBox2.SelectedIndexChanged += new System.EventHandler(this.gunaComboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label2.Location = new System.Drawing.Point(137, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Categories";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Paie
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(596, 456);
            this.Controls.Add(this.panel1);
            this.Name = "Paie";
            this.Text = "Paie";
            this.Load += new System.EventHandler(this.Paie_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.gunaGroupBox2.ResumeLayout(false);
            this.gunaGroupBox2.PerformLayout();
            this.gunaGroupBox1.ResumeLayout(false);
            this.gunaGroupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Paie_Load(object sender, EventArgs e)
        {
            cmd = connect.getGrade();
            lecteur = cmd.ExecuteReader();
            gunaComboBox2.Items.Add("Toutes");
            gunaComboBox3.Items.Add("Toutes");
            gunaComboBox5.Items.Add("Toutes");
            while (lecteur.Read())
            {
                gunaComboBox2.Items.Add(lecteur[0]);
                gunaComboBox3.Items.Add(lecteur[0]);
                gunaComboBox5.Items.Add(lecteur[0]);
            }
            lecteur.Close();
            for(int i = 2000; i <= 2025; i++)
            {
                gunaComboBox1.Items.Add(i);
            }
        }

        private void gunaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            string matricule;
            string code_grade;
            string code_Aff;
            int nbrenfants;
            int primeDiplome;
            int salaire;
            int indeminite;
            int allocation;
            string grade;
            string affectation;
            string nom;
            string postnom;
            string prenom;
            int totals = 0;
            int generalep = int.Parse(gunaTextBox1.Text);
            int ajustement = int.Parse(gunaTextBox3.Text);
            int taux = int.Parse(gunaTextBox2.Text);

            try
            {
                cmd = connect.PaieA();
                MySqlDataReader d;
                d = cmd.ExecuteReader();
                while (d.Read())
                {

                    matricule = d.GetValue(2).ToString();
                    code_grade = d.GetValue(3).ToString();
                    code_Aff = d.GetValue(4).ToString();
                    nbrenfants = int.Parse(d.GetValue(6).ToString());
                    primeDiplome = int.Parse(d.GetValue(7).ToString());
                    salaire = int.Parse(d.GetValue(8).ToString());
                    indeminite = int.Parse(d.GetValue(9).ToString());
                    allocation = int.Parse(d.GetValue(10).ToString());
                    grade = d.GetValue(11).ToString();
                    affectation = d.GetValue(12).ToString();
                    nom = d.GetValue(13).ToString();
                    postnom = d.GetValue(14).ToString();
                    prenom = d.GetValue(15).ToString();
                    totals += salaire + primeDiplome + indeminite + (allocation * nbrenfants) + generalep + ajustement;



                } 
                effectuer.Effectuer_text("Paiement effectuer");
                effectuer.ShowDialog();
                d.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                fail.Fail_text("Echec une erreur est survenu");
                fail.ShowDialog();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string matricule;
            string code_grade;
            string code_Aff;
            int nbrenfants;
            int primeDiplome;
            int salaire;
            int indeminite;
            int allocation;
            string grade;
            string affectation;
            string nom;
            string postnom;
            string prenom;
            int totals = 0;
            int generalep = int.Parse(gunaTextBox1.Text);
            int ajustement = int.Parse(gunaTextBox3.Text);
            int taux = int.Parse(gunaTextBox2.Text);

            try
            {
                cmd = connect.PaieA();
                MySqlDataReader d;
                d = cmd.ExecuteReader();
                e.Graphics.DrawString("Bulletin De Paie", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Black, new Point(230));
                while (d.Read())
                {

                    matricule = d.GetValue(2).ToString();
                    code_grade = d.GetValue(3).ToString();
                    code_Aff = d.GetValue(4).ToString();
                    nbrenfants = int.Parse(d.GetValue(6).ToString());
                    primeDiplome = int.Parse(d.GetValue(7).ToString());
                    salaire = int.Parse(d.GetValue(8).ToString());
                    indeminite = int.Parse(d.GetValue(9).ToString());
                    allocation = int.Parse(d.GetValue(10).ToString());
                    grade = d.GetValue(11).ToString();
                    affectation = d.GetValue(12).ToString();
                    nom = d.GetValue(13).ToString();
                    postnom = d.GetValue(14).ToString();
                    prenom = d.GetValue(15).ToString();
                    totals += salaire + primeDiplome + indeminite + (allocation * nbrenfants) + generalep + ajustement;


                    e.Graphics.DrawString(nom+" "+ postnom+ " "+ prenom, new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Black, new Point(70, 150)); 
                    e.Graphics.DrawString(totals.ToString(), new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Black, new Point(100,200));
                    e.HasMorePages = d.Read();
                }
                
                d.Close();


            }
            catch (Exception)
            {
                fail.Fail_text("Echec une erreur est survenu");
                fail.ShowDialog();
            }


        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
                if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
