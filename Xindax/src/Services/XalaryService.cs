using System.Windows.Forms;

namespace Xindax.src.Services
{
    internal class XalaryService
    {
        public string[] get;
        public void GetTasks(ListBox box)
        {
            get = new string[]
            {
                "XalaryServiceProvider.service",
                "Task Manager"
            };

            foreach (string str in get)
            {
                box.Items.Add(str);
            }
        }
    }
}
