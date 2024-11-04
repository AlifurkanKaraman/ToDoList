using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return _context.ToDoItems.ToList();
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public ActionResult<ToDo> Get(int id)
        {
            var currentToDo = _context.ToDoItems.Find(id);
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
            _context.ToDoItems.Add(new ToDo(newToDoDto.Title, newToDoDto.Description));
            _context.SaveChanges();
            return Ok("ToDo added successfully.");
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public ActionResult<ToDo> Put(int id, [FromBody] ToDo updatedToDo)
        {
            var currentToDo = _context.ToDoItems.Find(id);
            if (currentToDo != null)
            {
                currentToDo.Title = updatedToDo.Title ?? currentToDo.Title;
                currentToDo.Description = updatedToDo.Description ?? currentToDo.Description;
                currentToDo.IsDone = updatedToDo.IsDone;
                currentToDo.CreatedDate = DateTime.Now;
                _context.SaveChanges();

                return Ok("ToDo modified successfully.");
            }
            return NotFound($"Requested ToDo with id {id} is not found!");
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var currentToDo = _context.ToDoItems.Find(id);
            if (currentToDo != null)
            {
                _context.ToDoItems.Remove(currentToDo);
                _context.SaveChanges();
                return Ok("ToDo deleted successfully.");
            }
            return NotFound($"Requested ToDo with id {id} is not found!");
        }
    }
}
