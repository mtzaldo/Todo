namespace Todo.Boundaries
{
    public interface ICreateTodoResponse
    {
        void Response(Events.OperationResultEventArgs e);
    }
}
