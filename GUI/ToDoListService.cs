using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using API.Model;

using StatusModel = API.Model.Status;
using ModelTask = API.Model.Task;
using SystemTask = System.Threading.Tasks.Task;
using System.Text.Json;

public sealed class ToDoListService
{
    private static ToDoListService _instance;
    private static readonly object _lock = new object();
    private readonly HttpClient _httpClient;
    private readonly string _baseApiUrl = "http://localhost:5263/api/";

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

    /// Melakukan registrasi pengguna baru ke API.
    public async Task<bool> RegisterAsync(string username, string password)
    {
        try
        {
            var user = new { Username = username, Password = password };
            var response = await _httpClient.PostAsJsonAsync("User/register", user);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[ERROR] Gagal registrasi {username}: Status Code: {response.StatusCode}, Message: {errorMessage}");
                return false;
            }

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

            if (apiResponse != null)
            {
                Debug.WriteLine($"[DEBUG] Register response for {username}: Success = {apiResponse.Success}, Message = {apiResponse.Message}");
                return apiResponse.Success;
            }
            Debug.WriteLine($"[DEBUG] Register response for {username}: apiResponse is null.");
            return false;
        }
        catch (HttpRequestException httpEx)
        {
            Debug.WriteLine($"[ERROR] HTTP error occurred during registration for {username}: {httpEx.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[ERROR] Gagal registrasi {username}: {ex.Message}");
            return false;
        }
    }


    // Melakukan login pengguna ke API.
    public async Task<bool> LoginAsync(string username, string password)
    {
        try
        {
            var user = new { Username = username, Password = password };
            var response = await _httpClient.PostAsJsonAsync("User/login", user);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine($"[DEBUG] Login berhasil untuk {username}.");
                return true;

            }
            else
            {

                var errorContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[ERROR] Login gagal untuk {username}. Status Code: {response.StatusCode}, Content: {errorContent}");

                try
                {
                    var apiResponse = System.Text.Json.JsonSerializer.Deserialize<ApiResponse>(errorContent);
                    if (apiResponse != null)
                    {
                        Debug.WriteLine($"[DEBUG] Pesan Error API: {apiResponse.Message}");
                    }
                }
                catch (System.Text.Json.JsonException jsonEx)
                {
                    Debug.WriteLine($"[ERROR] Gagal mendeserialize respon error API: {jsonEx.Message}");
                }

                return false;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[ERROR] Terjadi kesalahan saat login untuk {username}: {ex.Message}");
            return false;
        }
    }

    // Melakukan logout pengguna dari API.
    public async Task<bool> LogoutAsync(string username)
    {
        try
        {
            var response = await _httpClient.PostAsync($"User/logout/{username}", null);
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

            if (apiResponse != null)
            {
                Debug.WriteLine($"[DEBUG] Logout response untuk {username}: Success = {apiResponse.Success}, Message = {apiResponse.Message}");
                return apiResponse.Success;
            }
            Debug.WriteLine($"[DEBUG] Logout response untuk {username}: apiResponse is null.");
            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[ERROR] Gagal logout {username}: {ex.Message}");
            return false;
        }
    }

    // Menyimpan dan memuat daftar tugas
    private List<ModelTask> Load()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "tasks.json");

        if (!File.Exists(filePath)) return new List<ModelTask>();

        var json = File.ReadAllText(filePath);
        return string.IsNullOrWhiteSpace(json)
            ? new List<ModelTask>()
            : JsonSerializer.Deserialize<List<ModelTask>>(json) ?? new List<ModelTask>();
    }

    // Menambahkan tugas baru untuk pengguna tertentu melalui API.
    public async Task<ApiResponse> AddTaskAsync(ModelTask task)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("task", task);
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

            if (apiResponse != null)
            {
                return apiResponse;
            }

            return new ApiResponse(400, "Gagal menambahkan tugas.");
        }
        catch (Exception ex)
        {
            return new ApiResponse(400, $"Terjadi kesalahan: {ex.Message}");
        }
    }

    // Mengedit tugas yang sudah ada.
    public async Task<bool> EditTaskAsync(string username, string oldTaskName, ModelTask updatedTask)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"task/{username}/{oldTaskName}", updatedTask);
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

            if (apiResponse != null)
            {
                Debug.WriteLine($"[DEBUG] EditTask response untuk '{oldTaskName}': Success = {apiResponse.Success}, Message = {apiResponse.Message}");
                return apiResponse.Success;
            }
            Debug.WriteLine($"[DEBUG] EditTask response untuk '{oldTaskName}': apiResponse is null.");
            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[ERROR] Gagal mengedit tugas '{oldTaskName}': {ex.Message}");
            return false;
        }
    }

    // Menghapus tugas berdasarkan detailnya.
    public async Task<bool> DeleteTaskAsync(string username, string taskName, string description, int day, int month, int year, int hour, int minute)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"task/{username}?taskName={taskName}&description={description}&day={day}&month={month}&year={year}&hour={hour}&minute={minute}");
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

            if (apiResponse != null)
            {
                Debug.WriteLine($"[DEBUG] DeleteTask response untuk '{taskName}': Success = {apiResponse.Success}, Message = {apiResponse.Message}");
                return apiResponse.Success;
            }
            Debug.WriteLine($"[DEBUG] DeleteTask response untuk '{taskName}': apiResponse is null.");
            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[ERROR] Gagal menghapus tugas '{taskName}': {ex.Message}");
            return false;
        }
    }

    // Menandai tugas sebagai selesai.
    public async Task<bool> MarkTaskAsCompletedAsync(string username, string taskName, string description, int day, int month, int year, int hour, int minute)
    {
        try
        {
            var response = await _httpClient.PostAsync($"task/complete/{username}?taskName={taskName}&description={description}&day={day}&month={month}&year={year}&hour={hour}&minute={minute}", null);
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

            if (apiResponse != null)
            {
                Debug.WriteLine($"[DEBUG] MarkTaskAsCompleted response untuk '{taskName}': Success = {apiResponse.Success}, Message = {apiResponse.Message}");
                return apiResponse.Success;
            }
            Debug.WriteLine($"[DEBUG] MarkTaskAsCompleted response untuk '{taskName}': apiResponse is null.");
            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[ERROR] Gagal menandai tugas selesai '{taskName}': {ex.Message}");
            return false;
        }
    }

    // Mendapatkan daftar tugas berdasarkan status untuk pengguna tertentu.
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
                    Debug.WriteLine($"[WARNING] Status tidak dikenal diberikan: {status}");
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

    // Mendapatkan semua tugas untuk pengguna tertentu (dapat dianggap sebagai "riwayat").
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

    // Mendapatkan daftar pengingat yang dikonfigurasi dari API.
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

    // Mendapatkan pengingat untuk tugas-tugas yang akan jatuh tempo.
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
                    reminders.Add($"[PENGINGAT] {rule.Message} untuk tugas '{task.Name}' pada {task.Deadline.ToString()}");
                }
            }
        }
        return reminders;
    }

    /// Mengatur status login semua pengguna menjadi false.
    /// Fungsi ini dipanggil saat aplikasi dimulai untuk menjamin tidak ada pengguna yang dianggap masih login dari sesi sebelumnya.
    public void ResetAllLoginStatus()
    {
        try
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
            string filePath = Path.Combine(projectRoot, "API", "Data", "users.json");

            if (!File.Exists(filePath))
            {
                Debug.WriteLine("[INFO] File users.json tidak ditemukan. Tidak ada pengguna yang perlu di-reset.");
                return;
            }

            string json = File.ReadAllText(filePath);
            var users = System.Text.Json.JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();

            foreach (var user in users)
                user.IsLoggedIn = false;

            string updatedJson = System.Text.Json.JsonSerializer.Serialize(users, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, updatedJson);
            Debug.WriteLine("[INFO] Semua pengguna berhasil di-set logout (IsLoggedIn = false).");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[ERROR] Gagal reset status login pengguna: {ex.Message}");
        }
    }
}