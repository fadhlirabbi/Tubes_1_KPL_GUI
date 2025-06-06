using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
        private readonly ToDoListService _toDoListService;

        public Login()
        {
            InitializeComponent();
            _toDoListService = ToDoListService.Instance; // Mendapatkan instance singleton
        }

        private async void MasukButton_Click(object sender, EventArgs e)
        {
            string namaPengguna = userTextBox.Text;
            string kataSandi = passTextBox.Text;

            // 1. Validasi input tidak kosong
            if (string.IsNullOrWhiteSpace(namaPengguna) || string.IsNullOrWhiteSpace(kataSandi))
            {
                MessageBox.Show("Nama Pengguna dan Kata Sandi tidak boleh kosong.", "Gagal Masuk", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //2. Memanggil service untuk login
            bool loginSuccess = await _toDoListService.LoginAsync(namaPengguna, kataSandi);

            if (loginSuccess)
            {
                Dashboard dashboard = new Dashboard(namaPengguna);
                dashboard.Show();
                this.Hide();
            }
            else
            {               
                MessageBox.Show("Nama Pengguna atau Kata Sandi salah. Silakan coba lagi.", "Gagal Masuk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DaftarButton_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }
    }
}
