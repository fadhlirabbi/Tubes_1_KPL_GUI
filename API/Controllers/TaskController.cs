using Microsoft.AspNetCore.Mvc;
using API.Model;
using API.Services;
using ModelTask = API.Model.Task;

namespace API.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _service = new();

        [HttpPost]
        public IActionResult Create([FromBody] ModelTask task)
        {
            var result = _service.CreateTask(task);
            return result.Success ? CreatedAtAction(nameof(GetById), new { id = task.Id }, result.Data)
                                  : BadRequest(result.Message);
        }

        [HttpPost("complete/{username}")]
        public IActionResult MarkTaskAsCompleted(
            string username,
            [FromQuery] string taskName,
            [FromQuery] string description,
            [FromQuery] int day,
            [FromQuery] int month,
            [FromQuery] int year,
            [FromQuery] int hour,
            [FromQuery] int minute)
        {
            var result = _service.MarkTaskAsCompleted(username, taskName, description, day, month, year, hour, minute);
            
            if (result.Success)
            {
                return Ok(new { Message = result.Message, Task = result.Data });
            }
            else
            {
                return BadRequest(new { Message = result.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllTasks());

        [HttpGet("user/{username}")]
        public IActionResult GetByUser(string username) => Ok(_service.GetByUser(username));

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var task = _service.GetById(id);
            return task == null ? NotFound("Task not found") : Ok(task);
        }

        [HttpPut("{username}/{taskName}")]
        public IActionResult EditTask(string username, string taskName, [FromBody] ModelTask task)
        {
            var result = _service.EditTask(username, taskName, task);
            return result.Success ? Ok(result) : NotFound(result.Message);
        }

        [HttpDelete("{username}")]
        public IActionResult Delete(
        string username,
        [FromQuery] string taskName,
        [FromQuery] string description,
        [FromQuery] int day,
        [FromQuery] int month,
        [FromQuery] int year,
        [FromQuery] int hour,
        [FromQuery] int minute)
        {
            var result = _service.DeleteTask(username, taskName, description, day, month, year, hour, minute);
            return result.Success ? Ok(result.Message) : NotFound(result.Message);
        }

        [HttpPost("update-status")]
        public IActionResult UpdateTaskStatus()  
        {
            try
            {
                var response = _service.UpdateTaskStatus();  
                if (response.Success)
                {
                    return Ok(new { Message = response.Message });
                }
                else
                {
                    return StatusCode(response.StatusCode, new { Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Terjadi kesalahan pada server.", Error = ex.Message });
            }
        }


        [HttpGet("ongoing/{username}")]
        public IActionResult GetOngoingTasks(string username) =>
            Ok(_service.GetTaskByStatus(username, Status.Incompleted));

        [HttpGet("completed/{username}")]
        public IActionResult GetCompletedTasks(string username) =>
            Ok(_service.GetTaskByStatus(username, Status.Completed));

        [HttpGet("overdue/{username}")]
        public IActionResult GetOverdueTasks(string username) =>
            Ok(_service.GetTaskByStatus(username, Status.Overdue));
    }
}
