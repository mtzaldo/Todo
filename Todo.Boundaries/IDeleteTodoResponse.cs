namespace Todo.Boundaries
{
    public interface IDeleteTodoResponse
    {
        void Response(Events.OperationResultEventArgs e);
    }
}
