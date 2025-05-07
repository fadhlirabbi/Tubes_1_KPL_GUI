using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tubes_1_KPL.Model;

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

        // Register User
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var users = LoadUsers();

            if (users.Any(u => u.Username == user.Username))
                return BadRequest("Username already exists.");

            user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            user.IsLoggedIn = false;
            users.Add(user);

            SaveUsers(users);
            return Ok("User registered successfully.");
        }

        // Login User
        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginUser)
        {
            var users = LoadUsers();

            var existingUser = users.FirstOrDefault(u =>
                u.Username == loginUser.Username && u.Password == loginUser.Password);

            if (existingUser == null)
                return Unauthorized("Username or password is incorrect.");

            existingUser.IsLoggedIn = true;
            SaveUsers(users);
            return Ok("Login successful.");
        }

        // Logout User
        [HttpPost("logout/{username}")]
        public IActionResult Logout(string username)
        {
            var users = LoadUsers();
            var existingUser = users.FirstOrDefault(u => u.Username == username);

            if (existingUser == null || !existingUser.IsLoggedIn)
                return NotFound("User not logged in or does not exist.");

            existingUser.IsLoggedIn = false;
            SaveUsers(users);
            return Ok("Logout successful.");
        }

        // Get All Users
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var users = LoadUsers();
            if (users == null || !users.Any())
            {
                return NoContent(); // No users found
            }
            return Ok(users);
        }

        // ✅ Delete User
        [HttpDelete("{username}")]
        public IActionResult DeleteUser(string username)
        {
            var users = LoadUsers();
            var userToDelete = users.FirstOrDefault(u => u.Username == username);

            if (userToDelete == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            users.Remove(userToDelete);
            SaveUsers(users);

            return Ok(new { Message = "User deleted successfully.", DeletedUser = userToDelete });
        }
    }
}
