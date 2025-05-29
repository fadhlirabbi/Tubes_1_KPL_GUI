using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Diagnostics; // Untuk Debug.WriteLine
using API.Model;
using Tubes_1_KPL.Model;

using StatusModel = API.Model.Status;
using ModelTask = API.Model.Task;


    public sealed class ToDoListService
    {
        private static ToDoListService _instance;
        private static readonly object _lock = new object();
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl = "http://localhost:5263/api/";

        // Private constructor untuk menerapkan Singleton
        private ToDoListService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseApiUrl) };
        }

        // Properti statis untuk mendapatkan instance Singleton
        public static ToDoListService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ToDoListService();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Melakukan registrasi pengguna baru ke API.
        /// </summary>
        /// <param name="username">Username pengguna.</param>
        /// <param name="password">Password pengguna.</param>
        /// <returns>True jika registrasi berhasil, false jika gagal.</returns>
        public async Task<bool> RegisterAsync(string username, string password)
        {
            try
            {
                var user = new { Username = username, Password = password };
                var response = await _httpClient.PostAsJsonAsync("User/register", user);
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

                // Hanya mengembalikan nilai boolean Success. Pesan hanya untuk debug internal.
                if (apiResponse != null)
                {
                    Debug.WriteLine($"[DEBUG] Register response for {username}: Success = {apiResponse.Success}, Message = {apiResponse.Message}");
                    return apiResponse.Success;
                }
                Debug.WriteLine($"[DEBUG] Register response for {username}: apiResponse is null.");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Gagal register {username}: {ex.Message}");
                return false;
            }
        }

    /// <summary>
    /// Melakukan login pengguna ke API.
    /// </summary>
    /// <param name="username">Username pengguna.</param>
    /// <param name="password">Password pengguna.</param>
    /// <returns>True jika login berhasil, false jika gagal.</returns>
    // Inside ToDoListService
    public async Task<bool> LoginAsync(string username, string password)
    {
        try
        {
            var user = new { Username = username, Password = password };
            var response = await _httpClient.PostAsJsonAsync("User/login", user);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine($"[DEBUG] Login successful for {username}.");
                return true; // Login successful
            }
            else
            {
                // Read the error message from the API response
                var errorContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[ERROR] Login failed for {username}. Status Code: {response.StatusCode}, Content: {errorContent}");

                // Attempt to deserialize to ApiResponse if possible, otherwise log raw content
                try
                {
                    var apiResponse = System.Text.Json.JsonSerializer.Deserialize<ApiResponse>(errorContent);
                    if (apiResponse != null)
                    {
                        Debug.WriteLine($"[DEBUG] API Error Message: {apiResponse.Message}");
                        // You might want to pass this message back to the UI, e.g., via a tuple
                        // return (false, apiResponse.Message);
                    }
                }
                catch (System.Text.Json.JsonException jsonEx)
                {
                    Debug.WriteLine($"[ERROR] Could not deserialize API error response: {jsonEx.Message}");
                }
                return false; // Login failed
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[ERROR] Exception during login for {username}: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Melakukan logout pengguna dari API.
    /// </summary>
    /// <param name="username">Username pengguna yang akan logout.</param>
    /// <returns>True jika logout berhasil, false jika gagal.</returns>
    public async Task<bool> LogoutAsync(string username)
        {
            try
            {
                var response = await _httpClient.PostAsync($"User/logout/{username}", null);
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

                if (apiResponse != null)
                {
                    Debug.WriteLine($"[DEBUG] Logout response for {username}: Success = {apiResponse.Success}, Message = {apiResponse.Message}");
                    return apiResponse.Success;
                }
                Debug.WriteLine($"[DEBUG] Logout response for {username}: apiResponse is null.");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Gagal logout {username}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Menambahkan tugas baru untuk pengguna tertentu.
        /// </summary>
        /// <param name="taskName">Nama tugas.</param>
        /// <param name="description">Deskripsi tugas.</param>
        /// <param name="deadline">Objek Deadline tugas.</param>
        /// <param name="userId">ID pengguna yang memiliki tugas.</param>
        /// <returns>True jika tugas berhasil ditambahkan, false jika gagal.</returns>
        public async Task<bool> AddTaskAsync(string taskName, string description, Deadline deadline, string userId)
        {
            try
            {
                var newTask = new ModelTask(taskName, description, deadline, userId);
                var response = await _httpClient.PostAsJsonAsync("task", newTask);
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

                if (apiResponse != null)
                {
                    Debug.WriteLine($"[DEBUG] AddTask response for '{taskName}': Success = {apiResponse.Success}, Message = {apiResponse.Message}");
                    return apiResponse.Success;
                }
                Debug.WriteLine($"[DEBUG] AddTask response for '{taskName}': apiResponse is null.");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Gagal menambah tugas '{taskName}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Mengedit tugas yang sudah ada.
        /// </summary>
        /// <param name="username">Username pemilik tugas.</param>
        /// <param name="oldTaskName">Nama tugas lama (untuk identifikasi).</param>
        /// <param name="updatedTask">Objek tugas dengan informasi yang diperbarui.</param>
        /// <returns>True jika tugas berhasil diperbarui, false jika gagal.</returns>
        public async Task<bool> EditTaskAsync(string username, string oldTaskName, ModelTask updatedTask)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"task/{username}/{oldTaskName}", updatedTask);
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

                if (apiResponse != null)
                {
                    Debug.WriteLine($"[DEBUG] EditTask response for '{oldTaskName}': Success = {apiResponse.Success}, Message = {apiResponse.Message}");
                    return apiResponse.Success;
                }
                Debug.WriteLine($"[DEBUG] EditTask response for '{oldTaskName}': apiResponse is null.");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Gagal mengedit tugas '{oldTaskName}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Menghapus tugas berdasarkan detailnya.
        /// </summary>
        /// <param name="username">Username pemilik tugas.</param>
        /// <param name="taskName">Nama tugas.</param>
        /// <param name="description">Deskripsi tugas.</param>
        /// <param name="day">Hari deadline.</param>
        /// <param name="month">Bulan deadline.</param>
        /// <param name="year">Tahun deadline.</param>
        /// <param name="hour">Jam deadline.</param>
        /// <param name="minute">Menit deadline.</param>
        /// <returns>True jika tugas berhasil dihapus, false jika gagal.</returns>
        public async Task<bool> DeleteTaskAsync(string username, string taskName, string description, int day, int month, int year, int hour, int minute)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"task/{username}?taskName={taskName}&description={description}&day={day}&month={month}&year={year}&hour={hour}&minute={minute}");
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

                if (apiResponse != null)
                {
                    Debug.WriteLine($"[DEBUG] DeleteTask response for '{taskName}': Success = {apiResponse.Success}, Message = {apiResponse.Message}");
                    return apiResponse.Success;
                }
                Debug.WriteLine($"[DEBUG] DeleteTask response for '{taskName}': apiResponse is null.");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Gagal menghapus tugas '{taskName}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Menandai tugas sebagai selesai.
        /// </summary>
        /// <param name="username">Username pemilik tugas.</param>
        /// <param name="taskName">Nama tugas.</param>
        /// <param name="description">Deskripsi tugas.</param>
        /// <param name="day">Hari deadline.</param>
        /// <param name="month">Bulan deadline.</param>
        /// <param name="year">Tahun deadline.</param>
        /// <param name="hour">Jam deadline.</param>
        /// <param name="minute">Menit deadline.</param>
        /// <returns>True jika tugas berhasil ditandai selesai, false jika gagal.</returns>
        public async Task<bool> MarkTaskAsCompletedAsync(string username, string taskName, string description, int day, int month, int year, int hour, int minute)
        {
            try
            {
                var response = await _httpClient.PostAsync($"task/complete/{username}?taskName={taskName}&description={description}&day={day}&month={month}&year={year}&hour={hour}&minute={minute}", null);
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

                if (apiResponse != null)
                {
                    Debug.WriteLine($"[DEBUG] MarkTaskAsCompleted response for '{taskName}': Success = {apiResponse.Success}, Message = {apiResponse.Message}");
                    return apiResponse.Success;
                }
                Debug.WriteLine($"[DEBUG] MarkTaskAsCompleted response for '{taskName}': apiResponse is null.");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Gagal menandai tugas selesai '{taskName}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Mendapatkan daftar tugas berdasarkan status untuk pengguna tertentu.
        /// </summary>
        /// <param name="username">Username pengguna.</param>
        /// <param name="status">Status tugas yang ingin diambil (Ongoing, Completed, Overdue).</param>
        /// <returns>Daftar tugas sesuai status, atau daftar kosong jika terjadi kesalahan.</returns>
        public async Task<List<ModelTask>> GetTasksByStatusAsync(string username, StatusModel status)
        {
            try
            {
                string endpoint = string.Empty;
                switch (status)
                {
                    case StatusModel.Incompleted:
                        endpoint = "ongoing";
                        break;
                    case StatusModel.Completed:
                        endpoint = "completed";
                        break;
                    case StatusModel.Overdue:
                        endpoint = "overdue";
                        break;
                    default:
                        Debug.WriteLine($"[WARNING] Unknown status provided: {status}");
                        return new List<ModelTask>();
                }

                var response = await _httpClient.GetAsync($"task/{endpoint}/{username}");

                if (!response.IsSuccessStatusCode)
                {
                    // Hanya mencatat kesalahan ke debug output, tidak mengembalikan pesan ke GUI
                    Debug.WriteLine($"[ERROR] Gagal mendapatkan tugas {endpoint} untuk {username}. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
                    return new List<ModelTask>();
                }

                var apiResponse = await response.Content.ReadFromJsonAsync<List<ModelTask>>();

                return apiResponse ?? new List<ModelTask>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Gagal mendapatkan tugas berdasarkan status {status} untuk {username}: {ex.Message}");
                return new List<ModelTask>();
            }
        }

        /// <summary>
        /// Mendapatkan semua tugas untuk pengguna tertentu (dapat dianggap sebagai "riwayat").
        /// </summary>
        /// <param name="username">Username pengguna.</param>
        /// <returns>Daftar semua tugas pengguna, atau daftar kosong jika terjadi kesalahan.</returns>
        public async Task<List<ModelTask>> GetUserTasksHistoryAsync(string username)
        {
            try
            {
                var response = await _httpClient.GetAsync($"task/user/{username}");

                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"[ERROR] Gagal mendapatkan riwayat tugas untuk {username}. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
                    return new List<ModelTask>();
                }

                var apiResponse = await response.Content.ReadFromJsonAsync<List<ModelTask>>();

                return apiResponse ?? new List<ModelTask>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Gagal mendapatkan riwayat tugas untuk {username}: {ex.Message}");
                return new List<ModelTask>();
            }
        }

        /// <summary>
        /// Mendapatkan daftar pengingat yang dikonfigurasi dari API.
        /// </summary>
        /// <returns>Daftar aturan pengingat, atau daftar kosong jika terjadi kesalahan.</returns>
        public async Task<List<ReminderRule>> GetReminderRulesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("ReminderConfig");

                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"[ERROR] Gagal mendapatkan aturan pengingat. Status Code: {response.StatusCode}. Content: {await response.Content.ReadAsStringAsync()}");
                    return new List<ReminderRule>();
                }

                var reminderConfig = await response.Content.ReadFromJsonAsync<ReminderConfig>();

                return reminderConfig?.Rules ?? new List<ReminderRule>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Gagal mendapatkan aturan pengingat: {ex.Message}");
                return new List<ReminderRule>();
            }
        }

        /// <summary>
        /// Mendapatkan pengingat untuk tugas-tugas yang akan jatuh tempo.
        /// </summary>
        /// <param name="username">Username pengguna.</param>
        /// <returns>Daftar string pesan pengingat.</returns>
        public async Task<List<string>> GetRemindersAsync(string username)
        {
            var reminders = new List<string>();
            var tasks = await GetTasksByStatusAsync(username, StatusModel.Incompleted);
            var reminderRules = await GetReminderRulesAsync();

            if (!tasks.Any() || !reminderRules.Any())
            {
                return reminders;
            }

            foreach (var task in tasks)
            {
                DateTime deadlineDateTime = new DateTime(task.Deadline.Year, task.Deadline.Month, task.Deadline.Day, task.Deadline.Hour, task.Deadline.Minute, 0);

                foreach (var rule in reminderRules)
                {
                    DateTime reminderDate = deadlineDateTime.AddDays(-rule.DaysBefore);
                    if (DateTime.Now >= reminderDate && DateTime.Now < deadlineDateTime)
                    {
                        reminders.Add($"[REMINDER] {rule.Message} untuk tugas '{task.Name}' pada {task.Deadline.ToString()}");
                    }
                }
            }
            return reminders;
        }
    }
