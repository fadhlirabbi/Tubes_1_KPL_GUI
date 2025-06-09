using API.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelTask = API.Model.Task;
using SystemTask = System.Threading.Tasks.Task;

namespace Tubes_KPL_GUI
{
    public partial class FormAddTask : Form
    {
        private readonly string _username;

        public FormAddTask(string username)
        {
            InitializeComponent();
            _username = username;
        }

        // Event handler untuk tombol 'Tambah' untuk menambahkan tugas
        private async void btnAddTask_Click(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(taskName) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Nama tugas dan deskripsi tidak boleh kosong.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string monthText = txtMonth.Text.Trim().ToLower();
            int month = GetMonthFromText(monthText);
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

            var task = new ModelTask(taskName, description, deadline, _username);

            ApiResponse apiResponse = await ToDoListSingleton.Instance.AddTaskAsync(task);

            if (apiResponse.StatusCode >= 200 && apiResponse.StatusCode < 300 || apiResponse.StatusCode == 0)
            {
                MessageBox.Show("Tugas berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else

            {
                HandleApiError(apiResponse);
            }
        }

        // Fungsi untuk mengonversi nama bulan menjadi angka
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

        // Fungsi untuk menangani error API
        private void HandleApiError(ApiResponse apiResponse)
        {
            if (apiResponse.StatusCode == 400)
            {
                if (apiResponse.Message.Contains("Tugas dengan nama, deskripsi, dan deadline yang sama sudah ada"))
                {
                    MessageBox.Show($"Gagal menambahkan tugas: {apiResponse.Message}.", "Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Gagal menambahkan tugas: {apiResponse.Message}.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (apiResponse.StatusCode == 401)
            {
                MessageBox.Show($"Gagal autentikasi. Status Code: {apiResponse.StatusCode}", "Autentikasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (apiResponse.StatusCode == 500)
            {
                MessageBox.Show($"Terjadi kesalahan server. Status Code: {apiResponse.StatusCode}", "Kesalahan Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Terjadi kesalahan yang tidak diketahui. Status Code: {apiResponse.StatusCode}", "Kesalahan Tidak Dikenal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormAddTask_Load(object sender, EventArgs e)
        {
            // Kosong atau bisa tambahkan inisialisasi jika diperlukan
        }
    }
}

