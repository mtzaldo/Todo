namespace Todo.Boundaries
{
    public interface IUpdateTodoResponse
    {
        void Response(Events.OperationResultEventArgs e);
    }
}