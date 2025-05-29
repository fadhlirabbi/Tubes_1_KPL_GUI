using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using API.Model;

namespace API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly string _filePath;

        public UserController()
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string folderPath = Path.Combine(projectRoot, "Data");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            _filePath = Path.Combine(folderPath, "users.json");
        }

        private List<User> LoadUsers()
        {
            if (!System.IO.File.Exists(_filePath))
                return new List<User>();

            var json = System.IO.File.ReadAllText(_filePath);
            return string.IsNullOrWhiteSpace(json)
                ? new List<User>()
                : JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        private void SaveUsers(List<User> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_filePath, json);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var users = LoadUsers();

            if (users.Any(u => u.Username == user.Username))
            {
                return BadRequest(new ApiResponse(400, "Username sudah ada atau sudah digunakan."));
            }

            user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            user.IsLoggedIn = false;
            users.Add(user);

            SaveUsers(users);
            return Ok(new ApiResponse(200, "Pendaftaran pengguna berhasil."));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginUser)
        {
            var users = LoadUsers();

            var existingUser = users.FirstOrDefault(u =>
                u.Username == loginUser.Username && u.Password == loginUser.Password);

            if (existingUser == null)
            {
                return Unauthorized(new ApiResponse(401, "Username atau password salah."));
            }

            existingUser.IsLoggedIn = true;
            SaveUsers(users);
            return Ok(new ApiResponse(200, "Login berhasil."));
        }

        [HttpPost("logout/{username}")]
        public IActionResult Logout(string username)
        {
            var users = LoadUsers();
            var existingUser = users.FirstOrDefault(u => u.Username == username);

            if (existingUser == null || !existingUser.IsLoggedIn)
            {
                return NotFound(new ApiResponse(404, "Pengguna belum login, atau tidak ditemukan."));
            }

            existingUser.IsLoggedIn = false;
            SaveUsers(users);
            return Ok(new ApiResponse(200, "Logout berhasil."));
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var users = LoadUsers();
            if (users == null || !users.Any())
            {
                return Ok(new ApiResponse(204, "Tidak ada pengguna ditemukan."));
            }
            return Ok(new ApiResponse(200, "Pengguna berhasil diambil.", users));
        }

        [HttpDelete("{username}")]
        public IActionResult DeleteUser(string username)
        {
            var users = LoadUsers();
            var userToDelete = users.FirstOrDefault(u => u.Username == username);

            if (userToDelete == null)
            {
                return NotFound(new ApiResponse(404, "Pengguna tidak ditemukan."));
            }

            users.Remove(userToDelete);
            SaveUsers(users);

            return Ok(new ApiResponse(200, "Pengguna berhasil dihapus.", userToDelete));
        }
    }
}
