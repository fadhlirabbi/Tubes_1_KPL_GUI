//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text.Json;
//using API.Model;
//using ModelTask = API.Model.Task;


//namespace Test3
//{
//    [TestClass]
//    public sealed class TaskCreatorTests
//    {
//        private LocalTaskCreator _taskCreator;
//        private string _filePath;

//        [TestInitialize]
//        public void Setup()
//        {
//            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
//            string dataFolder = Path.Combine(projectRoot, "API", "Data");
//            _filePath = Path.Combine(dataFolder, "task.json");

//            if (File.Exists(_filePath))
//                File.Delete(_filePath); 

//            Directory.CreateDirectory(dataFolder);
//            _taskCreator = new LocalTaskCreator("testuser", _filePath);
//        }

//        [TestMethod]
//        public void TestCreateTask()
//        {
//            string name = "Tugas 1";
//            string description = "Deskripsi tugas 1";
//            int day = 5, month = 1, year = 2025, hour = 14, minute = 30;

//            _taskCreator.CreateTask(name, description, day, month, year, hour, minute);

//            var tasks = _taskCreator.GetUserTasks();
//            var createdTask = tasks.Find(t => t.Name == name);

//            Assert.IsNotNull(createdTask, "Tugas tidak berhasil dibuat.");
//            Assert.AreEqual(description, createdTask.Description, "Deskripsi tugas tidak sesuai.");
//        }

//        [TestMethod]
//        public void TestEditTask()
//        {
//            string oldName = "Tugas 1";
//            string newName = "Tugas 1 (Updated)";
//            string newDesc = "Deskripsi tugas diperbarui";
//            int newDay = 10, newMonth = 1, newYear = 2025, newHour = 16, newMinute = 45;

//            _taskCreator.CreateTask(oldName, "Deskripsi awal", 5, 1, 2025, 14, 30);
//            _taskCreator.EditTask(oldName, newName, newDesc, newDay, newMonth, newYear, newHour, newMinute);

//            var tasks = _taskCreator.GetUserTasks();
//            var editedTask = tasks.Find(t => t.Name == newName);

//            Assert.IsNotNull(editedTask, "Tugas yang diedit tidak ditemukan.");
//            Assert.AreEqual(newDesc, editedTask.Description, "Deskripsi tidak sesuai.");
//            Assert.AreEqual(newDay, editedTask.Deadline.Day);
//            Assert.AreEqual(newHour, editedTask.Deadline.Hour);
//        }


//        private class LocalTaskCreator
//        {
//            private readonly string _userId;
//            private readonly string _filePath;

//            public LocalTaskCreator(string userId, string filePath)
//            {
//                _userId = userId;
//                _filePath = filePath;
//            }

//            public void CreateTask(string name, string desc, int day, int month, int year, int hour, int minute)
//            {
//                if (!IsValidDate(day, month, year)) return;

//                var task = new ModelTask(name, desc, new Deadline { Day = day, Month = month, Year = year, Hour = hour, Minute = minute }, _userId);
//                var tasks = Load();
//                tasks.Add(task);
//                Save(tasks);
//            }

//            public void EditTask(string oldName, string newName, string newDesc, int day, int month, int year, int hour, int minute)
//            {
//                var tasks = Load();
//                var task = tasks.FirstOrDefault(t => t.UserId == _userId && t.Name == oldName);
//                if (task == null || !IsValidDate(day, month, year)) return;

//                task.Name = newName;
//                task.Description = newDesc;
//                task.Deadline = new Deadline { Day = day, Month = month, Year = year, Hour = hour, Minute = minute };
//                Save(tasks);
//            }

//            public List<ModelTask> GetUserTasks()
//            {
//                return Load().Where(t => t.UserId == _userId).ToList();
//            }

//            private List<ModelTask> Load()
//            {
//                if (!File.Exists(_filePath)) return new List<ModelTask>();
//                var json = File.ReadAllText(_filePath);
//                return JsonSerializer.Deserialize<List<ModelTask>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ModelTask>();
//            }

//            private void Save(List<ModelTask> tasks)
//            {
//                var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
//                File.WriteAllText(_filePath, json);
//            }

//            private bool IsValidDate(int day, int month, int year)
//            {
//                return day > 0 && day <= DateTime.DaysInMonth(year, month);
//            }
//        }
//    }
//}
