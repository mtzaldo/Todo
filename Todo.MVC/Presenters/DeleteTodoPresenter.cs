namespace Todo.MVC.Presenters
{
    public class DeleteTodoPresenter : Boundaries.IDeleteTodoResponse
    {

        public void DeleteTodo(Models.Todo todo)
        {
            Boundaries.IDeleteTodoRequest boundary =
                new Interactors.DeleteTodo(this, Repositories.TodoRepo.Instance);

            boundary.Delete(new Boundaries.Models.TodoRequest()
            {
                ID = todo.ID,
                Description = todo.Description,
                Completed = todo.Completed
            });

        }

        public void Response(Events.OperationResultEventArgs e)
        {
            if (e.Success)
            {

            }
        }
    }
}
