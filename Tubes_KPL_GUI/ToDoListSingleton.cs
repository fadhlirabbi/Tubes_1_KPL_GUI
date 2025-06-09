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
                // Mengirim permintaan POST ke server untuk logout pengguna
                var response = await _httpClient.PostAsync($"User/logout/{username}", null);

                // Memeriksa apakah permintaan berhasil
                if (!response.IsSuccessStatusCode)
                {
                    // Jika gagal, ambil pesan kesalahan dan log
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"[ERROR] Gagal logout {username}: StatusCode = {(int)response.StatusCode}, Message = {errorMessage}");
                    return false; // Mengembalikan false jika logout gagal
                }

                // Jika logout berhasil, log dan kembalikan true
                Debug.WriteLine($"[INFO] Logout berhasil untuk pengguna: {username}");
                return true;
            }
            catch (Exception ex)
            {
                // Menangani kesalahan yang terjadi selama proses logout
                Debug.WriteLine($"[ERROR] Gagal melakukan logout {username}: {ex.Message}");
                return false; // Mengembalikan false jika terjadi error
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

        public async Task<ApiResponse> DeleteTaskAsync(string username, string taskName, string description, int day, int month, int year, int hour, int minute)
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

                return new ApiResponse(400, "Gagal menghapus tugas.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, $"Terjadi kesalahan: {ex.Message}");
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
            // Validasi input username, memastikan tidak kosong atau hanya spasi
            if (string.IsNullOrWhiteSpace(username))
            {
                Debug.WriteLine("[ERROR] Username tidak boleh kosong.");
                return new List<ModelTask>(); // Mengembalikan daftar kosong jika username tidak valid
            }

            try
            {
                // Menentukan endpoint berdasarkan status tugas yang diminta
                string endpoint = status switch
                {
                    StatusModel.Incompleted => "ongoing",  // Tugas yang belum selesai
                    StatusModel.Completed => "completed",   // Tugas yang sudah selesai
                    StatusModel.Overdue => "overdue",      // Tugas yang terlambat
                    _ => throw new ArgumentOutOfRangeException(nameof(status), "Status tidak dikenal.") // Menangani status yang tidak valid
                };

                // Melakukan HTTP GET request untuk mendapatkan tugas berdasarkan status dan username
                var response = await _httpClient.GetAsync($"task/{endpoint}/{username}");

                // Jika status code tidak berhasil, menampilkan error
                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"[ERROR] Gagal mendapatkan tugas {endpoint} untuk {username}. StatusCode: {(int)response.StatusCode}, Response: {errorMessage}");
                    return new List<ModelTask>(); // Mengembalikan daftar kosong jika request gagal
                }

                // Menyaring data tugas dalam format JSON dan mengembalikannya sebagai daftar ModelTask
                var apiResponse = await response.Content.ReadFromJsonAsync<List<ModelTask>>();

                return apiResponse ?? new List<ModelTask>(); // Mengembalikan daftar tugas atau daftar kosong jika response null
            }
            catch (ArgumentOutOfRangeException argEx)
            {
                // Menangani kasus ketika status tidak dikenal
                Debug.WriteLine($"[ERROR] {argEx.Message}");
                return new List<ModelTask>(); // Mengembalikan daftar kosong jika status tidak valid
            }
            catch (HttpRequestException httpEx)
            {
                // Menangani masalah yang terjadi saat menghubungi server (misalnya jaringan bermasalah)
                Debug.WriteLine($"[ERROR] Terjadi masalah saat menghubungi server: {httpEx.Message}");
                return new List<ModelTask>(); // Mengembalikan daftar kosong jika ada masalah dengan permintaan HTTP
            }
            catch (Exception ex)
            {
                // Menangani kesalahan umum lainnya
                Debug.WriteLine($"[ERROR] Gagal mendapatkan tugas berdasarkan status {status} untuk {username}: {ex.Message}");
                return new List<ModelTask>(); // Mengembalikan daftar kosong jika terjadi kesalahan tak terduga
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

        // Reset semua login saat aplikasi pertama kali dibuka
        public void ResetAllLoginStatus()
        {
            try
            {
                string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
                string path = Path.Combine(projectRoot, "API", "Data", "users.json");

                if (!File.Exists(path)) return;

                var users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(path)) ?? new();
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
        /// <param name="username">Username pengguna yang status tugasnya akan diperbarui.</param>
        /// <returns>Objek <see cref="ApiResponse"/> yang berisi status operasi pembaruan tugas.</returns>
        public async Task<ApiResponse> UpdateTaskStatusAsync(string username)
        {
            try
            {
                // Menentukan endpoint API untuk memperbarui status tugas berdasarkan username
                var endpoint = $"task/update-status/{username}";

                // Melakukan request POST ke endpoint untuk memperbarui status tugas
                var response = await _httpClient.PostAsync(endpoint, null);

                // Membaca respons dari server dalam format ApiResponse
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

                // Jika respons valid, kembalikan response dari API
                if (apiResponse != null)
                {
                    return apiResponse;
                }

                // Jika response null, kembalikan response gagal dengan pesan error
                return new ApiResponse(400, "Gagal memperbarui status tugas.");
            }
            catch (Exception ex)
            {
                // Jika terjadi error saat melakukan request, kembalikan response gagal dengan detail error
                return new ApiResponse(400, $"Terjadi kesalahan: {ex.Message}");
            }
        }

    }
}
