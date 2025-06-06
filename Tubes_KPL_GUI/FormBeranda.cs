using System;
using System.Linq;
using System.Windows.Forms;
using API.Model;
using SystemTask = System.Threading.Tasks.Task;

namespace Tubes_KPL_GUI
{
    public partial class FormBeranda : Form
    {
        private readonly string _username;

        public FormBeranda(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private async void FormBeranda_Load(object sender, EventArgs e)
        {
            welcomeLabel.Text = $"Selamat datang, {_username}";
            await LoadIncompletedTasksAsync();
        }

        private async SystemTask LoadIncompletedTasksAsync()
        {
            try
            {
                var tasks = await ToDoListSingleton.Instance.GetTasksByStatusAsync(_username, Status.Incompleted);
                var sortedTasks = tasks.OrderBy(t =>
                    new DateTime(t.Deadline.Year, t.Deadline.Month, t.Deadline.Day, t.Deadline.Hour, t.Deadline.Minute, 0)
                ).ToList();

                taskGridView.DataSource = sortedTasks;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat tugas: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
