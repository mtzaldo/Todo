using System.Collections.Generic;

namespace Todo.Boundaries
{
    public interface IReadTodoRequest
    {
        IEnumerable<Models.TodoResponse> Read(Models.TodoRequest req);
    }
}
