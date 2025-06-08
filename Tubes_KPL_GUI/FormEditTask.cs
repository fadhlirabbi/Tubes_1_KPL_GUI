using API.Model;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using ModelTask = API.Model.Task;

namespace Tubes_KPL_GUI
{
    public partial class FormEditTask : Form
    {
        private readonly string _username;

        public FormEditTask(string username)
        {
            InitializeComponent();
            _username = username;
        }

        // Event handler untuk tombol 'Perbarui' untuk memperbarui tugas
        private async void btnUpdateTask_Click(object sender, EventArgs e)
        {
            string oldTaskName = txtOldTaskName.Text.Trim();
            string taskName = txtTaskName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(oldTaskName) || string.IsNullOrWhiteSpace(taskName) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Semua field harus diisi.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtDay.Text, out int day) ||
                !int.TryParse(txtYear.Text, out int year) ||
                !int.TryParse(txtHour.Text, out int hour) ||
                !int.TryParse(txtMinute.Text, out int minute))
            {
                MessageBox.Show("Input tanggal atau waktu tidak valid.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int month = GetMonthFromText(txtMonth.Text.Trim().ToLower());
            if (month == 0)
            {
                MessageBox.Show("Nama bulan tidak valid.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Deadline deadline = new Deadline
            {
                Day = day,
                Month = month,
                Year = year,
                Hour = hour,
                Minute = minute
            };

            var updatedTask = new ModelTask(taskName, description, deadline, _username);
            bool response = await ToDoListSingleton.Instance.EditTaskAsync(_username, oldTaskName, updatedTask);

            if (response)
            {
                MessageBox.Show("Task berhasil diperbarui!");
            }
            else
            {
                MessageBox.Show("Gagal memperbarui task.");
            }

        }

        // Mengonversi nama bulan dalam teks menjadi angka
        private int GetMonthFromText(string monthText)
        {
            switch (monthText)
            {
                case "januari": return 1;
                case "februari": return 2;
                case "maret": return 3;
                case "april": return 4;
                case "mei": return 5;
                case "juni": return 6;
                case "juli": return 7;
                case "agustus": return 8;
                case "september": return 9;
                case "oktober": return 10;
                case "november": return 11;
                case "desember": return 12;
                default: return 0;
            }
        }

        private void lblDay_Click(object sender, EventArgs e)
        {

        }
    }
}
