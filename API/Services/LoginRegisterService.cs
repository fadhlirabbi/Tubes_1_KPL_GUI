using API.Controllers;
using System.Diagnostics.Contracts;

namespace API.Services
{
    public class LoginRegisterService
    {
        public enum State
        {
            LoggedOut,
            LoggedIn
        }

        private State _currentState;
        public State CurrentState => _currentState;

        private readonly LoginRegisterController _controller;
        private string? _currentUser;

        public LoginRegisterService()
        {
            _currentState = State.LoggedOut;
            _controller = new LoginRegisterController();
        }

        public LoginRegisterService(LoginRegisterController controller)
        {
            _currentState = State.LoggedOut;
            _controller = controller;
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

        public async Task Register()
        {
            Contract.Requires(_currentState == State.LoggedOut);

            Console.Write("Username: ");
            var username = Console.ReadLine()?.Trim();

            Console.Write("Password: ");
            var password = Console.ReadLine()?.Trim();

            if (!ValidateCredentials(username, password)) return;

            await Register(username!, password!);
        }

        public async Task Register(string username, string password)
        {
            Contract.Requires(_currentState == State.LoggedOut);

            if (!ValidateCredentials(username, password)) return;

            await _controller.RegisterAsync(username.Trim(), password.Trim());
        }

        public async Task<bool> TryLoginAsync(string username, string password)
        {
            Contract.Requires(_currentState == State.LoggedOut);

            if (!ValidateCredentials(username, password)) return false;

            var success = await _controller.TryLoginAsync(username.Trim(), password.Trim());
            if (success)
            {
                _currentState = State.LoggedIn;
                _currentUser = username.Trim();
            }

            return success;
        }

        public async Task Logout()
        {
            Contract.Requires(_currentState == State.LoggedIn);

            if (_currentUser == null)
            {
                Console.WriteLine("Tidak ada user yang login.");
                return;
            }

            await _controller.LogoutAsync(_currentUser);
            _currentState = State.LoggedOut;
            _currentUser = null;
        }

        public async Task DeleteAccountAndTasks()
        {
            Contract.Requires(_currentState == State.LoggedIn);

            if (_currentUser == null)
            {
                Console.WriteLine("Tidak ada user yang login.");
                return;
            }

            var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/") };

            // Hapus user
            var userResponse = await httpClient.DeleteAsync($"User/{_currentUser}");
            if (!userResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Gagal menghapus akun.");
                return;
            }

            // Hapus semua tugas user
            var taskList = await httpClient.GetFromJsonAsync<List<API.Model.Task>>("task");
            var userTasks = taskList?.Where(t => t.UserId == _currentUser).ToList();

            if (userTasks != null)
            {
                foreach (var task in userTasks)
                {
                    await httpClient.DeleteAsync($"task/{_currentUser}?taskName={task.Name}");
                }
            }

            Console.WriteLine("Akun dan semua tugas berhasil dihapus.");

            _currentUser = null;
            _currentState = State.LoggedOut;
        }
    }
}
