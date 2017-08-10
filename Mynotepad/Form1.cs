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

namespace Mynotepad
{
    public partial class Form1 : Form
    {
        string path;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Only text document|*.text", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            path = sfd.FileName;
                            using (StreamWriter sw = new StreamWriter(sfd.FileName))
                            {
                                await sw.WriteLineAsync(textBox1.Text);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        await sw.WriteLineAsync(textBox1.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Only text document|*.text", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (StreamWriter sw = new StreamWriter(sfd.FileName))
                            {
                                await sw.WriteLineAsync(textBox1.Text);
                            }
                        }

                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = string.Empty;
            textBox1.Clear();
        }

        private void aboutAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (About frm = new About())
            {
                frm.ShowDialog();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Only text document|*.text", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(ofd.FileName))
                        {
                            path = ofd.FileName;
                            Task<string> text = sr.ReadToEndAsync();
                            textBox1.Text = text.Result;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
    }
}
