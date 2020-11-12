using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Auto_File_Renamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fDialog = new FolderBrowserDialog();
            fDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            if (fDialog.ShowDialog() == DialogResult.OK) {
                textBox1.Text = $"{fDialog.SelectedPath}\\";
            }
        }

        List<string> oFolders = new List<string>();
        List<string> oFiles = new List<string>();
        List<string> Folders = new List<string>();
        List<string> Files = new List<string>();

        private void button2_Click(object sender, EventArgs e)
        {
            oFolders.Clear();
            oFiles.Clear();
            Folders.Clear();
            Files.Clear();
            richTextBox1.Clear();

            int numFolders = Directory.GetDirectories(textBox1.Text).Length;
            int numFiles = Directory.GetFiles(textBox1.Text).Length;

            if (numFolders > 0 && checkBox1.Checked == true)
            {
                for (var n = 0; n < numFolders; n++)
                {
                    string folderNames = Directory.GetDirectories(textBox1.Text)[n];
                    if (folderNames.Contains(textBox2.Text))
                    {
                        richTextBox1.Text += folderNames + "\n";
                        oFolders.Add(folderNames);
                    }
                }
            }

            if (numFiles > 0 && checkBox2.Checked == true)
            {
                for (var n = 0; n < numFiles; n++)
                {
                    string fileNames = Directory.GetFiles(textBox1.Text)[n];
                    if (fileNames.Contains(textBox4.Text))
                    {
                        richTextBox1.Text += fileNames + "\n";
                        oFiles.Add(fileNames);
                    }
                }
            }

            if (oFolders.Count > 0 && checkBox1.Checked == true)
            {
                for (var n = 0; n < oFolders.Count; n++)
                {
                    Folders.Add(oFolders[n].Replace(textBox2.Text, textBox3.Text));
                }
            }

            if (oFiles.Count > 0 && checkBox2.Checked == true)
            {
                for (var n = 0; n < oFiles.Count; n++)
                {
                    Files.Add(oFiles[n].Replace(textBox4.Text, textBox5.Text));
                }
            }

            if (Folders.Count > 0)
            {
                for (var n = 0; n < Folders.Count; n++)
                {
                    Directory.Move(oFolders[n], Folders[n]);
                }
            }

            if (Files.Count > 0)
            {
                for (var n = 0; n < Files.Count; n++)
                {
                    Directory.Move(oFiles[n], Files[n]);
                }
            }
        }
    }
}
