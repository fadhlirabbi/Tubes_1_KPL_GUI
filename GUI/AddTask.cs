using API.Model;
using GUI;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelTask = API.Model.Task;
using SystemTask = System.Threading.Tasks.Task;

namespace GUI
{
    public partial class AddTask : Form
    {
        private readonly string _username;

        public AddTask(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            string taskName = taskNameTextBox.Text.Trim();
            string description = descriptionTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(taskName) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Nama tugas dan deskripsi tidak boleh kosong.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int day = int.Parse(dayTextBox.Text);
            int month = int.Parse(monthTextBox.Text);
            int year = int.Parse(yearTextBox.Text);
            int hour = int.Parse(hourTextBox.Text);
            int minute = int.Parse(minuteTextBox.Text);

            Deadline deadline = new Deadline
            {
                Day = day,
                Month = month,
                Year = year,
                Hour = hour,
                Minute = minute
            };

            var task = new ModelTask(taskName, description, deadline, _username);

            ApiResponse apiResponse = await ToDoListService.Instance.AddTaskAsync(task);

            Debug.WriteLine($"[DEBUG] API Response Status Code: {apiResponse.StatusCode}");
            Debug.WriteLine($"[DEBUG] API Response Message: {apiResponse.Message}");


            if (apiResponse.StatusCode > 200 && apiResponse.StatusCode <= 300 || apiResponse.StatusCode == 0)
            {
                MessageBox.Show($"Tugas berhasil ditambahkan. Status Code: {apiResponse.StatusCode}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else if (apiResponse.StatusCode == 400)
            {
                if (apiResponse.Message.Contains("Tugas dengan nama, deskripsi, dan deadline yang sama sudah ada"))
                {
                    MessageBox.Show($"Gagal menambahkan tugas: {apiResponse.Message}. Status Code: {apiResponse.StatusCode}", "Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Gagal menambahkan tugas: {apiResponse.Message}. Status Code: {apiResponse.StatusCode}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (apiResponse.StatusCode == 401)
            {
                MessageBox.Show($"Gagal autentikasi. Status Code: {apiResponse.StatusCode}", "Autentikasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (apiResponse.StatusCode == 404)
            {
                MessageBox.Show($"Tugas tidak ditemukan. Status Code: {apiResponse.StatusCode}", "Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void AddTask_Load(object sender, EventArgs e)
        {

        }

        private void deadlineLabel_Click(object sender, EventArgs e)
        {

        }

        private void taskNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}