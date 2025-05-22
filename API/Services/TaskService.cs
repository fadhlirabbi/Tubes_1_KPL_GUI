using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Model;
using ModelTask = API.Model.Task;
using ModelDeadline = API.Model.Deadline;
using SystemTask = System.Threading.Tasks.Task;

namespace API.Services
{
    public class TaskService
    {
        private readonly string _filePath;
        public TaskService()
        {
            string root = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "API", "Data"); 
            Directory.CreateDirectory(root);
            _filePath = Path.Combine(root, "task.json");
        }

        private List<ModelTask> Load()
        {
            if (!File.Exists(_filePath)) return new List<ModelTask>();
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<ModelTask>>(json) ?? new List<ModelTask>();
        }

        private void Save(List<ModelTask> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public ApiResponse CreateTask(ModelTask task)
        {
            var tasks = Load();

            bool isDuplicate = tasks.Any(t =>
                t.UserId == task.UserId &&
                t.Name.Equals(task.Name, StringComparison.OrdinalIgnoreCase) &&
                t.Description.Equals(task.Description, StringComparison.OrdinalIgnoreCase) &&
                t.Deadline.Day == task.Deadline.Day &&
                t.Deadline.Month == task.Deadline.Month &&
                t.Deadline.Year == task.Deadline.Year &&
                t.Deadline.Hour == task.Deadline.Hour &&
                t.Deadline.Minute == task.Deadline.Minute
            );

            if (isDuplicate)
            {
                return new ApiResponse(400, "Tugas dengan nama, deskripsi, dan deadline yang sama sudah ada.");
            }

            task.Id = Guid.NewGuid().ToString();
            tasks.Add(task);
            Save(tasks);
            return new ApiResponse(201, "Tugas berhasil dibuat.", task);
        }



        public ApiResponse MarkTaskAsCompleted(string username, string taskName, string description, int day, int month, int year, int hour, int minute)
        {
            var tasks = Load();
            var task = tasks.FirstOrDefault(t =>
                t.UserId == username &&
                t.Name == taskName &&
                t.Description == description &&
                t.Deadline.Day == day &&
                t.Deadline.Month == month &&
                t.Deadline.Year == year &&
                t.Deadline.Hour == hour &&
                t.Deadline.Minute == minute);

            if (task == null)
            {
                return new ApiResponse(404, "Task not found with the provided name, description, and deadline.");
            }

            if (task.Status == Status.Completed)
            {
                return new ApiResponse(400, "This task is already marked as completed.");
            }

            task.Status = Status.Completed;
            Save(tasks);
            return new ApiResponse(200, "Task successfully marked as completed.", task);
        }


        public List<ModelTask> GetAll() => Load();

        public List<ModelTask> GetByUser(string username) =>
            Load().Where(t => t.UserId == username).ToList();

        public ModelTask? GetById(string id) =>
            Load().FirstOrDefault(t => t.Id == id);

        public ApiResponse Update(string username, string taskName, ModelTask updated)
        {
            var tasks = Load();
            var task = tasks.FirstOrDefault(t => t.UserId == username && t.Name == taskName);
            if (task == null) return new ApiResponse(404, "Task tidak ditemukan");

            task.Name = updated.Name;
            task.Description = updated.Description;
            task.Deadline = updated.Deadline;
            task.Status = updated.Status;
            task.UserId = updated.UserId;

            Save(tasks);
            return new ApiResponse(200, "Task berhasil di-update", task);
        }

        public ApiResponse Delete(string username, string taskName, string description, int day, int month, int year, int hour, int minute)
        {
            var tasks = Load();
            var task = tasks.FirstOrDefault(t =>
                t.UserId == username &&
                t.Name == taskName &&
                t.Description == description &&
                t.Deadline.Day == day &&
                t.Deadline.Month == month &&
                t.Deadline.Year == year &&
                t.Deadline.Hour == hour &&
                t.Deadline.Minute == minute);

            if (task == null) return new ApiResponse(404, "Task tidak ditemukan");

            tasks.Remove(task);
            Save(tasks);
            return new ApiResponse(200, "Task berhasil di-hapus");
        }


        public List<ModelTask> GetByStatus(string username, Status status) =>
            Load().Where(t => t.UserId == username && t.Status == status).ToList();

        public void UpdateTaskStatus()
        {
            var tasks = Load();
            var now = DateTime.Now;

            foreach (var task in tasks)
            {
                if (task.Status == Status.Completed) continue; 

                DateTime taskDeadline = new DateTime(task.Deadline.Year, task.Deadline.Month, task.Deadline.Day, task.Deadline.Hour, task.Deadline.Minute, 0);

                if (now > taskDeadline && task.Status != Status.Completed)
                {
                    task.Status = Status.Overdue; 
                }
                else if (now <= taskDeadline && task.Status == Status.Incompleted)
                {

                }
            }

            Save(tasks);
        }

        private ReminderConfig LoadReminderConfig()
        {
            return new ReminderConfig();
        }

        public List<string> GenerateRemindersForTasks(string username)
        {
            var tasks = Load().Where(t => t.UserId == username && t.Status != Status.Completed).ToList();
            var reminders = new List<string>();

            var reminderConfig = LoadReminderConfig();

            foreach (var task in tasks)
            {
                DateTime taskDeadline = new DateTime(
                    task.Deadline.Year,
                    task.Deadline.Month,
                    task.Deadline.Day,
                    task.Deadline.Hour,
                    task.Deadline.Minute,
                    0
                );

                int daysUntilDeadline = (taskDeadline.Date - DateTime.Now.Date).Days;
                bool matchedRule = false;

                foreach (var rule in reminderConfig.Rules)
                {
                    if (daysUntilDeadline == rule.DaysBefore)
                    {
                        reminders.Add($"[REMINDER] Tugas '{task.Name}': {task.Description} akan jatuh tenggat pada {rule.Message} ({taskDeadline:dd/MM/yyyy HH:mm})");
                        matchedRule = true;
                        break;
                    }
                }

                if (!matchedRule)
                {
                    if (daysUntilDeadline < 0)
                    {
                        reminders.Add($"[REMINDER] Tugas '{task.Name}': {task.Description} sudah jatuh tenggat pada {taskDeadline:dd/MM/yyyy HH:mm}");
                    }
                    else
                    {
                        reminders.Add($"[REMINDER] Tugas '{task.Name}': {task.Description} akan jatuh tenggat pada {taskDeadline:dd/MM/yyyy HH:mm}");
                    }
                }
            }

            return reminders;
        }

    }
}
