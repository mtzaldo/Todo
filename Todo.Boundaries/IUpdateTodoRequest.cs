namespace Todo.Boundaries
{
    public interface IUpdateTodoRequest
    {
        void Save(Models.TodoRequest req);
    }
}
