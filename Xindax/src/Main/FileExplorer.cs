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
using Xindax.Properties;
using Xindax.src.Data;
using Xindax.src.Services;

namespace Xindax.src.Main
{
    public partial class FileExplorer : Form
    {
        public FileService.State Service { get; set; }
        public static string CurrentDirectory = Settings.Default.dir;
        public FileExplorer()
        {
            InitializeComponent();
            Vars.State = FileService.State.BROWSING;
            if (Vars.State == FileService.State.BROWSING)
            {
                MessageBox.Show(CurrentDirectory);
                siticoneProgressBar1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                panel1.Visible = false;
                treeView1.Nodes.Clear();
                treeView1.Visible = true;
                foreach (var dirs in Directory.GetDirectories(CurrentDirectory))
                {
                    DirectoryInfo DirInfo = new DirectoryInfo(dirs);
                    var nodes = treeView1.Nodes.Add(DirInfo.Name, DirInfo.Name, 0);
                    nodes.Tag = DirInfo;
                }
                foreach (var Files in Directory.GetFiles(CurrentDirectory))
                {
                    FileInfo fileInfo = new FileInfo(Files);
                    var nodes = treeView1.Nodes.Add(fileInfo.Name, fileInfo.Name, 1);
                    nodes.Tag = fileInfo;
                }
            }
        }

        private void FileExplorer_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null)
            {
                // do nothing
            }
            else if (e.Node.Tag.GetType() == typeof(DirectoryInfo))
            {
                // Opens the folder
                e.Node.Nodes.Clear();
                foreach (var dirs in Directory.GetDirectories(((DirectoryInfo)e.Node.Tag).FullName))
                {
                    DirectoryInfo DirInfo = new DirectoryInfo(dirs);
                    var nodes = e.Node.Nodes.Add(DirInfo.Name, DirInfo.Name, 0);
                    nodes.Tag = DirInfo;
                }
                foreach (var dirs in Directory.GetFiles(((DirectoryInfo)e.Node.Tag).FullName))
                {
                    FileInfo DirInfo = new FileInfo(dirs);
                    var nodes = e.Node.Nodes.Add(DirInfo.Name, DirInfo.Name, 1);
                    nodes.Tag = DirInfo;
                }
            }
            else
            {
                Process.Start(((FileInfo)e.Node.Tag).FullName);
            }
        }

        private void siticoneRoundedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CurrentDirectory = siticoneRoundedTextBox1.Text;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void siticoneRoundedTextBox1_TextChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            if (siticoneRoundedTextBox1.Text.Contains("/r/"))
            {
                if (Directory.Exists(siticoneRoundedTextBox1.Text.Replace("/r/", "")))
                {
                    foreach (var dirs in Directory.GetDirectories(siticoneRoundedTextBox1.Text.Replace("/r/", "")))
                    {
                        DirectoryInfo DirInfo = new DirectoryInfo(dirs);
                        var nodes = treeView1.Nodes.Add(DirInfo.Name, DirInfo.Name, 0);
                        nodes.Tag = DirInfo;
                    }
                    foreach (var Files in Directory.GetFiles(siticoneRoundedTextBox1.Text.Replace("/r/", "")))
                    {
                        FileInfo fileInfo = new FileInfo(Files);
                        var nodes = treeView1.Nodes.Add(fileInfo.Name, fileInfo.Name, 1);
                        nodes.Tag = fileInfo;
                    }
                }
            }
        }
    }
}
