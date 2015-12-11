namespace Todo.Boundaries.Models
{
    public class TodoResponse
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
