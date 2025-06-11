using System;
using System.Linq;
using System.Windows.Forms;
using API.Model;
using SystemTask = System.Threading.Tasks.Task;

namespace Tubes_KPL_GUI
{
    /// <summary>
    /// FormBeranda adalah form utama yang menampilkan informasi beranda dan tugas yang belum selesai.
    /// </summary>
    public partial class FormBeranda : Form
    {
        private readonly string _username;

        /// <summary>
        /// Konstruktor FormBeranda yang menerima username pengguna.
        /// </summary>
        /// <param name="username">Username pengguna yang sedang login</param>
        public FormBeranda(string username)
        {
            InitializeComponent();  
            _username = username;  
        }

        /// <summary>
        /// Event handler yang dijalankan saat FormBeranda dimuat.
        /// Menampilkan pesan selamat datang dan memuat daftar tugas yang belum selesai.
        /// </summary>
        private async void FormBeranda_Load(object sender, EventArgs e)
        {
            welcomeLabel.Text = $"Selamat datang, {_username}";
            await LoadIncompletedTasksAsync();
        }

        /// <summary>
        /// Mengambil tugas yang belum selesai dari server dan menampilkannya di grid.
        /// Menyortir tugas berdasarkan deadline.
        /// </summary>
        private async System.Threading.Tasks.Task LoadIncompletedTasksAsync()
        {
            try
            {
                taskGridView.Rows.Clear();

                var tasks = await ToDoListSingleton.Instance.GetTasksByStatusAsync(_username, Status.Incompleted);

                var sortedTasks = tasks.OrderBy(t =>
                    new DateTime(t.Deadline.Year, t.Deadline.Month, t.Deadline.Day, t.Deadline.Hour, t.Deadline.Minute, 2)
                ).ToList();

                foreach (var task in sortedTasks)
                {
                    var deadline = task.Deadline;
                    string tanggal = $"{deadline.Day:D2}/{deadline.Month:D2}/{deadline.Year}";
                    string waktu = $"{deadline.Hour:D2}:{deadline.Minute:D2}";

                    taskGridView.Rows.Add(
                        task.Name,
                        task.Description,
                        tanggal,
                        waktu,
                        task.Status.ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat tugas: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void motivationLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
