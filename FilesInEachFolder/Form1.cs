using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FilesInEachFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //
            using (StreamWriter sw = new StreamWriter(textBox1.Text + "\\PathReport.txt"))
            {
                  string[] filePath = Directory.GetFiles(textBox1.Text, (textBox2.Text));

                  foreach (string name in filePath)
                    {
                      sw.WriteLine(name);
                      //MessageBox.Show(name);
                    }

                sw.Flush();
            }

            MessageBox.Show("Report Complete");
            System.Diagnostics.Process.Start("notepad.exe", textBox1.Text + "\\PathReport.txt");

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm form2 = new HelpForm();
            form2.Show();
        }
    }
}
