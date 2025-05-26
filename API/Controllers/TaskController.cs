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
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }



        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("user/{username}")]
        public IActionResult GetByUser(string username) => Ok(_service.GetByUser(username));

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var task = _service.GetById(id);
            return task == null ? NotFound("Task not found") : Ok(task);
        }

        [HttpPut("{username}/{taskName}")]
        public IActionResult Update(string username, string taskName, [FromBody] ModelTask task)
        {
            var result = _service.Update(username, taskName, task);
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
            var result = _service.Delete(username, taskName, description, day, month, year, hour, minute);
            return result.Success ? Ok(result.Message) : NotFound(result.Message);
        }


        [HttpGet("ongoing/{username}")]
        public IActionResult GetOngoing(string username) =>
            Ok(_service.GetByStatus(username, Status.Incompleted));

        [HttpGet("completed/{username}")]
        public IActionResult GetCompleted(string username) =>
            Ok(_service.GetByStatus(username, Status.Completed));

        [HttpGet("overdue/{username}")]
        public IActionResult GetOverdue(string username) =>
            Ok(_service.GetByStatus(username, Status.Overdue));
    }
}
