using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using API.Model;
using API.Controllers;
using SystemTask = System.Threading.Tasks.Task;
using ModelTask = API.Model.Task;

namespace API.Services
{
    public class UserClientService
    {
        public enum State
        {
            LoggedOut,
            LoggedIn
        }

        private State _currentState;
        public State CurrentState => _currentState;

        private string? _currentUser;
        private readonly HttpClient _httpClient;

        public UserClientService()
        {
            _currentState = State.LoggedOut;
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/") };
        }

        private bool ValidateCredentials(string? username, string? password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Username dan password tidak boleh kosong atau hanya spasi.");
                return false;
            }
            return true;
        }

        // Melakukan registrasi pengguna baru dengan memanggil API UserController
        public async Task<bool> RegisterAsync(string username, string password)
        {
            if (!ValidateCredentials(username, password)) return false;

            try
            {
                var user = new { Username = username.Trim(), Password = password.Trim() };
                var response = await _httpClient.PostAsJsonAsync("User/register", user);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Registrasi gagal: {await response.Content.ReadAsStringAsync()}");
                    return false;
                }

                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return apiResponse?.Success ?? false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Registrasi gagal: {ex.Message}");
                return false;
            }
        }

        // Mencoba untuk login pengguna menggunakan API UserController
        public async Task<bool> TryLoginAsync(string username, string password)
        {
            if (!ValidateCredentials(username, password)) return false;

            try
            {
                var loginPayload = new { Username = username.Trim(), Password = password.Trim() };
                var response = await _httpClient.PostAsJsonAsync("User/login", loginPayload);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Login gagal: {await response.Content.ReadAsStringAsync()}");
                    return false;
                }

                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();
                if (apiResponse?.Success == true)
                {
                    _currentState = State.LoggedIn;
                    _currentUser = username.Trim();
                    Console.WriteLine("Login berhasil!");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Login gagal: {ex.Message}");
                return false;
            }
        }

        // Melakukan logout pengguna dengan memanggil API UserController dan memperbarui status 'IsLoggedIn' menjadi false.
        public async SystemTask LogoutAsync()
        {
            if (_currentState == State.LoggedOut || _currentUser == null)
            {
                Console.WriteLine("Tidak ada pengguna yang sedang login.");
                return;
            }

            try
            {
                var response = await _httpClient.PostAsync($"User/logout/{_currentUser}", null);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Logout gagal: {await response.Content.ReadAsStringAsync()}");
                    return;
                }
                _currentState = State.LoggedOut;
                _currentUser = null;
                Console.WriteLine("Logout berhasil!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Logout gagal: {ex.Message}");
            }
        }

        // Menghapus akun pengguna dan semua tugas terkait
        public async SystemTask DeleteAccountAndTasksAsync()
        {
            if (_currentState == State.LoggedOut || _currentUser == null)
            {
                Console.WriteLine("Tidak ada pengguna yang sedang login.");
                return;
            }

            try
            {
                // Hapus user dari API
                var userResponse = await _httpClient.DeleteAsync($"User/{_currentUser}");
                if (!userResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Gagal menghapus akun: {await userResponse.Content.ReadAsStringAsync()}");
                    return;
                }

                // Hapus semua tugas terkait user
                var taskResponse = await _httpClient.GetFromJsonAsync<List<ModelTask>>("task");
                var userTasks = taskResponse?.Where(t => t.UserId == _currentUser).ToList();

                if (userTasks != null)
                {
                    foreach (var task in userTasks)
                    {
                        await _httpClient.DeleteAsync($"task/{_currentUser}?taskName={task.Name}");
                    }
                }

                Console.WriteLine("Akun dan semua tugas berhasil dihapus.");
                _currentState = State.LoggedOut;
                _currentUser = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Gagal menghapus akun dan tugas: {ex.Message}");
            }
        }
    }
}
