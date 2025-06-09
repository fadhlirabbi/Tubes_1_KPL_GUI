using System;
using System.Linq;
using System.Windows.Forms;
using API.Services;

namespace Tubes_KPL_GUI
{
    /// <summary>
    /// Form Dashboard yang menampilkan berbagai form yang bisa dipilih pengguna.
    /// </summary>
    public partial class Dashboard : Form
    {
        // Menyimpan nama pengguna yang sedang login
        private readonly string _username;

        // Menyimpan form yang sedang aktif di dalam dashboard
        private Form? _activeForm;

        /// <summary>
        /// Konstruktor untuk menginisialisasi form Dashboard dengan username.
        /// </summary>
        /// <param name="username">Username pengguna yang sedang login.</param>
        public Dashboard(string username)
        {
            InitializeComponent(); // Inisialisasi komponen UI
            _username = username; // Menyimpan username
        }

        /// <summary>
        /// Event handler yang dijalankan ketika form Dashboard dimuat.
        /// Memperbarui status tugas sebelum menampilkan form beranda.
        /// </summary>
        private async void Dashboard_Load(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync(); // Memperbarui status tugas sebelum menampilkan beranda
            LoadForm(new FormBeranda(_username)); // Menampilkan form Beranda
        }

        /// <summary>
        /// Memuat form baru dan mengganti form yang aktif di panel utama.
        /// </summary>
        /// <param name="childForm">Form baru yang akan dimuat.</param>
        private void LoadForm(Form childForm)
        {
            if (_activeForm != null) // Menutup form yang sedang aktif
                _activeForm.Close();

            _activeForm = childForm; // Menetapkan form baru sebagai form aktif
            childForm.TopLevel = false; // Menetapkan form baru agar berada di dalam panel
            childForm.FormBorderStyle = FormBorderStyle.None; // Menghilangkan border form
            childForm.Dock = DockStyle.Fill; // Mengatur form untuk mengisi panel

            panelMain.Controls.Clear(); // Menghapus kontrol yang ada di panel utama
            panelMain.Controls.Add(childForm); // Menambahkan form baru ke panel utama
            panelMain.Tag = childForm; // Menandai form baru

            childForm.BringToFront(); // Membawa form baru ke depan
            childForm.Show(); // Menampilkan form baru
        }

        /// <summary>
        /// Event handler untuk tombol Beranda yang memperbarui status tugas dan memuat form Beranda.
        /// </summary>
        private async void btnBeranda_Click(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync(); // Memperbarui status tugas
            LoadForm(new FormBeranda(_username)); // Memuat form Beranda
        }

        /// <summary>
        /// Event handler untuk tombol Tambah yang memperbarui status tugas dan memuat form AddTask.
        /// </summary>
        private async void btnTambah_Click(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync(); // Memperbarui status tugas
            LoadForm(new FormAddTask(_username)); // Memuat form untuk menambah tugas
        }

        /// <summary>
        /// Event handler untuk tombol Edit yang memperbarui status tugas dan memuat form EditTask.
        /// </summary>
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync(); // Memperbarui status tugas
            LoadForm(new FormEditTask(_username)); // Memuat form untuk mengedit tugas
        }

        /// <summary>
        /// Event handler untuk tombol Tandai yang memperbarui status tugas dan memuat form MarkDone.
        /// </summary>
        private async void btnTandai_Click(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync(); // Memperbarui status tugas
            LoadForm(new FormMarkDone(_username)); // Memuat form untuk menandai tugas selesai
        }

        /// <summary>
        /// Event handler untuk tombol Hapus yang memperbarui status tugas dan memuat form DeleteTask.
        /// </summary>
        private async void btnHapus_Click(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync(); // Memperbarui status tugas
            LoadForm(new FormDeleteTask(_username)); // Memuat form untuk menghapus tugas
        }

        /// <summary>
        /// Event handler untuk tombol Riwayat yang memperbarui status tugas dan (opsional) memuat form Riwayat.
        /// </summary>
        private async void btnRiwayat_Click(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync(); // Memperbarui status tugas
            LoadForm(new FormRiwayat(_username)); // Menampilkan form Riwayat (dikomentari)
        }

        /// <summary>
        /// Event handler untuk tombol Logout yang mengonfirmasi logout dan keluar jika berhasil.
        /// </summary>
        private async void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes) // Jika pengguna memilih Yes
            {
                bool logoutSuccess = await ToDoListSingleton.Instance.LogoutAsync(_username); // Melakukan logout

                if (logoutSuccess) // Jika logout berhasil
                {
                    new FormLogin().Show(); // Menampilkan form login
                    this.Close(); // Menutup form Dashboard
                    Console.WriteLine("Berhasil logout."); // Menampilkan pesan log
                }
                else
                {
                    MessageBox.Show("Logout gagal, silakan coba lagi.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error); // Menampilkan pesan error
                }
            }
        }

        /// <summary>
        /// Fungsi untuk memperbarui status tugas menggunakan ToDoListSingleton.
        /// </summary>
        private async Task UpdateTaskStatusAsync()
        {
            var response = await ToDoListSingleton.Instance.UpdateTaskStatusAsync(_username); // Memperbarui status tugas
            if (response.Success) // Jika pembaruan status berhasil
            {
                Console.WriteLine("Status tugas berhasil diperbarui.");
            }
            else
            {
                Console.WriteLine($"Gagal memperbarui status tugas: {response.Message}"); // Menampilkan pesan error jika gagal
            }
        }
    }
}
