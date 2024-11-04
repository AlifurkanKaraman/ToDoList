namespace ToDoList
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDone { get; set; } = false;
        public ToDo() {}
        public ToDo(string title, string description = "No description provided")
        {
            Title = title;
            Description = description;
        }
    }
}
