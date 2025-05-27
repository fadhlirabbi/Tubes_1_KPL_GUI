using System;
using System.Windows.Forms;
using API.Services;

namespace GUI
{
    public partial class Register : Form
    {
        private readonly LoginRegisterService _registerService = new();

        public Register()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblStatus.Text = "Username dan password tidak boleh kosong.";
                return;
            }

            await _registerService.Register(username, password);
            MessageBox.Show("Registrasi berhasil!");

            var login = new Form1();
            login.Show();
            this.Close();
        }

        private void lnkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var login = new Form1();
            login.Show();
            this.Close();
        }
    }
}
