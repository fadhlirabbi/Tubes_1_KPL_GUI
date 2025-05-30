using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Model;
using StatusModel = API.Model.Status;
using ModelTask = API.Model.Task;
using SystemTask = System.Threading.Tasks.Task;

namespace GUI
{
    public partial class Dashboard : Form
    {
        private readonly string _username;

        public Dashboard(string username)
        {
            InitializeComponent();
            _username = username;
            welcomeLabel.Text = $"Selamat datang, {_username}";
            _ = LoadTasksAsync();
        }

        private async SystemTask LoadTasksAsync()
        {
            try
            {
                var tasks = await ToDoListService.Instance.GetTasksByStatusAsync(_username, StatusModel.Incompleted);
                taskGridView.DataSource = tasks;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat tugas: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void addTaskButton_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddTask(_username))
            {
                var result = addForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _ = LoadTasksAsync();
                }
            }
        }
        private void editTaskButton_Click(object sender, EventArgs e)
        {
            if (taskGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih task untuk diedit.");
                return;
            }

            var task = (ModelTask)taskGridView.SelectedRows[0].DataBoundItem;

            using (var editForm = new EditTask(_username, task))
            {
                var result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _ = LoadTasksAsync();
                }
            }
        }

        private void welcomeLabel_Click(object sender, EventArgs e)
        {

        }

        private async void deleteTaskButton_Click(object sender, EventArgs e)
        {
            if (taskGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih tugas untuk dihapus.");
                return;
            }

            var task = (ModelTask)taskGridView.SelectedRows[0].DataBoundItem;
            var d = task.Deadline;
            bool deleted = await ToDoListService.Instance.DeleteTaskAsync(_username, task.Name, task.Description, d.Day, d.Month, d.Year, d.Hour, d.Minute);

            if (deleted)
            {
                MessageBox.Show("Tugas berhasil dihapus.");
                await LoadTasksAsync();
            }
        }

        private async void markCompletedButton_Click(object sender, EventArgs e)
        {
            if (taskGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih tugas untuk ditandai selesai.");
                return;
            }

            var task = (ModelTask)taskGridView.SelectedRows[0].DataBoundItem;
            var d = task.Deadline;
            bool completed = await ToDoListService.Instance.MarkTaskAsCompletedAsync(_username, task.Name, task.Description, d.Day, d.Month, d.Year, d.Hour, d.Minute);

            if (completed)
            {
                MessageBox.Show("Tugas ditandai sebagai selesai.");
                await LoadTasksAsync();
            }
        }

        private async void reminderButton_Click(object sender, EventArgs e)
        {
            var reminders = await ToDoListService.Instance.GetRemindersAsync(_username);
            string message = reminders.Count > 0
                ? string.Join("\n", reminders)
                : "Tidak ada reminder saat ini.";
            MessageBox.Show(message, "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void historyButton_Click(object sender, EventArgs e)
        {
            var history = await ToDoListService.Instance.GetUserTasksHistoryAsync(_username);
            if (history.Count == 0)
            {
                MessageBox.Show("Belum ada riwayat tugas.");
                return;
            }

            var message = string.Join("\n", history.Select(t =>
                $"- {t.Name} ({t.Status}) pada {t.Deadline.Day}/{t.Deadline.Month}/{t.Deadline.Year} {t.Deadline.Hour:D2}:{t.Deadline.Minute:D2}"));

            MessageBox.Show(message, "Riwayat Tugas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
