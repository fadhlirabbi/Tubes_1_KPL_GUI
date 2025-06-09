using API.Services;
using API.Model;
using SystemTask = System.Threading.Tasks.Task;
using ModelTask = API.Model.Task;

namespace Tubes_KPL_CLI
{
    internal class Program
    {
        private static string? _loggedInUser = null;
        private static TaskClientService? _taskClient = null;
        private static UserClientService _auth = new();
        private static TaskService _taskService = new();

        static async SystemTask Main()
        {
            while (true)
            {
                ShowMainMenu();
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        await HandleRegister();
                        break;
                    case "2":
                        await HandleLogin();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("Pilih opsi:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Pilih: ");
        }

        private static async SystemTask HandleRegister()
        {
            string username = PromptInput("Masukkan username: ");
            string password = PromptInput("Masukkan password: ");
            bool registerSuccess = await _auth.RegisterAsync(username, password);

            if (registerSuccess)
            {
                Console.WriteLine("Pendaftaran berhasil!");
            }
            else
            {
                Console.WriteLine("Pendaftaran gagal. Silakan coba lagi.");
            }
        }

        private static async SystemTask HandleLogin()
        {
            string username = PromptInput("Masukkan username: ");
            string password = PromptInput("Masukkan password: ");
            bool loginSuccessful = await _auth.TryLoginAsync(username, password);

            if (!loginSuccessful) return;

            _loggedInUser = username;
            _taskClient = new TaskClientService(_loggedInUser, new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/") });

            Console.WriteLine($"Berhasil login sebagai: {_loggedInUser}");

            await TaskLoop();
        }

        private static async SystemTask TaskLoop()
        {
            while (_loggedInUser != null)
            {
                _taskService.UpdateTaskStatus(_loggedInUser);
                ShowReminders();

                ShowTaskMenu();
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1": await CreateTask(); break;
                    case "2": await EditTask(); break;
                    case "3": await DeleteTask(); break;
                    case "4": await MarkTaskComplete(); break;
                    case "5": await DisplayTasks("ongoing"); break;
                    case "6": await DisplayTasks("overdue"); break;
                    case "7": await DisplayTasks("completed"); break;
                    case "8": await DeleteAccount(); break;
                    case "9":
                        await _auth.LogoutAsync();
                        _loggedInUser = null;
                        _taskClient = null;
                        Console.WriteLine("Berhasil logout.");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void ShowReminders()
        {
            if (_loggedInUser != null)
            {
                var reminders = _taskService.GenerateRemindersForTasks(_loggedInUser);

                if (reminders.Any())
                {
                    Console.WriteLine("\n=== Pengingat Tugas ===");
                    foreach (var reminder in reminders)
                    {
                        Console.WriteLine(reminder);
                    }
                }
                else
                {
                    Console.WriteLine("Tidak ada pengingat tugas saat ini.");
                }
            }
        }

        private static void ShowTaskMenu()
        {
            Console.WriteLine("\nPilih opsi:");
            Console.WriteLine("1. Buat Tugas");
            Console.WriteLine("2. Edit Tugas");
            Console.WriteLine("3. Hapus Tugas");
            Console.WriteLine("4. Tandai Tugas Selesai");
            Console.WriteLine("5. Lihat Tugas Ongoing");
            Console.WriteLine("6. Lihat Tugas Deadline");
            Console.WriteLine("7. Lihat Tugas Selesai");
            Console.WriteLine("8. Hapus Akun");
            Console.WriteLine("9. Logout");
            Console.Write("Pilih: ");
        }

        private static string PromptInput(string label)
        {
            Console.Write(label);
            return Console.ReadLine()?.Trim() ?? "";
        }

        private static int PromptInt(string label, int min, int max)
        {
            int val;
            Console.Write(label);
            while (!int.TryParse(Console.ReadLine(), out val) || val < min || val > max)
            {
                Console.Write($"Input tidak valid. {label}");
            }

            return val;
        }

        private static async SystemTask CreateTask()
        {
            string name = PromptInput("Nama tugas: ");
            string desc = PromptInput("Deskripsi tugas: ");
            int day = PromptInt("Tanggal (1-31): ", 1, 31);
            string month = PromptInput("Bulan (misalnya, januari): ");
            int year = PromptInt("Tahun: ", 1900, 3000);
            int hour = PromptInt("Jam (0-23): ", 0, 23);
            int minute = PromptInt("Menit (0-59): ", 0, 59);

            await _taskClient!.CreateTaskAsync(name, desc, day, month, year, hour, minute);
        }

        private static async SystemTask EditTask()
        {
            string oldName = PromptInput("Masukkan nama tugas yang ingin diubah: ");
            var task = (await _taskClient!.GetOngoingTasksAsync())
                .FirstOrDefault(t => t.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                Console.WriteLine($"Tugas '{oldName}' tidak ditemukan.");
                return;
            }

            string newName = PromptInput("Nama tugas baru: ");
            string desc = PromptInput("Deskripsi tugas baru: ");
            int day = PromptInt("Tanggal baru (1-31): ", 1, 31);
            string month = PromptInput("Bulan baru: ");
            int year = PromptInt("Tahun baru: ", 1900, 3000);
            int hour = PromptInt("Jam baru (0-23): ", 0, 23);
            int minute = PromptInt("Menit baru (0-59): ", 0, 59);

            await _taskClient.EditTask(oldName, newName, desc, day, month, year, hour, minute);
        }

        private static async SystemTask DeleteTask()
        {
            string name = PromptInput("Masukkan nama tugas yang ingin dihapus: ");
            string description = PromptInput("Masukkan deskripsi tugas yang ingin dihapus: ");
            int day = PromptInt("Tanggal (1-31): ", 1, 31);
            int month = PromptInt("Bulan (1-12): ", 1, 12);
            int year = PromptInt("Tahun: ", 1900, 3000);
            int hour = PromptInt("Jam (0-23): ", 0, 23);
            int minute = PromptInt("Menit (0-59): ", 0, 59);

            bool result = await _taskClient!.DeleteTaskAsync(name, description, day, month, year, hour, minute);
            Console.WriteLine(result ? "Tugas berhasil dihapus." : "Tugas tidak ditemukan.");
        }

        private static async SystemTask MarkTaskComplete()
        {
            string name = PromptInput("Task name: ");
            string description = PromptInput("Task description: ");
            int day = PromptInt("Deadline day (1-31): ", 1, 31);
            int month = PromptInt("Deadline month (1-12): ", 1, 12);
            int year = PromptInt("Deadline year: ", 1900, 3000);
            int hour = PromptInt("Deadline hour (0-23): ", 0, 23);
            int minute = PromptInt("Deadline minute (0-59): ", 0, 59);

            await _taskClient!.MarkTaskAsCompleted(name, description, day, month, year, hour, minute);
        }

        private static async SystemTask DisplayTasks(string type)
        {
            List<ModelTask> tasks = type switch
            {
                "ongoing" => await _taskClient!.GetOngoingTasksAsync(),
                "overdue" => await _taskClient!.GetOverdueTasksAsync(),
                "completed" => await _taskClient!.GetCompletedTasksAsync(),
                _ => new List<ModelTask>()
            };

            Console.WriteLine($"\n=== Tugas {type} ===");
            if (tasks.Count == 0)
            {
                Console.WriteLine("Tidak ada tugas.");
            }
            else
            {
                foreach (var task in tasks)
                    Console.WriteLine(task);
            }
        }

        private static async SystemTask DeleteAccount()
        {
            string confirm = PromptInput("Yakin ingin hapus akun dan semua tugas? (yes/no): ").ToLower();
            if (confirm == "yes")
            {
                await _auth.DeleteAccountAndTasksAsync();

                _loggedInUser = null;
                _taskClient = null;
            }
            else
            {
                Console.WriteLine("Penghapusan dibatalkan.");
            }
        }
    }
}
