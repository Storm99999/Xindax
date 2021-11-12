using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Xindax.Properties;
using Xindax.src.Main;
using Xindax.src.Services;

namespace Xindax
{
    public partial class XindaxUI : Form
    {
        private Image mainIcon = Resources.aicon;
        private PictureBox mIconTb = new PictureBox();
        public static string Direct = "";
        public XindaxUI()
        {
            InitializeComponent();
            mIconTb.Image = mainIcon;
            mIconTb.Width = 60;
            mIconTb.Height = 60;
            GraphicalService.AddAppToTaskbar(pictureBox1, Taskbar);
            GraphicalService.AddAppToTaskbar(pictureBox2, Taskbar);
            GraphicalService.AddAppToTaskbar(pictureBox3, Taskbar);
            GraphicalService.AddAppToTaskbar(pictureBox4, Taskbar);
            GraphicalService.AddAppToTaskbar(pictureBox5, Taskbar);

            foreach (var folders in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\XindaxSim"))
            {
                DirectoryInfo folder = new DirectoryInfo(folders);
                PictureBox folderIcon = new PictureBox();
                folderIcon.Image = Resources.folder_xxl;
                folderIcon.Width = 53;
                folderIcon.Height = 38;
                Direct = folder.FullName;
                folderIcon.Click += FolderIcon_Click;
                folderIcon.SizeMode = PictureBoxSizeMode.Zoom;
                flowLayoutPanel1.Controls.Add(folderIcon);
            }
        }

        private void FolderIcon_Click(object sender, EventArgs e)
        {
            
            Settings.Default.dir = Direct;
            Settings.Default.Save();
            new FileExplorer().Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new Xiexplorer().Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new XTerminal().Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new FileExplorer().Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            panel1.Visible = true;
            
        }

        private void XindaxUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            if (e.KeyCode == Keys.Escape && panel1.Visible == false)
            {
                panel1.Visible = true;
            }
        }

        private void XindaxUI_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FileExplorer ex = new FileExplorer();
            Settings.Default.dir = "D:\\ue4";
            ex.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            new TaskManager().Show();
        }
    }
}
