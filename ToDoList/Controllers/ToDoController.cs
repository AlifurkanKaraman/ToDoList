using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private static List<ToDo> toDoList =
        [
            new ToDo("Brush teeth", "Brush teeth in the morning"),
            new ToDo("Read book", "Read for 30 minutes"),
            new ToDo("Breakfast", "Make yourself a breakfast"),
            new ToDo("Study programming", "Do 4 pomodoros for it"),
            new ToDo("Lunch", "Prepare something for it")
        ];
        // GET: api/<ToDoController>
        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return toDoList;
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public ActionResult<ToDo> Get(int id)
        {
            var currentToDo = toDoList.FirstOrDefault(ToDo => ToDo.Id == id);
            if (currentToDo != null)
            {
                return Ok(currentToDo);
            }

            return NotFound($"Requested ToDo with id {id} is not found!");
        }

        // POST api/<ToDoController>
        [HttpPost]
        public IActionResult Post([FromBody] ToDoDto newToDoDto)
        {
            if (string.IsNullOrWhiteSpace(newToDoDto.Title))
            {
                return BadRequest("Title is required.");
            }
            var newToDo = new ToDo(newToDoDto.Title, newToDoDto.Description);
            toDoList.Add(newToDo);
            return Ok("ToDo added successfully.");
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public ActionResult<ToDo> Put(int id, [FromBody] ToDo newToDo)
        {
            var currentToDo = toDoList.FirstOrDefault(ToDo => ToDo.Id == id);
            if (currentToDo != null)
            {
                if (!string.IsNullOrEmpty(newToDo.Title))
                    currentToDo.Title = newToDo.Title;
                if (!string.IsNullOrEmpty(newToDo.Description))
                    currentToDo.Description = newToDo.Description;
                if (newToDo.IsDone != currentToDo.IsDone)
                    currentToDo.IsDone = newToDo.IsDone;
                currentToDo.CreatedDate = DateTime.Now;
                return Ok("ToDo modified successfully.");
            }
            return NotFound($"Requested ToDo with id {id} is not found!");
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var currentToDo = toDoList.FirstOrDefault(ToDo => ToDo.Id == id);
            if (currentToDo != null)
            {
                toDoList.Remove(currentToDo);
                return Ok("ToDo deleted successfully.");
            }
            return NotFound($"Requested ToDo with id {id} is not found!");
        }
    }
}
