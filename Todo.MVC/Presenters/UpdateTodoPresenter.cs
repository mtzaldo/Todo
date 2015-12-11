using System;
using Todo.Boundaries.Models;

namespace Todo.MVC.Presenters
{ 
    internal class UpdateTodoPresenter : Boundaries.IUpdateTodoResponse
    {
        public void Save(Models.Todo todo)
        {
            Boundaries.IUpdateTodoRequest boundary = 
                new Interactors.UpdateTodo(this, Repositories.TodoRepo.Instance);

            boundary.Save(new Boundaries.Models.TodoRequest()
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
