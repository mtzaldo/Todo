using System.Collections.Generic;

namespace Todo.Boundaries
{
    public interface IReadTodoResponse
    {
        void Response(Events.OperationResultEventArgs e);
    }
}