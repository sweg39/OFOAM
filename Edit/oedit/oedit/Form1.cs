using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using twogg32;
namespace oedit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string repository;
        public string font;
        public string backgroundColor;
        public int textColorR;
        public int textColorG;
        public int textColorB;
        public int backgroundColorR;
        public int backgroundColorG;
        public int backgroundColorB;
        public int accentColorR;
        public int accentColorG;
        public int accentColorB;
        public int floatEmStyle;
        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                var inifile = new IniFile("usr-settings.ini");
                font = inifile.GetValue("Text", "textFont");
                label1.Font = new System.Drawing.Font(font, 16);
                textColorR = inifile.GetInteger("Color", "textColorRed");
                textColorG = inifile.GetInteger("Color", "textColorGreen");
                textColorB = inifile.GetInteger("Color", "textColorBlue");
                backgroundColorR = inifile.GetInteger("Color", "backgroundColorRed");
                backgroundColorG = inifile.GetInteger("Color", "backgroundColorGreen");
                backgroundColorB = inifile.GetInteger("Color", "backgroundColorBlue");
                accentColorR = inifile.GetInteger("Color", "accentRed");
                accentColorG = inifile.GetInteger("Color", "accentGreen");
                accentColorB = inifile.GetInteger("Color", "accentBlue");
                floatEmStyle = inifile.GetInteger("Text", "textSizeFloat");
                this.ForeColor = Color.FromArgb(textColorR, textColorG, textColorB);
                this.BackColor = Color.FromArgb(backgroundColorR, backgroundColorG, backgroundColorB);
                this.Font = new System.Drawing.Font(font, floatEmStyle);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Width = inifile.GetInteger("Basic", "width", 600);
                this.Height = inifile.GetInteger("Basic", "height", 360);
                button1.BackColor = Color.FromArgb(accentColorR, accentColorG, accentColorB);
                button2.BackColor = Color.FromArgb(accentColorR, accentColorG, accentColorB);
            }
            catch(Exception ex)
            {

                if(MessageBox.Show("Error: application needs to exit. Additional info: .." + ex.ToString() + "...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if(fb.ShowDialog() == DialogResult.OK)
            {
                repository = fb.SelectedPath;
                label2.Text = repository;
            }
            else
            {
                MessageBox.Show("Error: no folder selected.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                label3.Text = ofd.FileName;
            }
            else
            {
                MessageBox.Show("Error: no file selected.");
            }
        }
    }
}

