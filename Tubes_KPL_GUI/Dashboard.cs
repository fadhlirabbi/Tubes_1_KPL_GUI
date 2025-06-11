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
        private readonly string _username;
        private Form? _activeForm;

        /// <summary>
        /// Konstruktor untuk menginisialisasi form Dashboard dengan username.
        /// </summary>
        /// <param name="username">Username pengguna yang sedang login.</param>
        public Dashboard(string username)
        {
            InitializeComponent(); 
            _username = username; 
        }

        /// <summary>
        /// Event handler yang dijalankan ketika form Dashboard dimuat.
        /// Memperbarui status tugas sebelum menampilkan form beranda.
        /// </summary>
        private async void Dashboard_Load(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync(); 
            LoadForm(new FormBeranda(_username)); 
        }

        /// <summary>
        /// Memuat form baru dan mengganti form yang aktif di panel utama.
        /// </summary>
        /// <param name="childForm">Form baru yang akan dimuat.</param>
        private void LoadForm(Form childForm)
        {
            if (_activeForm != null) 
                _activeForm.Close();

            _activeForm = childForm; 
            childForm.TopLevel = false; 
            childForm.FormBorderStyle = FormBorderStyle.None; 
            childForm.Dock = DockStyle.Fill; 

            panelMain.Controls.Clear();
            panelMain.Controls.Add(childForm); 
            panelMain.Tag = childForm; 

            childForm.BringToFront(); 
            childForm.Show(); 
        }

        /// <summary>
        /// Event handler untuk tombol Beranda yang memperbarui status tugas dan memuat form Beranda.
        /// </summary>
        private async void btnBeranda_Click(object sender, EventArgs e)
        {
            try
            {
                await UpdateTaskStatusAsync();
                LoadForm(new FormBeranda(_username));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memperbarui status tugas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler untuk tombol Tambah yang memperbarui status tugas dan memuat form AddTask.
        /// </summary>
        private async void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                await UpdateTaskStatusAsync();
                LoadForm(new FormAddTask(_username));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memperbarui status tugas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler untuk tombol Edit yang memperbarui status tugas dan memuat form EditTask.
        /// </summary>
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                await UpdateTaskStatusAsync();
                LoadForm(new FormEditTask(_username));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memperbarui status tugas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        /// <summary>
        /// Event handler untuk tombol Tandai yang memperbarui status tugas dan memuat form MarkDone.
        /// </summary>
        private async void btnTandai_Click(object sender, EventArgs e)
        {
            try
            {
                await UpdateTaskStatusAsync();
                LoadForm(new FormMarkDone(_username));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memperbarui status tugas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler untuk tombol Hapus yang memperbarui status tugas dan memuat form DeleteTask.
        /// </summary>
        private async void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                await UpdateTaskStatusAsync();
                LoadForm(new FormDeleteTask(_username));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memperbarui status tugas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler untuk tombol Riwayat yang memperbarui status tugas dan (opsional) memuat form Riwayat.
        /// </summary>
        private async void btnRiwayat_Click(object sender, EventArgs e)
        {
            try
            {
                await UpdateTaskStatusAsync();
                LoadForm(new FormRiwayat(_username));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler untuk tombol Logout yang mengonfirmasi logout dan keluar jika berhasil.
        /// </summary>
        private async void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes) 
            {
                bool logoutSuccess = await ToDoListSingleton.Instance.LogoutAsync(_username); 

                if (logoutSuccess)
                {
                    new FormLogin().Show();
                    this.Close();
                    Console.WriteLine("Berhasil logout."); 
                    ToDoListSingleton.Instance.ResetAllLoginStatus();
                }
                else
                {
                    MessageBox.Show("Logout gagal, silakan coba lagi.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
        }

        /// <summary>
        /// Fungsi untuk memperbarui status tugas menggunakan ToDoListSingleton.
        /// </summary>
        private async Task UpdateTaskStatusAsync()
        {
            var response = await ToDoListSingleton.Instance.UpdateTaskStatusAsync(_username);
            if (response.Success)
            {
                Console.WriteLine("Status tugas berhasil diperbarui.");
            }
            else
            {
                Console.WriteLine($"Gagal memperbarui status tugas: {response.Message}");
            }
        }
    }
}
