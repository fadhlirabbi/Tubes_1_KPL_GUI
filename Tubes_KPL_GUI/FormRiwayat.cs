using System;
using System.Collections.Generic;
using System.Windows.Forms;
using API.Model; 

namespace Tubes_KPL_GUI
{
    public partial class FormRiwayat : Form
    {
        private readonly string _username;

        public FormRiwayat(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private async void FormRiwayat_Load(object sender, EventArgs e)
        {
            await LoadRiwayatAsync();
        }

        private async System.Threading.Tasks.Task LoadRiwayatAsync()
        {
            try
            {
                dgvRiwayat.Rows.Clear();

                // Ambil data dengan status Completed dan Overdue
                var completedTasks = await ToDoListSingleton.Instance.GetTasksByStatusAsync(_username, Status.Completed);
                var overdueTasks = await ToDoListSingleton.Instance.GetTasksByStatusAsync(_username, Status.Overdue);


                // Gabungkan keduanya
                var allTasks = new List<API.Model.Task>();
                allTasks.AddRange(completedTasks);
                allTasks.AddRange(overdueTasks);

                // Tampilkan ke DataGridView
                foreach (var task in allTasks)
                {
                    var deadline = task.Deadline;
                    string tanggal = $"{deadline.Day:D2}/{deadline.Month:D2}/{deadline.Year}";
                    string waktu = $"{deadline.Hour:D2}:{deadline.Minute:D2}";

                    dgvRiwayat.Rows.Add(
                        task.Name,
                        task.Description,
                        tanggal,
                        waktu,
                        task.Status.ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat tugas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
