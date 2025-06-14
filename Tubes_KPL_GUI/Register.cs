﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Tubes_KPL_GUI
{
    public partial class Register : Form
    {
        private readonly ToDoListSingleton _toDoListSingleton;

        public Register()
        {
            InitializeComponent();
            _toDoListSingleton = ToDoListSingleton.Instance;
            passTextBox.PasswordChar = '●';
        }

        // Event handler untuk tombol Daftar
        private async void DaftarBtn_Click(object sender, EventArgs e)
        {
            string username = userTextBox.Text.Trim();
            string password = passTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Nama Pengguna dan Kata Sandi tidak boleh kosong.",
                    "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var passwordPattern = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$");
            if (!passwordPattern.IsMatch(password))
            {
                MessageBox.Show(
                    "Kata Sandi harus minimal 8 karakter dan mengandung:\n- 1 huruf kapital\n- 1 huruf kecil\n- 1 angka\n- 1 karakter khusus.",
                    "Format Kata Sandi Tidak Valid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            bool registered = await _toDoListSingleton.RegisterAsync(username, password);
            if (registered)
            {
                MessageBox.Show("Pendaftaran berhasil! Silakan login.",
                    "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var login = new FormLogin();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Pendaftaran gagal. Nama pengguna mungkin sudah digunakan.",
                    "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler untuk tombol Kembali ke halaman Login
        private void KembaliBtn_Click(object sender, EventArgs e)
        {
            var login = new FormLogin();
            login.Show();
            this.Hide();
        }

        // Event handler untuk checkbox Lihat Sandi
        private void LihatSandi_CheckedChanged(object sender, EventArgs e)
        {
            if (lihatSandi.Checked)
                passTextBox.PasswordChar = '\0';
            else
                passTextBox.PasswordChar = '●';
        }
    }
}
