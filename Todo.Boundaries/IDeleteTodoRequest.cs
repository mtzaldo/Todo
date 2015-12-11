namespace Todo.Boundaries
{
    public interface IDeleteTodoRequest
    {
        void Delete(Boundaries.Models.TodoRequest req);
    }
}
