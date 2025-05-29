using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tubes_1_KPL.Model; // Pastikan ini adalah namespace untuk model User Anda
using API.Model; // Pastikan ini adalah namespace untuk model ApiResponse Anda

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
                // MENGUBAH: Menggunakan konstruktor ApiResponse dengan StatusCode
                return BadRequest(new ApiResponse(400, "Username sudah ada atau sudah digunakan.")); // 400 Bad Request
            }

            user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            user.IsLoggedIn = false;
            users.Add(user);

            SaveUsers(users);
            // MENGUBAH: Menggunakan konstruktor ApiResponse dengan StatusCode
            return Ok(new ApiResponse(200, "User berhasil registrasi.")); // 200 OK
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginUser)
        {
            var users = LoadUsers();

            var existingUser = users.FirstOrDefault(u =>
                u.Username == loginUser.Username && u.Password == loginUser.Password);

            if (existingUser == null)
            {
                // MENGUBAH: Menggunakan konstruktor ApiResponse dengan StatusCode
                return Unauthorized(new ApiResponse(401, "Username atau password salah.")); // 401 Unauthorized
            }

            existingUser.IsLoggedIn = true;
            SaveUsers(users);
            // MENGUBAH: Menggunakan konstruktor ApiResponse dengan StatusCode
            return Ok(new ApiResponse(200, "Login berhasil.")); // 200 OK
        }

        [HttpPost("logout/{username}")]
        public IActionResult Logout(string username)
        {
            var users = LoadUsers();
            var existingUser = users.FirstOrDefault(u => u.Username == username);

            if (existingUser == null || !existingUser.IsLoggedIn)
            {
                // MENGUBAH: Menggunakan konstruktor ApiResponse dengan StatusCode
                return NotFound(new ApiResponse(404, "User belum log in, atau tidak ditemukan.")); // 404 Not Found
            }

            existingUser.IsLoggedIn = false;
            SaveUsers(users);
            // MENGUBAH: Menggunakan konstruktor ApiResponse dengan StatusCode
            return Ok(new ApiResponse(200, "Logout berhasil.")); // 200 OK
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var users = LoadUsers();
            if (users == null || !users.Any())
            {
                return NoContent(); // NoContent() tidak perlu ApiResponse, karena tidak ada body.
                                    // Tapi jika ingin konsisten, bisa juga:
                                    // return Ok(new ApiResponse(204, "No users found.")); // 204 No Content
            }
            // MENGUBAH: Menggunakan konstruktor ApiResponse dengan StatusCode
            return Ok(new ApiResponse(200, "Users retrieved successfully.", users)); // 200 OK dengan data
        }

        [HttpDelete("{username}")]
        public IActionResult DeleteUser(string username)
        {
            var users = LoadUsers();
            var userToDelete = users.FirstOrDefault(u => u.Username == username);

            if (userToDelete == null)
            {
                // MENGUBAH: Menggunakan konstruktor ApiResponse dengan StatusCode
                return NotFound(new ApiResponse(404, "User tidak ditemukan.")); // 404 Not Found
            }

            users.Remove(userToDelete);
            SaveUsers(users);

            // MENGUBAH: Menggunakan konstruktor ApiResponse dengan StatusCode
            return Ok(new ApiResponse(200, "User berhasil di hapus.", userToDelete)); // 200 OK dengan data
        }
    }
}