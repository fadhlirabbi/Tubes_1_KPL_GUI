//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text.Json;
//using API.Model;

//namespace API.Services
//{
//    public class UserService
//    {
//        private readonly string _filePath;

//        public UserService()
//        {
//            string root = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "API", "Data");
//            Directory.CreateDirectory(root);
//            _filePath = Path.Combine(root, "users.json");
//        }

//        private List<User> Load()
//        {
//            if (!File.Exists(_filePath)) return new List<User>();
//            var json = File.ReadAllText(_filePath);
//            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
//        }

//        private void Save(List<User> users)
//        {
//            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
//            File.WriteAllText(_filePath, json);
//        }

//        public ApiResponse CreateUser(User user)
//        {
//            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
//            {
//                return new ApiResponse(400, "Username and password are required.");
//            }

//            var users = Load();

//            // Validasi duplicate username
//            bool isDuplicate = users.Any(u =>
//                u.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase)
//            );

//            if (isDuplicate)
//            {
//                return new ApiResponse(400, "User with the same username already exists.");
//            }

//            user.Id = new Random().Next(1, 1000);  
//            users.Add(user);
//            Save(users);
//            return new ApiResponse(201, "User successfully created.", user);
//        }

//        public ApiResponse EditUser(int id, User updated)
//        {
//            if (updated == null)
//            {
//                return new ApiResponse(400, "Invalid data provided.");
//            }

//            var users = Load();
//            var user = users.FirstOrDefault(u => u.Id == id);
//            if (user == null) return new ApiResponse(404, "User not found");

//            user.Username = updated.Username;
//            user.Password = updated.Password;
//            user.IsLoggedIn = updated.IsLoggedIn;

//            Save(users);
//            return new ApiResponse(200, "User successfully updated", user);
//        }

//        public ApiResponse DeleteUser(int id)
//        {
//            var users = Load();
//            var user = users.FirstOrDefault(u => u.Id == id);
//            if (user == null) return new ApiResponse(404, "User not found");

//            users.Remove(user);
//            Save(users);
//            return new ApiResponse(200, "User successfully deleted");
//        }

//        public List<User> GetAllUsers() => Load();

//        public User GetById(int id) => Load().FirstOrDefault(u => u.Id == id);
//    }
//}
