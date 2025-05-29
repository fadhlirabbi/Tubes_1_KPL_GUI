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
            
            string username = textBox1.Text;            
            string password = textBox2.Text;

            // 1. Validasi input tidak kosong
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Nama Pengguna dan Kata Sandi tidak boleh kosong.", "Kesalahan Pendaftaran", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validasi kompleksitas password
            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

            if (!passwordRegex.IsMatch(password))
            {
                MessageBox.Show(
                    "Kata Sandi harus minimal 8 karakter dan mengandung setidaknya satu huruf kapital, satu huruf kecil, satu digit, dan satu karakter khusus (misalnya, @$!%*?&).",
                    "Pelanggaran Kebijakan Kata Sandi",
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
                this.Hide(); 
                Login loginForm = new Login(); 
                loginForm.Show(); 
            }
            else
            {
                MessageBox.Show("Pendaftaran gagal. Mungkin karena Nama Pengguna sudah ada atau terjadi kesalahan pada server.", "Kesalahan Pendaftaran", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide(); 
        }
    }
}
