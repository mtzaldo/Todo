namespace Todo.Boundaries
{
    public interface ICreateTodoRequest
    {
        void Save(Models.TodoRequest request);
    }
}
