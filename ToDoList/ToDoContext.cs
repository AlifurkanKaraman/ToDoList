using Microsoft.EntityFrameworkCore;

namespace ToDoList
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> ToDoItems { get; set; }
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }
    }
}
