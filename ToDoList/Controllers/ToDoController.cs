using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

            return NotFound($"Requested ToDo with id {id} is not on the list");
        }

        // POST api/<ToDoController>
        [HttpPost]
        public IActionResult Post([FromBody] ToDo newToDo)
        {
            if (string.IsNullOrWhiteSpace(newToDo.Title))
            {
                return BadRequest("Title is required.");
            }

            toDoList.Add(newToDo);
            return Ok("ToDo added successfully.");

        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
