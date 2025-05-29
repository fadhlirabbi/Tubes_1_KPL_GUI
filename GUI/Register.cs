using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI
{
    public partial class Register : Form
    {
        private readonly ToDoListService _toDoListService;

        public Register()
        {
            InitializeComponent();
            _toDoListService = ToDoListService.Instance; // Mendapatkan instance singleton
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Mengasumsikan input username dinamakan textBox1
            string username = textBox1.Text;
            // Mengasumsikan input password dinamakan textBox2
            string password = textBox2.Text;

            // 1. Validasi input tidak kosong
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username dan password tidak boleh kosong.", "Kesalahan Pendaftaran", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validasi kompleksitas password
            // Minimal 8 karakter, satu huruf kapital, satu huruf kecil, satu digit, satu karakter khusus
            // Catatan: Regex memastikan hanya karakter dari A-Z, a-z, 0-9, dan karakter khusus yang ditentukan.
            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

            if (!passwordRegex.IsMatch(password))
            {
                MessageBox.Show(
                    "Password harus minimal 8 karakter dan mengandung setidaknya satu huruf kapital, satu huruf kecil, satu digit, dan satu karakter khusus (misalnya, @$!%*?&).",
                    "Pelanggaran Kebijakan Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 3. Mencoba untuk mendaftar menggunakan ToDoListService
            bool isRegistered = await _toDoListService.RegisterAsync(username, password);

            if (isRegistered)
            {
                MessageBox.Show("Pendaftaran berhasil!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Opsional, navigasi ke form login atau tutup form pendaftaran
                this.Hide(); // Menyembunyikan form saat ini
                Login loginForm = new Login(); // Mengasumsikan kelas form Login dinamakan Login
                loginForm.Show(); // Menampilkan form login
            }
            else
            {
                // Jika RegisterAsync mengembalikan false, artinya panggilan API gagal (misalnya, username sudah ada).
                // ToDoListService sudah mencatat pesan spesifik dari API di konsol debug.
                MessageBox.Show("Pendaftaran gagal. Mungkin karena username sudah ada atau terjadi kesalahan pada server.", "Kesalahan Pendaftaran", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide(); // Menyembunyikan form saat ini
        }
    }
}
