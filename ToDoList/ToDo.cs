﻿namespace ToDoList
{
    public class ToDo
    {
        public int Id { get; private set; }
        private static int _counter = 1;
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDone { get; set; } = false;
        public ToDo(string title, string description = "No description provided")
        {
            Id = _counter++;
            Title = title;
            Description = description;
        }
    }
}
