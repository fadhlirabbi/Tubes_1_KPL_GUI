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

        public async Task Register()
        {
            Contract.Requires(_currentState == State.LoggedOut);
            await _controller.RegisterAsync();
        }

        public async Task Register(string username, string password)
        {
            Contract.Requires(_currentState == State.LoggedOut);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Username/password tidak boleh kosong.");
                return;
            }

            await _controller.RegisterAsync(username, password);
        }

        public async Task<bool> TryLoginAsync(string username, string password)
        {
            Contract.Requires(_currentState == State.LoggedOut);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Username/password tidak boleh kosong.");
                return false;
            }

            var success = await _controller.TryLoginAsync(username, password);
            if (success)
            {
                _currentState = State.LoggedIn;
                _currentUser = username;
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
