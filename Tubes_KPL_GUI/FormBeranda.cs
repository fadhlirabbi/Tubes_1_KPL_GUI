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
        // Menyimpan username pengguna yang sedang login
        private readonly string _username;

        /// <summary>
        /// Konstruktor FormBeranda yang menerima username pengguna.
        /// </summary>
        /// <param name="username">Username pengguna yang sedang login</param>
        public FormBeranda(string username)
        {
            InitializeComponent();  // Inisialisasi komponen UI
            _username = username;  // Menyimpan username pengguna
        }

        /// <summary>
        /// Event handler yang dijalankan saat FormBeranda dimuat.
        /// Menampilkan pesan selamat datang dan memuat daftar tugas yang belum selesai.
        /// </summary>
        private async void FormBeranda_Load(object sender, EventArgs e)
        {
            // Menampilkan pesan selamat datang dengan nama pengguna
            welcomeLabel.Text = $"Selamat datang, {_username}";

            // Memuat tugas yang belum selesai
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
                taskGridView.Rows.Clear();  // Clear previous rows if any

                // Mendapatkan tugas yang belum selesai berdasarkan status tugas
                var tasks = await ToDoListSingleton.Instance.GetTasksByStatusAsync(_username, Status.Incompleted);

                // Menyortir tugas berdasarkan deadline
                var sortedTasks = tasks.OrderBy(t =>
                    new DateTime(t.Deadline.Year, t.Deadline.Month, t.Deadline.Day, t.Deadline.Hour, t.Deadline.Minute, 2)
                ).ToList();

                // Tampilkan setiap tugas di DataGridView
                foreach (var task in sortedTasks)
                {
                    var deadline = task.Deadline;
                    string tanggal = $"{deadline.Day:D2}/{deadline.Month:D2}/{deadline.Year}";
                    string waktu = $"{deadline.Hour:D2}:{deadline.Minute:D2}";

                    // Menambahkan data ke dalam DataGridView
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
                // Menampilkan pesan error jika gagal memuat tugas
                MessageBox.Show($"Gagal memuat tugas: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void motivationLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
