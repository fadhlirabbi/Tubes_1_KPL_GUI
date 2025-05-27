using System;
using System.Windows.Forms;
using API.Services;

namespace GUI
{
    public partial class Form1 : Form
    {
        private readonly LoginRegisterService _authService = new();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            bool success = await _authService.TryLoginAsync(username, password);
            if (success)
            {
                lblStatus.Text = "";
                MessageBox.Show("Login berhasil!");
            }
            else
            {
                lblStatus.Text = "Username atau password salah.";
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var reg = new Register();
            reg.Show();
            this.Hide();
        }
    }
}
