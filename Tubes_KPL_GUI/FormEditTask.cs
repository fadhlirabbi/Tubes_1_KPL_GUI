using System;
using System.Windows.Forms;
using API.Model;
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

        // Event handler untuk tombol 'Perbarui' yang memperbarui data tugas.
        private async void BtnUpdateTask_Click(object sender, EventArgs e)
        {
            string oldTaskName = txtOldTaskName.Text.Trim();
            string newTaskName = txtTaskName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (!IsInputValid(oldTaskName, newTaskName, description))
            {
                ShowError("Semua field harus diisi.");
                return;
            }

            if (!TryParseDeadline(out Deadline deadline))
            {
                ShowError("Input tanggal atau waktu tidak valid.");
                return;
            }

            var updatedTask = new ModelTask(newTaskName, description, deadline, _username);
            bool isUpdated = await ToDoListSingleton.Instance.EditTaskAsync(_username, oldTaskName, updatedTask);

            MessageBox.Show(
                isUpdated ? "Task berhasil diperbarui!" : "Gagal memperbarui task.",
                isUpdated ? "Sukses" : "Kesalahan",
                MessageBoxButtons.OK,
                isUpdated ? MessageBoxIcon.Information : MessageBoxIcon.Error
            );
        }

        // Validasi input teks kosong.
        private bool IsInputValid(string oldTaskName, string newTaskName, string description)
        {
            return !string.IsNullOrWhiteSpace(oldTaskName) &&
                   !string.IsNullOrWhiteSpace(newTaskName) &&
                   !string.IsNullOrWhiteSpace(description);
        }

        // Mencoba parsing deadline dari input pengguna.
        private bool TryParseDeadline(out Deadline deadline)
        {
            deadline = null;

            if (!int.TryParse(txtDay.Text.Trim(), out int day) ||
                !int.TryParse(txtYear.Text.Trim(), out int year) ||
                !int.TryParse(txtHour.Text.Trim(), out int hour) ||
                !int.TryParse(txtMinute.Text.Trim(), out int minute))
            {
                ShowError("Input tanggal, tahun, jam, atau menit tidak valid.");
                return false;
            }

            int month = GetMonthFromText(txtMonth.Text.Trim().ToLower());
            if (month == 0)
            {
                ShowError("Nama bulan tidak valid.");
                return false;
            }

            if (hour < 0 || hour > 23)
            {
                ShowError("Jam harus antara 0 dan 23.");
                return false;
            }

            if (minute < 0 || minute > 59)
            {
                ShowError("Menit harus antara 0 dan 59.");
                return false;
            }

            deadline = new Deadline
            {
                Day = day,
                Month = month,
                Year = year,
                Hour = hour,
                Minute = minute
            };

            return true;
        }

        // Menampilkan pesan error umum.
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Mengonversi nama bulan menjadi angka (1-12).
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

        // Dikosongkan karena tidak ada aksi yang dilakukan saat label diklik
        private void lblDay_Click(object sender, EventArgs e)
        {

        }
    }
}
