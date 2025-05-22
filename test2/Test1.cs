//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text.Json;
//using System.Threading.Tasks;
//using API.Model;
//using ModelTask = API.Model.Task;
//using ModelDeadline = API.Model.Deadline;
//using SystemTask = System.Threading.Tasks.Task;

//namespace Tubes_1_KPL.Tests
//{
//    [TestClass]
//    public class TaskServiceTests
//    {
//        private LocalTaskService _service;
//        private const string JsonPath = "Data/task.json";

//        [TestInitialize]
//        public void Setup()
//        {
//            if (File.Exists(JsonPath))
//                File.Delete(JsonPath); 

//            Directory.CreateDirectory(Path.GetDirectoryName(JsonPath)!);
//        }

//        [TestMethod]
//        public async SystemTask CreateTask_ValidData_TaskIsCreated()
//        {
//            string userId = "test_user_1";
//            _service = new LocalTaskService(userId);

//            string name = $"Tugas-{Guid.NewGuid()}";
//            string description = "Deskripsi tugas";
//            int day = 25, year = 2025, hour = 9, minute = 15;
//            string month = "Mei";

//            await _service.CreateTaskAsync(name, description, day, month, year, hour, minute);

//            var tasks = _service.GetUserTasks();
//            Assert.IsTrue(tasks.Exists(t => t.Name == name && t.UserId == userId));
//        }

//        [TestMethod]
//        public async SystemTask CreateTask_InvalidDate_TaskIsRejected()
//        {
//            string userId = "test_user_2";
//            _service = new LocalTaskService(userId);

//            string name = "Tugas Salah";
//            await _service.CreateTaskAsync(name, "Deskripsi", 31, "Februari", 2025, 10, 0);

//            var tasks = _service.GetUserTasks();
//            Assert.IsFalse(tasks.Exists(t => t.Name == name));
//        }

//        [TestMethod]
//        public void GetUserTasks_NoTasks_ReturnsEmptyList()
//        {
//            string userId = "kosong_user";
//            _service = new LocalTaskService(userId);

//            var tasks = _service.GetUserTasks();
//            Assert.AreEqual(0, tasks.Count);
//        }


//        private class LocalTaskService
//        {
//            private readonly string _userId;
//            private readonly string _filePath = JsonPath;
//            private readonly Dictionary<string, int> _monthTable = new(StringComparer.OrdinalIgnoreCase)
//            {
//                { "januari", 1 }, { "februari", 2 }, { "maret", 3 }, { "april", 4 },
//                { "mei", 5 }, { "juni", 6 }, { "juli", 7 }, { "agustus", 8 },
//                { "september", 9 }, { "oktober", 10 }, { "november", 11 }, { "desember", 12 }
//            };

//            public LocalTaskService(string userId)
//            {
//                _userId = userId;
//            }

//            public async SystemTask CreateTaskAsync(string name, string description, int day, string monthStr, int year, int hour, int minute)
//            {
//                if (!_monthTable.ContainsKey(monthStr)) return;

//                int month = _monthTable[monthStr];
//                if (!IsValidDate(day, month, year)) return;

//                var deadline = new ModelDeadline
//                {
//                    Day = day,
//                    Month = month,
//                    Year = year,
//                    Hour = hour,
//                    Minute = minute
//                };

//                var task = new ModelTask(name, description, deadline, _userId);

//                var tasks = LoadTasks();
//                tasks.Add(task);
//                SaveTasks(tasks);

//                await SystemTask.CompletedTask;
//            }

//            public List<ModelTask> GetUserTasks()
//            {
//                return LoadTasks().Where(t => t.UserId == _userId).ToList();
//            }

//            private bool IsValidDate(int day, int month, int year)
//            {
//                return day <= DateTime.DaysInMonth(year, month);
//            }

//            private List<ModelTask> LoadTasks()
//            {
//                if (!File.Exists(_filePath)) return new List<ModelTask>();
//                var json = File.ReadAllText(_filePath);
//                return JsonSerializer.Deserialize<List<ModelTask>>(json) ?? new List<ModelTask>();
//            }

//            private void SaveTasks(List<ModelTask> tasks)
//            {
//                var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
//                File.WriteAllText(_filePath, json);
//            }
//        }
//    }
//}
