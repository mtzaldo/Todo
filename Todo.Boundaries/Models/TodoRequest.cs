namespace Todo.Boundaries.Models
{
    public class TodoRequest
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
