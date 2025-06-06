using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Tubes_KPL_GUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Nama Pengguna dan Kata Sandi tidak boleh kosong.",
                                "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = await ToDoListSingleton.Instance.LoginAsync(username, password);

            if (success)
            {
                var dashboard = new Dashboard(username);
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nama Pengguna atau Kata Sandi salah.",
                                "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
