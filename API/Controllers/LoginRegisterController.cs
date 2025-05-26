using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class LoginRegisterController
    {
        protected readonly HttpClient _http;

        public LoginRegisterController()
        {
            _http = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/") };
            Contract.Invariant(_http != null);
        }

        public LoginRegisterController(HttpClient httpClient)
        {
            _http = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public virtual async Task RegisterAsync(string username, string password)
        {
            try
            {
                var user = new { Username = username, Password = password };
                Debug.WriteLine($"[DEBUG] Sending register request for: {username}");

                var response = await _http.PostAsJsonAsync("User/register", user);
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(response.IsSuccessStatusCode
                    ? "Registrasi berhasil."
                    : $"Registrasi gagal: {content}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Gagal register: {ex.Message}");
                Debug.WriteLine($"[ERROR] RegisterAsync: {ex}");
            }
        }

        public virtual async Task<bool> TryLoginAsync(string username, string password)
        {
            try
            {
                var user = new { Username = username, Password = password };
                Debug.WriteLine($"[DEBUG] Sending login request for: {username}");

                var response = await _http.PostAsJsonAsync("User/login", user);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Login berhasil: {username}");
                    return true;
                }

                Console.WriteLine($"Login gagal: {content}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Gagal login: {ex.Message}");
                Debug.WriteLine($"[ERROR] TryLoginAsync: {ex}");
                return false;
            }
        }

        public virtual async Task LogoutAsync(string username)
        {
            try
            {
                Debug.WriteLine($"[DEBUG] Sending logout request for: {username}");

                var response = await _http.PostAsync($"User/logout/{username}", null);
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(response.IsSuccessStatusCode
                    ? $"Logout berhasil: {username}"
                    : $"Logout gagal: {content}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Gagal logout: {ex.Message}");
                Debug.WriteLine($"[ERROR] LogoutAsync: {ex}");
            }
        }
    }
}
