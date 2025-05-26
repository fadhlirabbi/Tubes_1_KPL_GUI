using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using API.Model;
using ModelTask = API.Model.Task;
using ModelDeadline = API.Model.Deadline;
using SystemTask = System.Threading.Tasks.Task;

namespace API.Services
{
    public class TaskClientService
    {
        private readonly HttpClient _http;
        private readonly string _user;

        public TaskClientService(string username, HttpClient client)
        {
            _user = username;
            _http = client;
        }

        public async SystemTask CreateTaskAsync(string name, string description, int day, string monthString, int year, int hour, int minute)
        {
            var deadline = new ModelDeadline
            {
                Day = day,
                Month = ConvertMonthToInt(monthString),
                Year = year,
                Hour = hour,
                Minute = minute
            };

            var task = new ModelTask(name, description, deadline, _user);

            var response = await _http.PostAsJsonAsync("task", task);
            var message = await response.Content.ReadAsStringAsync();

            Console.WriteLine(response.IsSuccessStatusCode
                ? "Tugas berhasil dibuat."
                : $"Gagal membuat tugas: {message}");
        }

        public async SystemTask EditTask(string oldName, string newName, string newDesc, int day, string month, int year, int hour, int minute)
        {
            var deadline = new ModelDeadline
            {
                Day = day,
                Month = ConvertMonthToInt(month),
                Year = year,
                Hour = hour,
                Minute = minute
            };

            var updated = new ModelTask(newName, newDesc, deadline, _user);

            var response = await _http.PutAsJsonAsync($"task/{_user}/{oldName}", updated);
            Console.WriteLine(response.IsSuccessStatusCode ? "Tugas berhasil diubah." : "Gagal mengubah tugas.");
        }

        public async Task<bool> DeleteTaskAsync(string taskName, string description, int day, int month, int year, int hour, int minute)
        {
            string url = $"task/{_user}?" +
                         $"taskName={Uri.EscapeDataString(taskName)}" +
                         $"&description={Uri.EscapeDataString(description)}" +
                         $"&day={day}&month={month}&year={year}&hour={hour}&minute={minute}";

            var response = await _http.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }


        public async Task<List<ModelTask>> GetOngoingTasksAsync() =>
            await GetTasksAsync($"task/ongoing/{_user}");

        public async Task<List<ModelTask>> GetCompletedTasksAsync() =>
            await GetTasksAsync($"task/completed/{_user}");

        public async Task<List<ModelTask>> GetOverdueTasksAsync() =>
            await GetTasksAsync($"task/overdue/{_user}");

        public async SystemTask MarkTaskAsCompleted(string taskName, string description, int day, int month, int year, int hour, int minute)
        {
            var response = await _http.PostAsync($"task/complete/{_user}?taskName={Uri.EscapeDataString(taskName)}" +
                                                  $"&description={Uri.EscapeDataString(description)}" +
                                                  $"&day={day}&month={month}&year={year}&hour={hour}&minute={minute}", null);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Task has been marked as completed.");
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to complete task: {message}");
            }
        }



        private async Task<List<ModelTask>> GetTasksAsync(string endpoint)
        {
            try
            {
                var response = await _http.GetAsync(endpoint);
                return await response.Content.ReadFromJsonAsync<List<ModelTask>>() ?? new List<ModelTask>();
            }
            catch
            {
                return new List<ModelTask>();
            }
        }

        private int ConvertMonthToInt(string month)
        {
            var dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"januari", 1}, {"februari", 2}, {"maret", 3}, {"april", 4},
                {"mei", 5}, {"juni", 6}, {"juli", 7}, {"agustus", 8},
                {"september", 9}, {"oktober", 10}, {"november", 11}, {"desember", 12}
            };

            return dict.TryGetValue(month.Trim(), out int m) ? m : 1;
        }

        private ReminderConfig LoadReminderConfig()
        {
            return new ReminderConfig();
        }

        public async Task<List<string>> GenerateRemindersForTasksAsync()
        {
            var reminders = new List<string>();
            var tasks = await GetOngoingTasksAsync(); 

            var reminderConfig = LoadReminderConfig();

            foreach (var task in tasks)
            {
                DateTime taskDeadline = new DateTime(task.Deadline.Year, task.Deadline.Month, task.Deadline.Day, task.Deadline.Hour, task.Deadline.Minute, 0);
                var daysUntilDeadline = (taskDeadline.Date - DateTime.Now.Date).Days;

                foreach (var rule in reminderConfig.Rules)
                {
                    if (daysUntilDeadline == rule.DaysBefore)
                    {
                        reminders.Add($"[REMINDER] Tugas '{task.Name}': {task.Description} akan jatuh tenggat pada {rule.Message} ({taskDeadline:dd/MM/yyyy HH:mm})");
                    }
                }
                if (daysUntilDeadline < 0)
                {
                    reminders.Add($"[REMINDER] Tugas '{task.Name}': {task.Description} sudah jatuh tenggat pada {taskDeadline:dd/MM/yyyy HH:mm}");
                }
                else if (daysUntilDeadline > 1)
                {
                    reminders.Add($"[REMINDER] Tugas '{task.Name}': {task.Description} akan jatuh tenggat pada ({taskDeadline:dd/MM/yyyy HH:mm})");
                }
            }

            return reminders;
        }
    }
}
