using API.Model;
using System;
using System.Windows.Forms;
using ModelTask = API.Model.Task;
using SystemTask = System.Threading.Tasks.Task;

namespace Tubes_KPL_GUI
{
    public partial class FormDeleteTask : Form
    {
        private readonly string _username;

        private const string ErrorTitle = "Kesalahan";
        private const string SuccessTitle = "Sukses";
        private const string InvalidInputMessage = "Nama tugas dan deskripsi tidak boleh kosong.";
        private const string InvalidDateTimeMessage = "Input tanggal atau waktu tidak valid.";
        private const string InvalidMonthMessage = "Nama bulan tidak valid.";

        public FormDeleteTask(string username)
        {
            InitializeComponent();
            _username = username ?? throw new ArgumentNullException(nameof(username));
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(taskName) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show(InvalidInputMessage, ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!TryParseDateTime(out int day, out int month, out int year, out int hour, out int minute))
            {
                return;
            }

            var apiResponse = await ToDoListSingleton.Instance.DeleteTaskAsync(_username, taskName, description, day, month, year, hour, minute);

            if (apiResponse.StatusCode >= 200 && apiResponse.StatusCode < 300 || apiResponse.StatusCode == 0)
            {
                MessageBox.Show(apiResponse.Message ?? "Tugas berhasil dihapus!", SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                HandleApiError(apiResponse);
            }
        }


        private bool TryParseDateTime(out int day, out int month, out int year, out int hour, out int minute)
        {
            day = year = hour = minute = month = 0;

            if (!int.TryParse(txtDay.Text, out day) ||
                !int.TryParse(txtYear.Text, out year) ||
                !int.TryParse(txtHour.Text, out hour) ||
                !int.TryParse(txtMinute.Text, out minute))
            {
                MessageBox.Show(InvalidDateTimeMessage, ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string monthText = txtMonth.Text.Trim().ToLower();
            month = GetMonthFromText(monthText);

            if (month == 0)
            {
                MessageBox.Show(InvalidMonthMessage, ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private int GetMonthFromText(string monthText)
        {
            return monthText switch
            {
                "januari" => 1,
                "februari" => 2,
                "maret" => 3,
                "april" => 4,
                "mei" => 5,
                "juni" => 6,
                "juli" => 7,
                "agustus" => 8,
                "september" => 9,
                "oktober" => 10,
                "november" => 11,
                "desember" => 12,
                _ => 0,
            };
        }

        private void HandleApiError(ApiResponse apiResponse)
        {
            if (apiResponse == null)
            {
                MessageBox.Show("Terjadi kesalahan tak terduga.", ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string title = ErrorTitle;
            string message = $"Terjadi kesalahan. Status Code: {apiResponse.StatusCode}";

            switch (apiResponse.StatusCode)
            {
                case 400:
                    title = "Permintaan Tidak Valid";
                    message = !string.IsNullOrWhiteSpace(apiResponse.Message)
                        ? apiResponse.Message
                        : "Data yang dikirim tidak valid.";
                    break;
                case 401:
                    title = "Autentikasi Gagal";
                    message = "Token atau autentikasi tidak valid.";
                    break;
                case 404:
                    title = "Tugas Tidak Ditemukan";
                    message = "Tugas yang ingin dihapus tidak ditemukan.";
                    break;
                case 500:
                    title = "Kesalahan Server";
                    message = "Terjadi kesalahan pada server.";
                    break;
                default:
                    title = "Kesalahan";
                    message = !string.IsNullOrWhiteSpace(apiResponse.Message)
                        ? apiResponse.Message
                        : $"Kesalahan tidak diketahui. Status: {apiResponse.StatusCode}";
                    break;
            }

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FormDeleteTask_Load(object sender, EventArgs e)
        {
            // Opsional: inisialisasi UI
        }
    }
}
