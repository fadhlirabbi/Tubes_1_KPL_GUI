using Microsoft.AspNetCore.Mvc;
using API.Model;
using System.Text.Json;
using Task = API.Model.Task;
using Tubes_1_KPL.Model;

namespace API.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly string _filePath;

        public TaskController()
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string folderPath = Path.Combine(projectRoot, "Data");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            _filePath = Path.Combine(folderPath, "task.json");
        }

        // Load Tasks from JSON
        private List<Task> LoadTasks()
        {
            if (!System.IO.File.Exists(_filePath))
                return new List<Task>();

            var json = System.IO.File.ReadAllText(_filePath);
            return string.IsNullOrWhiteSpace(json)
                ? new List<Task>()
                : JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
        }

        // Save Tasks to JSON
        private void SaveTasks(List<Task> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_filePath, json);
        }

        // ✅ Create New Task
        [HttpPost]
        public IActionResult CreateTask([FromBody] Task newTask)
        {
            var tasks = LoadTasks();
            tasks.Add(newTask);
            SaveTasks(tasks);
            return Ok(new ApiResponse(201, "Task successfully created", newTask));
        }

        // ✅ Get All Tasks
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = LoadTasks();
            return Ok(new ApiResponse(200, "Tasks retrieved successfully", tasks));
        }

        // ✅ Get Task by ID
        [HttpGet("{id}")]
        public IActionResult GetTaskById(string id)
        {
            var tasks = LoadTasks();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound(new ApiResponse(404, "Task not found"));

            return Ok(new ApiResponse(200, "Task found", task));
        }
        [HttpPut("{username}/{taskName}")]
        public IActionResult UpdateTask(string username, string taskName, [FromBody] Task updatedTask)
        {
            var tasks = LoadTasks();

            // 🔍 Debugging - Cek total task yang di-load
            Console.WriteLine($"[DEBUG] Total Tasks Loaded: {tasks.Count}");

            // 🔍 Debugging - Tampilkan semua data task
            foreach (var t in tasks)
            {
                Console.WriteLine($"[DEBUG] Task: {t.Name}, User: {t.UserId}");
            }

            var task = tasks.FirstOrDefault(t => t.UserId == username && t.Name == taskName);

            if (task == null)
            {
                Console.WriteLine($"[DEBUG] Task '{taskName}' for user '{username}' not found!");
                return NotFound(new ApiResponse(404, "Task not found"));
            }

            // 🔄 Update Task
            task.Name = updatedTask.Name;
            task.Description = updatedTask.Description;
            task.Deadline = updatedTask.Deadline;
            task.Status = updatedTask.Status;

            // ✏️ [Tambahan]: Update UserId juga
            task.UserId = updatedTask.UserId;

            // 🔍 Debugging - Cek perubahan
            Console.WriteLine($"[DEBUG] Updated Task Name: {task.Name}");
            Console.WriteLine($"[DEBUG] Updated User ID: {task.UserId}");

            // 🔄 Simpan perubahan
            SaveTasks(tasks);

            // 🔍 Debugging - Verifikasi penyimpanan
            Console.WriteLine($"[DEBUG] Task successfully updated and saved to JSON!");

            return Ok(new ApiResponse(200, "Task successfully updated", task));
        }


        // ✅ Delete Task
        [HttpDelete("{username}")]
        public IActionResult DeleteTask(string username, [FromQuery] string taskName)
        {
            var tasks = LoadTasks();
            var task = tasks.FirstOrDefault(t => t.UserId == username && t.Name == taskName);

            if (task == null)
                return NotFound(new ApiResponse(404, "Task not found"));

            tasks.Remove(task);
            SaveTasks(tasks);

            return Ok(new ApiResponse(200, "Task successfully deleted"));
        }

        // ✅ Get Ongoing Tasks
        [HttpGet("ongoing/{username}")]
        public IActionResult GetOngoingTasks(string username)
        {
            var tasks = LoadTasks().Where(t => t.UserId == username && t.Status == Status.Incompleted).ToList();
            return Ok(new ApiResponse(200, "Ongoing tasks retrieved successfully", tasks));
        }

        // ✅ Get Completed Tasks
        [HttpGet("completed/{username}")]
        public IActionResult GetCompletedTasks(string username)
        {
            var tasks = LoadTasks().Where(t => t.UserId == username && t.Status == Status.Completed).ToList();
            return Ok(new ApiResponse(200, "Completed tasks retrieved successfully", tasks));
        }

        // ✅ Get Overdue Tasks
        [HttpGet("overdue/{username}")]
        public IActionResult GetOverdueTasks(string username)
        {
            var tasks = LoadTasks().Where(t => t.UserId == username && t.Status == Status.Overdue).ToList();
            return Ok(new ApiResponse(200, "Overdue tasks retrieved successfully", tasks));
        }
    }
}
