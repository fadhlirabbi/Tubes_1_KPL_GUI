using API.Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace Tubes_KPL_GUI
{
    public partial class Dashboard : Form
    {
        private readonly string _username;
        private Form? _activeForm;

        private string? _loggedInUser = null;
        private TaskClientService? _taskClient = null;

        public Dashboard(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadForm(new FormBeranda(_username));
        }

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

        private void btnBeranda_Click(object sender, EventArgs e)
        {
            LoadForm(new FormBeranda(_username));
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            //LoadForm(new FormAddTask(_username));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //LoadForm(new FormEditTask(_username));
        }

        private void btnTandai_Click(object sender, EventArgs e)
        {
            //LoadForm(new FormMarkDone(_username));
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            //LoadForm(new FormDeleteTask(_username));
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            //LoadForm(new FormRiwayat(_username));
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Apakah Anda yakin ingin keluar?",
                                          "Konfirmasi Logout",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool logoutSuccess = await ToDoListSingleton.Instance.LogoutAsync(_username);

                if (logoutSuccess)
                {
                    _loggedInUser = null;
                    _taskClient = null;

                    new FormLogin().Show();
                    this.Close();
                    Console.WriteLine("Berhasil logout.");
                }
                else
                {
                    MessageBox.Show("Logout gagal, silakan coba lagi.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
