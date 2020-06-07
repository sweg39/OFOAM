using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sčinčila
{
    public partial class Form1 : Form
    {
        string path = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (webBrowser1.Visible == true)
            {
                fastColoredTextBox1.Width = this.Width / 2;
            }
            else
            {
                fastColoredTextBox1.Width = this.Width;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, fastColoredTextBox1.Text);
                path = sfd.FileName;
            }
        }
                catch(Exception eg)
                {
                    MessageBox.Show(eg.Message);
                }
}
        
        private void openInFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(path != null)
            {
                try
                {
                    FileInfo fi = new FileInfo(path);

                    Process.Start(fi.Directory.ToString());
                }
                catch(Exception eg)
                {
                    MessageBox.Show(eg.Message);
                }
            }
            else
            {
                MessageBox.Show("Please save the file first.");
            }
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Run(new Form1());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you really want to exit?", "Exiting...", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
        }

        private void cSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
        }

        private void jAVASCRIPTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
        }

        private void vBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.VB;
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.XML;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            if(f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fastColoredTextBox1.Text = File.ReadAllText(f.FileName);
                }
                catch(Exception enumd)
                {
                    MessageBox.Show(enumd.Message);
                }
            }
        }

        private void livePreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(path != null)
            {
                try
                {
                    UriBuilder ub = new UriBuilder();
                    Uri cc = new Uri(path);
                    webBrowser1.Url = cc;
                    fastColoredTextBox1.Width = this.Width - webBrowser1.Width - 17;
                    webBrowser1.Visible = true;
                }
                catch(Exception ep)
                {
                    MessageBox.Show(ep.Message);
                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if(webBrowser1.Visible == true)
            {
                fastColoredTextBox1.Width = this.Width / 2;
            }
            else
            {
                fastColoredTextBox1.Width = this.Width;
            }
        }

        private void fastColoredTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                if(path != null)
                {
                    File.WriteAllText(path, fastColoredTextBox1.Text);
                    try
                    {
                        UriBuilder ub = new UriBuilder();
                        Uri cc = new Uri(path);
                        webBrowser1.Url = cc;
                        fastColoredTextBox1.Width = this.Width - webBrowser1.Width - 17;
                        webBrowser1.Visible = true;
                    }
                    catch (Exception ep)
                    {
                        MessageBox.Show(ep.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Save your file first!");
                }
            }
        }
    }
}
