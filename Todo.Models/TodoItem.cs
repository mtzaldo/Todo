using System;

namespace Todo.Models
{
    public class TodoItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
