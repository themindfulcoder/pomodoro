using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pomo_api.Repositories;

namespace pomo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private TasksRepository tasksRepository { get; set; }

        public TasksController(TasksRepository tasksRepository)
        {
            this.tasksRepository = tasksRepository;
        }
        // GET api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<Models.Task>> Get()
        {
            var result = new List<Models.Task>();
            result.Add(new Models.Task{ Id = 0, Description = "Add task and optionally size", Size = Models.TaskSize.Small });
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
