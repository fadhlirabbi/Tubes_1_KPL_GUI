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

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // 1. Validasi input tidak kosong
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Nama Pengguna dan Kata Sandi tidak boleh kosong.", "Gagal Masuk", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //2. Memanggil service untuk login
            bool loginSuccess = await ToDoListService.Instance.LoginAsync(username, password);

            if (loginSuccess)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {               
                MessageBox.Show("Nama Pengguna atau Kata Sandi salah. Silakan coba lagi.", "Gagal Masuk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }
    }
}
