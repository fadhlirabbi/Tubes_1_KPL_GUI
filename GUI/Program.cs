using System;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ToDoListService.Instance.ResetAllLoginStatus();
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }

    }
}
