using System;
using System.Windows.Forms;

namespace Tubes_KPL_GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();
                ToDoListSingleton.Instance.ResetAllLoginStatus();
                Application.Run(new FormLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memulai aplikasi:\n{ex.Message}",
                    "Kesalahan Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
