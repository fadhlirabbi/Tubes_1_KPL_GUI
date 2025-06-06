using System;
using System.Windows.Forms;

namespace Tubes_KPL_GUI
{
    internal static class Program
    {
        /// <summary>
        /// Titik masuk utama aplikasi GUI.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();

                // Reset status login saat aplikasi dimulai
                ToDoListSingleton.Instance.ResetAllLoginStatus();

                // Mulai dari form login
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
