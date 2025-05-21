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
        private readonly Dictionary<string, int> _monthTable;
        private static Dictionary<string, List<ModelTask>> _userTasks = new();
        private readonly string _loggedInUser;
        public readonly HttpClient _http;

        public TaskService(string loggedInUser, HttpClient httpClient)
        {
            Contract.Requires(httpClient != null, "HttpClient tidak boleh null.");
            Contract.Requires(!string.IsNullOrEmpty(loggedInUser), "LoggedInUser tidak boleh null atau kosong.");

            _http = httpClient;
            _loggedInUser = loggedInUser;

            _monthTable = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"januari", 1}, {"februari", 2}, {"maret", 3}, {"april", 4},
                {"mei", 5}, {"juni", 6}, {"juli", 7}, {"agustus", 8},
                {"september", 9}, {"oktober", 10}, {"november", 11}, {"desember", 12}
            };

            if (!_userTasks.ContainsKey(_loggedInUser))
            {
                _userTasks[_loggedInUser] = new List<ModelTask>();
            }

            SyncTasksFromApiAsync().Wait();
        }

        private async SystemTask SyncTasksFromApiAsync()
        {
            try
            {
                var ongoingTasks = await GetOngoingTasksAsync();
                var completedTasks = await GetCompletedTasksAsync();
                var overdueTasks = await GetOverdueTasksAsync();

                if (_userTasks.ContainsKey(_loggedInUser))
                {
                    _userTasks[_loggedInUser].Clear();
                }
                else
                {
                    _userTasks[_loggedInUser] = new List<ModelTask>();
                }

                _userTasks[_loggedInUser].AddRange(ongoingTasks);
                _userTasks[_loggedInUser].AddRange(completedTasks);
                _userTasks[_loggedInUser].AddRange(overdueTasks);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error syncing tasks from API: {ex.Message}");
            }
        }

        public async SystemTask CreateTaskAsync(string name, string description, int day, string monthString, int year, int hour, int minute)
        {
            Contract.Requires(!string.IsNullOrEmpty(name));
            Contract.Requires(!string.IsNullOrEmpty(description));
            Contract.Requires(day > 0 && day <= 31);
            Contract.Requires(!string.IsNullOrEmpty(monthString));
            Contract.Requires(year > 0);
            Contract.Requires(hour >= 0 && hour <= 23);
            Contract.Requires(minute >= 0 && minute <= 59);
            Contract.Requires(_monthTable.ContainsKey(monthString));

            if (_userTasks.TryGetValue(_loggedInUser, out var tasks))
            {
                int month = _monthTable[monthString];
                if (IsValidDate(day, month, year))
                {
                    var deadline = new ModelDeadline { Day = day, Month = month, Year = year, Hour = hour, Minute = minute };
                    var task = new ModelTask(name, description, deadline, _loggedInUser);
                    tasks.Add(task);

                    var jsonContent = JsonSerializer.Serialize(task);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    var response = await _http.PostAsync("task", content);

                    Console.WriteLine(response.IsSuccessStatusCode
                        ? "Tugas berhasil dibuat di API."
                        : $"Gagal membuat tugas di API. Status: {response.StatusCode}");
                }
                else
                {
                    Console.WriteLine("Tanggal tidak valid.");
                }
            }
        }

        public async SystemTask EditTask(string oldTaskName, string newName, string newDescription, int newDay, string newMonthString, int newYear, int newHour, int newMinute)
        {
            Contract.Requires(!string.IsNullOrEmpty(oldTaskName));
            Contract.Requires(!string.IsNullOrEmpty(newName));
            Contract.Requires(!string.IsNullOrEmpty(newDescription));
            Contract.Requires(newDay > 0 && newDay <= 31);
            Contract.Requires(!string.IsNullOrEmpty(newMonthString));
            Contract.Requires(newYear > 0);
            Contract.Requires(newHour >= 0 && newHour <= 23);
            Contract.Requires(newMinute >= 0 && newMinute <= 59);
            Contract.Requires(_monthTable.ContainsKey(newMonthString));

            await SyncTasksFromApiAsync();

            if (_userTasks.TryGetValue(_loggedInUser, out var tasks))
            {
                var taskToEdit = tasks.FirstOrDefault(t => t.Name.Equals(oldTaskName, StringComparison.OrdinalIgnoreCase));

                if (taskToEdit != null)
                {
                    int newMonth = _monthTable[newMonthString];
                    if (IsValidDate(newDay, newMonth, newYear))
                    {
                        taskToEdit.Name = newName;
                        taskToEdit.Description = newDescription;
                        taskToEdit.Deadline = new ModelDeadline { Day = newDay, Month = newMonth, Year = newYear, Hour = newHour, Minute = newMinute };

                        var jsonContent = JsonSerializer.Serialize(taskToEdit);
                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        var response = await _http.PutAsync($"task/{_loggedInUser}/{oldTaskName}", content);
                        Console.WriteLine($"Tugas '{oldTaskName}' berhasil diubah.");

                        await SyncTasksFromApiAsync();
                    }
                    else
                    {
                        Console.WriteLine("Tanggal baru tidak valid.");
                    }
                }
                else
                {
                    Console.WriteLine($"Tugas dengan nama '{oldTaskName}' tidak ditemukan.");
                }
            }
        }

        public async SystemTask MarkTaskAsCompleted(string taskName, string answer)
        {
            Contract.Requires(!string.IsNullOrEmpty(taskName));
            Contract.Requires(!string.IsNullOrEmpty(answer));

            await SyncTasksFromApiAsync();

            if (!_userTasks.TryGetValue(_loggedInUser, out var tasks))
            {
                Console.WriteLine("Pengguna tidak memiliki tugas.");
                return;
            }

            var task = tasks.FirstOrDefault(t => t.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase));
            if (task == null)
            {
                Console.WriteLine($"Tugas '{taskName}' tidak ditemukan.");
                return;
            }

            var answerTable = new Dictionary<string, Status>(StringComparer.OrdinalIgnoreCase)
            {
                { "yes", Status.Completed },
                { "no", Status.Incompleted }
            };

            if (!answerTable.TryGetValue(answer, out var newStatus))
            {
                Console.WriteLine("Input tidak valid. Harus 'yes' atau 'no'.");
                return;
            }

            if (task.Status == Status.Incompleted && newStatus == Status.Completed)
            {
                task.Status = Status.Completed;
                var jsonContent = JsonSerializer.Serialize(task);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                await _http.PutAsync($"task/{_loggedInUser}/{taskName}", content);
                Console.WriteLine($"Tugas '{taskName}' berhasil ditandai selesai.");
                await SyncTasksFromApiAsync();
            }
            else if (task.Status == Status.Completed)
            {
                Console.WriteLine($"Tugas '{taskName}' sudah selesai sebelumnya.");
            }
            else if (task.Status == Status.Overdue)
            {
                Console.WriteLine($"Tugas '{taskName}' sudah melewati batas waktu.");
            }
            else
            {
                Console.WriteLine($"Tugas '{taskName}' tetap dalam status belum selesai.");
            }
        }

        public async Task<bool> DeleteTaskAsync(string taskName)
        {
            if (!_userTasks.TryGetValue(_loggedInUser, out var tasks))
            {
                Console.WriteLine("User tidak memiliki tugas.");
                return false;
            }

            var taskToDelete = tasks.FirstOrDefault(t => t.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase));
            if (taskToDelete == null)
            {
                Console.WriteLine($"Tugas '{taskName}' tidak ditemukan.");
                return false;
            }

            var response = await _http.DeleteAsync($"task/{_loggedInUser}?taskName={Uri.EscapeDataString(taskName)}");
            if (response.IsSuccessStatusCode)
            {
                tasks.Remove(taskToDelete);
                Console.WriteLine($"Tugas '{taskName}' berhasil dihapus.");
                return true;
            }

            Console.WriteLine($"Gagal menghapus tugas di API. Status: {response.StatusCode}");
            return false;
        }

        public async Task<List<ModelTask>> GetOngoingTasksAsync() =>
            await GetTasksFromApiAsync($"task/ongoing/{_loggedInUser}");

        public async Task<List<ModelTask>> GetOverdueTasksAsync() =>
            await GetTasksFromApiAsync($"task/overdue/{_loggedInUser}");

        public async Task<List<ModelTask>> GetCompletedTasksAsync() =>
            await GetTasksFromApiAsync($"task/completed/{_loggedInUser}");

        private async Task<List<ModelTask>> GetTasksFromApiAsync(string endpoint)
        {
            try
            {
                var response = await _http.GetAsync($"{endpoint}?userId={_loggedInUser}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<ModelTask>>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<ModelTask>();
                }

                Console.WriteLine($"Gagal mengambil data dari API. Status: {response.StatusCode}");
                return new List<ModelTask>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan saat menghubungi API: {ex.Message}");
                return new List<ModelTask>();
            }
        }

        private bool IsValidDate(int day, int month, int year) =>
            day <= DateTime.DaysInMonth(year, month);

        public List<ModelTask> GetUserTasks()
        {
            SyncTasksFromApiAsync().Wait();
            return _userTasks.TryGetValue(_loggedInUser, out var tasks)
                ? new List<ModelTask>(tasks)
                : new List<ModelTask>();
        }

        public void ShowReminders(ReminderConfig config)
        {
            SyncTasksFromApiAsync().Wait();
            var now = DateTime.Now;
            var userTasks = GetUserTasks();

            foreach (var task in userTasks)
            {
                if (task == null || string.IsNullOrEmpty(task.Name)) continue;

                var deadline = new DateTime(
                    task.Deadline.Year, task.Deadline.Month, task.Deadline.Day,
                    task.Deadline.Hour, task.Deadline.Minute, 0);
                    
                if (task.Status == Status.Incompleted && now > deadline)
                {
                    task.Status = Status.Overdue;
                    var jsonContent = JsonSerializer.Serialize(task);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    _http.PutAsync($"task/{_loggedInUser}/{task.Name}", content).Wait();
                    continue;
                }

                if (task.Status != Status.Incompleted) continue;

                int daysDiff = (deadline.Date - now.Date).Days;

                foreach (var rule in config.ReminderRules)
                {
                    if (daysDiff == rule.DaysBefore)
                    {
                        Console.WriteLine($"[Reminder] Tugas '{task.Name}' akan jatuh tempo {rule.Message} pada {deadline}.");
                    }
                }
            }
        }

        public async SystemTask DeleteAllTasksForUser()
        {
            var allTasks = await GetUserTasksFromApi();
            if (allTasks == null || allTasks.Count == 0)
            {
                Console.WriteLine("Tidak ada tugas yang perlu dihapus.");
                return;
            }

            foreach (var task in allTasks)
            {
                var response = await _http.DeleteAsync($"task/{_loggedInUser}?taskName={Uri.EscapeDataString(task.Name)}");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Gagal menghapus tugas '{task.Name}'. Status: {response.StatusCode}");
                }
            }

            Console.WriteLine("Semua tugas berhasil dihapus.");
        }

        private async Task<List<ModelTask>> GetUserTasksFromApi()
        {
            try
            {
                var response = await _http.GetAsync($"task/user/{_loggedInUser}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var tasks = JsonSerializer.Deserialize<List<ModelTask>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return tasks ?? new List<ModelTask>();
                }

                Console.WriteLine($"Gagal mengambil tugas user. Status: {response.StatusCode}");
                return new List<ModelTask>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kesalahan saat mengambil tugas user: {ex.Message}");
                return new List<ModelTask>();
            }
        }
    }
}
