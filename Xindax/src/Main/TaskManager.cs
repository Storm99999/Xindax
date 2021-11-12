using System.Windows.Forms;
using Xindax.src.Services;

namespace Xindax.src.Main
{
    public partial class TaskManager : Form
    {
        public TaskManager()
        {
            InitializeComponent();
            XalaryService xalaryService = new XalaryService();
            xalaryService.GetTasks(listBox1);
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((string)listBox1.SelectedItem == "XalaryServiceProvider.service")
            {
                Hide();
                new DS().Show();
            }
        }
    }
}
