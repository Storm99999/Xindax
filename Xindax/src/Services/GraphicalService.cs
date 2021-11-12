using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xindax.src.Services
{
    internal class GraphicalService
    {
        public static void AddAppToTaskbar(PictureBox _serviceNeeded, FlowLayoutPanel pnl)
        {
            pnl.Controls.Add(_serviceNeeded);
        }
    }
}
