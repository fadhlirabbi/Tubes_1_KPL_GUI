using API.Services;

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
            InitializeComponent(GetBtnBeranda());
            _username = username;
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync();
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

        private async void btnBeranda_Click(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync();
            LoadForm(new FormBeranda(_username));
        }

        private async void btnTambah_Click(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync();
            LoadForm(new FormAddTask(_username));
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync();
            LoadForm(new FormEditTask(_username));
        }

        private async void btnTandai_Click(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync();
            LoadForm(new FormMarkDone(_username));
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync();
            LoadForm(new FormDeleteTask(_username));
        }

        private async void btnRiwayat_Click(object sender, EventArgs e)
        {
            await UpdateTaskStatusAsync();
            // LoadForm(new FormRiwayat(_username));
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

        private async Task UpdateTaskStatusAsync()
        {
            var response = await ToDoListSingleton.Instance.UpdateTaskStatusAsync(_username);
            if (response.Success)
            {
                Console.WriteLine("Status tugas berhasil diperbarui.");
            }
            else
            {
                Console.WriteLine($"Gagal memperbarui status tugas: {response.Message}");
            }
        }
    }
}
