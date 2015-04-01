using System;

namespace Todo.Interactors.Models
{
    public class Todo : Boundaries.ITodoRequest
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
