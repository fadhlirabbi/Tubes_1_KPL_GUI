using Microsoft.AspNetCore.Mvc;
using API.Model;
using System.Text.Json;
using Task = API.Model.Task;

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

        private List<Task> LoadTasks()
        {
            if (!System.IO.File.Exists(_filePath))
                return new List<Task>();

            var json = System.IO.File.ReadAllText(_filePath);
            return string.IsNullOrWhiteSpace(json)
                ? new List<Task>()
                : JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
        }

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
            return CreatedAtAction(nameof(GetTaskById), new { id = newTask.Id }, newTask);
        }

        // ✅ Get All Tasks
        [HttpGet]
        public IActionResult GetAllTasks() => Ok(LoadTasks());

        // ✅ Get Task by ID
        [HttpGet("{id}")]
        public IActionResult GetTaskById(string id)
        {
            var tasks = LoadTasks();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            return task == null ? NotFound(new { Message = "Task not found" }) : Ok(task);
        }
        // ✅ Update Task
        [HttpPut("{username}/{taskName}")]
        public IActionResult UpdateTask(string username, string taskName, [FromBody] Task updatedTask)
        {
            var tasks = LoadTasks();
            var task = tasks.FirstOrDefault(t => t.UserId == username && t.Name == taskName);

            if (task == null)
                return NotFound(new { Message = "Task not found" });

            // 🔄 Update Fields
            task.Name = updatedTask.Name;
            task.Description = updatedTask.Description;
            task.Deadline = updatedTask.Deadline;
            task.Status = updatedTask.Status;

            // ✅ Update UserId juga
            if (!string.IsNullOrEmpty(updatedTask.UserId) && updatedTask.UserId != task.UserId)
            {
                Console.WriteLine($"[DEBUG] Updating UserId from '{task.UserId}' to '{updatedTask.UserId}'");
                task.UserId = updatedTask.UserId;
            }

            SaveTasks(tasks);

            return Ok(new { Message = "Task successfully updated", Task = task });
        }


        // ✅ Delete Task
        [HttpDelete("{username}")]
        public IActionResult DeleteTask(string username, [FromQuery] string taskName)
        {
            var tasks = LoadTasks();
            var task = tasks.FirstOrDefault(t => t.UserId == username && t.Name == taskName);

            if (task == null)
                return NotFound(new { Message = "Task not found" });

            tasks.Remove(task);
            SaveTasks(tasks);
            return Ok(new { Message = "Task successfully deleted" });
        }

        // ✅ Get Ongoing Tasks
        [HttpGet("ongoing/{username}")]
        public IActionResult GetOngoingTasks(string username)
        {
            var tasks = LoadTasks().Where(t => t.UserId == username && t.Status == Status.Incompleted).ToList();
            return Ok(tasks);
        }

        // ✅ Get Completed Tasks
        [HttpGet("completed/{username}")]
        public IActionResult GetCompletedTasks(string username)
        {
            var tasks = LoadTasks().Where(t => t.UserId == username && t.Status == Status.Completed).ToList();
            return Ok(tasks);
        }

        // ✅ Get Overdue Tasks
        [HttpGet("overdue/{username}")]
        public IActionResult GetOverdueTasks(string username)
        {
            var tasks = LoadTasks().Where(t => t.UserId == username && t.Status == Status.Overdue).ToList();
            return Ok(tasks);
        }

    }
}
