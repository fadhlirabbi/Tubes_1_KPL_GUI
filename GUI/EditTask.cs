using System;
using System.Windows.Forms;
using API.Model;
using ModelTask = API.Model.Task;

namespace GUI
{
    public partial class EditTask : Form
    {
        private readonly string _username;
        private readonly ModelTask _task;

        public EditTask(string username, ModelTask task)
        {
            InitializeComponent();
            _username = username;
            _task = task;

            // Isi kontrol dengan data tugas yang dipilih
            nameTextBox.Text = _task.Name;
            descriptionTextBox.Text = _task.Description;

            // Validasi tahun untuk deadline
            int validYear = _task.Deadline.Year >= 1 ? _task.Deadline.Year : 2000;  // Otomatis gunakan tahun default jika tahun tidak valid

            // Pastikan tahun tidak lebih kecil dari 1
            if (validYear < 1)
            {
                validYear = 2000;
            }

            // Handle invalid tanggal
            try
            {
                deadlinePicker.Value = new DateTime(validYear, _task.Deadline.Month, _task.Deadline.Day, _task.Deadline.Hour, _task.Deadline.Minute, 0);
            }
            catch (ArgumentOutOfRangeException)
            {
                deadlinePicker.Value = new DateTime(2000, 1, 1, 0, 0, 0); 
                MessageBox.Show("Tugas memiliki tanggal yang tidak valid. Tanggal telah diatur ulang.", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            // Ambil data yang sudah diperbarui dari form
            string newName = nameTextBox.Text;
            string newDescription = descriptionTextBox.Text;
            DateTime newDeadline = deadlinePicker.Value;

            var updatedTask = new ModelTask(newName, newDescription, new Deadline
            {
                Day = newDeadline.Day,
                Month = newDeadline.Month,
                Year = newDeadline.Year,
                Hour = newDeadline.Hour,
                Minute = newDeadline.Minute
            }, _username);

            // Menggunakan ToDoListService untuk melakukan update tugas
            var success = await ToDoListService.Instance.EditTaskAsync(_username, _task.Name, updatedTask);

            if (success)
            {
                MessageBox.Show("Tugas berhasil diubah.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Gagal mengubah tugas.");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
