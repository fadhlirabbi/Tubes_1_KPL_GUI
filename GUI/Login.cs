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
        public Login()
        {
            InitializeComponent();
        }

        private async void Masuk_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string passWord = textBox2.Text;

            // 1. Validasi input tidak kosong
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(passWord))
            {
                MessageBox.Show("Nama Pengguna dan Kata Sandi tidak boleh kosong.", "Gagal Masuk", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //2. Memanggil service untuk login
            bool loginSuccess = await ToDoListService.Instance.LoginAsync(userName, passWord);

            if (loginSuccess)
            {
                Dashboard dashboard = new Dashboard(userName);
                dashboard.Show();
                this.Hide();
            }
            else
            {               
                MessageBox.Show("Nama Pengguna atau Kata Sandi salah. Silakan coba lagi.", "Gagal Masuk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Daftar_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }
    }
}
