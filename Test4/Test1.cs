//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using API.Model;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net.Http;
//using System.Text.Json;
//using System.Threading.Tasks;
//using API.Services;
//using Tubes_1_KPL.Model;
//using SystemTask = System.Threading.Tasks.Task;
//using ModelTask = API.Model.Task;

//namespace Test4.MyApp.Tests
//{
//    [TestClass]
//    public class TestDeleteTask_TaskService
//    {
//        private TaskService _service;
//        private string _loggedInUser;
//        private string _taskPath;
//        private string _userPath;

//        [TestInitialize]
//        public void Setup()
//        {
//            // Gunakan async task sebagai workaround
//            SystemTask.Run(async () => await InitTestAsync()).GetAwaiter().GetResult();
//        }

//        private async SystemTask InitTestAsync()
//        {
//            _loggedInUser = "temp_user_delete_service";

//            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
//            string dataFolder = Path.Combine(root, "API", "Data");
//            _taskPath = Path.Combine(dataFolder, $"task_{Guid.NewGuid()}.json");
//            _userPath = Path.Combine(dataFolder, "users.json");

//            Directory.CreateDirectory(dataFolder);

//            File.WriteAllText(_taskPath, "[]");
//            File.WriteAllText(_userPath, "[]");

//            // Tambahkan user dummy
//            var users = new List<User>{
//                    new User { Id = 1000, Username = _loggedInUser, Password = "pass", IsLoggedIn = true }
//                };
//            File.WriteAllText(_userPath, JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }));

//            // Inisialisasi TaskService
//            var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/") };
//            _service = new TaskService(_loggedInUser, httpClient);

//            // Tambahkan dua task untuk user
//            await _service.CreateTaskAsync("Task1", "desc", 10, "Januari", 2025, 9, 0);
//            await _service.CreateTaskAsync("Task2", "desc", 10, "Januari", 2025, 9, 0);
//        }



//        [TestMethod]
//        public async SystemTask DeleteTask_Success()
//        {
//            bool deleted = await _service.DeleteTaskAsync("Task1");

//            var tasks = _service.GetUserTasks();
//            Assert.IsTrue(deleted, "Task tidak berhasil dihapus.");
//            Assert.IsFalse(tasks.Any(t => t.Name == "Task1"), "Task masih ada setelah penghapusan.");
//        }

//        [TestMethod]
//        public async SystemTask DeleteTask_Failure_TaskNotFound()
//        {
//            bool deleted = await _service.DeleteTaskAsync("TidakAdaTask");

//            var tasks = _service.GetUserTasks();
//            Assert.IsFalse(deleted, "Task tidak ada tapi dianggap berhasil dihapus.");
//            Assert.AreEqual(2, tasks.Count, "Task seharusnya tidak berubah.");
//        }

//        [TestMethod]
//        public async SystemTask DeleteAllTasksForUser_RemovesOnlyUserTasks()
//        {
//            await _service.DeleteAllTasksForUser();

//            var tasks = LoadAllTasks();
//            var userTasks = tasks.Where(t => t.UserId == _loggedInUser).ToList();

//            Assert.AreEqual(0, userTasks.Count, "Semua task milik user seharusnya terhapus.");
//        }

//        [TestCleanup]
//        public void Cleanup()
//        {
//            if (File.Exists(_taskPath)) File.Delete(_taskPath);
//            if (File.Exists(_userPath)) File.Delete(_userPath);
//        }

//        private List<ModelTask> LoadAllTasks()
//        {
//            if (!File.Exists(_taskPath)) return new List<ModelTask>();
//            var json = File.ReadAllText(_taskPath);
//            return JsonSerializer.Deserialize<List<ModelTask>>(json) ?? new List<ModelTask>();
//        }
//    }
//}
