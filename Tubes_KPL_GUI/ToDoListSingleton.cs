using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using StatusModel = API.Model.Status;
using ModelTask = API.Model.Task;
using SystemTask = System.Threading.Tasks.Task;
using API.Model;

namespace Tubes_KPL_GUI
{
    public sealed class ToDoListSingleton
    {
        private static ToDoListSingleton _instance;
        private static readonly object _lock = new object();

        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl = "http://localhost:5263/api/";

        private ToDoListSingleton()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseApiUrl) };
        }

        public static ToDoListSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new ToDoListSingleton();
                    }
                }
                return _instance;
            }
        }

        // Registrasi
        public async Task<bool> RegisterAsync(string username, string password)
        {

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Debug.WriteLine("[WARNING] Register gagal: username atau password kosong.");
                return false;
            }

            try
            {
                var user = new { Username = username.Trim(), Password = password.Trim() };
                var response = await _httpClient.PostAsJsonAsync("User/register", user);

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"[ERROR] Gagal registrasi {username}: StatusCode = {(int)response.StatusCode}, Message = {errorMessage}");
                    return false;
                }

                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

                if (apiResponse != null)
                {
                    Debug.WriteLine($"[DEBUG] Register response for {username}: Success = {apiResponse.Success}, Message = {apiResponse.Message}");
                    return apiResponse.Success;
                }
                    
                Debug.WriteLine($"[WARNING] Register response kosong untuk {username}.");
                return false;
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"[ERROR] HTTP error saat registrasi {username}: {httpEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Gagal registrasi {username}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Debug.WriteLine("[WARNING] Login gagal: username atau password kosong.");
                return false;
            }

            try
            {
                var loginPayload = new { Username = username.Trim(), Password = password.Trim() };
                var response = await _httpClient.PostAsJsonAsync("User/login", loginPayload);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"[INFO] Login berhasil untuk user: {username}");
                    return true;
                }

                string responseContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[WARN] Login gagal: status = {(int)response.StatusCode}, content = {responseContent}");

                try
                {
                    var apiError = JsonSerializer.Deserialize<ApiResponse>(responseContent);
                    if (apiError != null)
                    {
                        Debug.WriteLine($"[DEBUG] Pesan error dari API: {apiError.Message}");
                    }
                }
                catch (JsonException je)
                {
                    Debug.WriteLine($"[ERROR] Gagal parsing pesan error: {je.Message}");
                }

                return false;
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"[ERROR] Koneksi ke server gagal: {httpEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Kesalahan tidak terduga saat login: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Melakukan logout untuk pengguna dengan mengirim permintaan POST ke server.
        /// </summary>
        /// <param name="username">Username pengguna yang akan keluar dari sistem.</param>
        /// <returns>True jika logout berhasil, False jika gagal.</returns>
        public async Task<bool> LogoutAsync(string username)
        {
            try
            {
                var response = await _httpClient.PostAsync($"User/logout/{username}", null);

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"[ERROR] Gagal logout {username}: StatusCode = {(int)response.StatusCode}, Message = {errorMessage}");
                    return false; 
                }

                Debug.WriteLine($"[INFO] Logout berhasil untuk pengguna: {username}");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Gagal melakukan logout {username}: {ex.Message}");
                return false; 
            }
        }


        // CRUD Task
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

        public async Task<bool> EditTaskAsync(string username, string oldTaskName, ModelTask updatedTask)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"task/{username}/{oldTaskName}", updatedTask);
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return apiResponse?.Success ?? false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Edit task failed: {ex.Message}");
                return false;
            }
        }

        public async Task<ApiResponse> DeleteSpecificTaskAsync(string username, string taskName, string description, int day, int month, int year, int hour, int minute)
        {
            try
            {
                var queryParams = $"taskName={Uri.EscapeDataString(taskName)}" +
                                  $"&description={Uri.EscapeDataString(description)}" +
                                  $"&day={day}&month={month}&year={year}" +
                                  $"&hour={hour}&minute={minute}";

                var endpoint = $"task/delete-specific/{username}?{queryParams}";

                var response = await _httpClient.DeleteAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();
                    return apiResponse ?? new ApiResponse(200, "Tugas berhasil dihapus.");
                }

                return new ApiResponse((int)response.StatusCode, $"Gagal menghapus tugas. Status: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Terjadi kesalahan: {ex.Message}");
            }
        }

        public async Task<ApiResponse> MarkTaskAsCompletedAsync(string username, string taskName, string description, int day, int month, int year, int hour, int minute)
        {
            try
            {
                var endpoint = $"task/complete/{username}?taskName={taskName}&description={description}&day={day}&month={month}&year={year}&hour={hour}&minute={minute}";
                var response = await _httpClient.PostAsync(endpoint, null);

                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

                if (apiResponse != null)
                {
                    return apiResponse;
                }

                return new ApiResponse(400, "Gagal menandai tugas sebagai selesai.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, $"Terjadi kesalahan: {ex.Message}");
            }
        }

        /// <summary>
        /// Mengambil daftar tugas berdasarkan status dan username dari server.
        /// </summary>
        /// <param name="username">Username pengguna yang tugas-tugasnya ingin diambil.</param>
        /// <param name="status">Status tugas yang ingin diambil (Incompleted, Completed, Overdue).</param>
        /// <returns>Daftar tugas yang sesuai dengan status yang diminta.</returns>
        public async Task<List<ModelTask>> GetTasksByStatusAsync(string username, StatusModel status)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                Debug.WriteLine("[ERROR] Username tidak boleh kosong.");
                return new List<ModelTask>(); 
            }

            try
            {
                string endpoint = status switch
                {
                    StatusModel.Incompleted => "ongoing",  
                    StatusModel.Completed => "completed",   
                    StatusModel.Overdue => "overdue",      
                    _ => throw new ArgumentOutOfRangeException(nameof(status), "Status tidak dikenal.") 
                };

                var response = await _httpClient.GetAsync($"task/{endpoint}/{username}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"[ERROR] Gagal mendapatkan tugas {endpoint} untuk {username}. StatusCode: {(int)response.StatusCode}, Response: {errorMessage}");
                    return new List<ModelTask>(); 
                }

                var apiResponse = await response.Content.ReadFromJsonAsync<List<ModelTask>>();

                return apiResponse ?? new List<ModelTask>(); 
            }
            catch (ArgumentOutOfRangeException argEx)
            {
                Debug.WriteLine($"[ERROR] {argEx.Message}");
                return new List<ModelTask>(); 
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"[ERROR] Terjadi masalah saat menghubungi server: {httpEx.Message}");
                return new List<ModelTask>(); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Gagal mendapatkan tugas berdasarkan status {status} untuk {username}: {ex.Message}");
                return new List<ModelTask>(); 
            }
        }

        public async Task<List<ModelTask>> GetUserTaskHistoryAsync(string username)
        {
            try
            {
                var response = await _httpClient.GetAsync($"task/user/{username}");
                return await response.Content.ReadFromJsonAsync<List<ModelTask>>() ?? new();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] GetUserTaskHistory failed: {ex.Message}");
                return new();
            }
        }

        /// <summary>
        /// Reset semua login saat aplikasi pertama kali dibuka
        /// </summary>
        public void ResetAllLoginStatus()
        {
            try
            {
                string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
                string path = Path.Combine(projectRoot, "API", "Data", "users.json");

                if (!File.Exists(path)) return;

                var users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(path)) ?? new();

                // Reset only the login status of users, without modifying task data
                foreach (var user in users) user.IsLoggedIn = false;

                var updatedJson = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, updatedJson);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] ResetAllLoginStatus: {ex.Message}");
            }
        }

        /// <summary>
        /// Memperbarui status tugas pengguna dengan mengirim permintaan POST ke server.
        /// </summary>
        /// <returns>Objek <see cref="ApiResponse"/> yang berisi status operasi pembaruan tugas.</returns>
        public async Task<ApiResponse> UpdateTaskStatusAsync()
        {
            try
            {
                // Tidak memerlukan username, kita akan memperbarui semua tugas
                var endpoint = "task/update-status";  // Endpoint yang menangani semua tugas
                var response = await _httpClient.PostAsync(endpoint, null);
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

                if (apiResponse != null)
                {
                    return apiResponse;
                }

                return new ApiResponse(400, "Gagal memperbarui status tugas.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, $"Terjadi kesalahan: {ex.Message}");
            }
        }

    }
}
