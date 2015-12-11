namespace Todo.MVC.Presenters
{
    internal class CreateTodoPresenter : Boundaries.ICreateTodoResponse
    {
        public void CreateTodoItem(Models.Todo todo)
        {
            Boundaries.ICreateTodoRequest boundary =
                new Interactors.CreateTodo(
                    this,
                    Repositories.TodoRepo.Instance
                    );

            Boundaries.Models.TodoRequest req = 
                new Boundaries.Models.TodoRequest()
            {
                ID = todo.ID,
                Description = todo.Description,
                Completed = todo.Completed
            };

            boundary.Save(req);

        }

        public void Response(Events.OperationResultEventArgs e)
        {
            if (e.Success)
            {

            }
        }
    }
}
