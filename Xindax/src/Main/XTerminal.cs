using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xindax.src.Main
{
    public partial class XTerminal : Form
    {
        public XTerminal()
        {
            InitializeComponent();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (richTextBox1.Text == "xin xfetch.x")
                {
                    richTextBox1.Text = @"

                               
 Root space used - 56%
 Fetched graphics - 1
 Physical Power - 100%";
                }
                else if (richTextBox1.Text.Contains("/root -cdir "))
                {
                    
                }
            }
        }
    }
}
