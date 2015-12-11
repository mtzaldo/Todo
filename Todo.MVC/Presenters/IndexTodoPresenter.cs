using System.Collections.Generic;
using System.Linq;
using Todo.Boundaries.Models;

namespace Todo.MVC.Presenters
{
    internal class IndexTodoPresenter : Boundaries.IReadTodoResponse
    {
        public Models.TodoViewModel Init()
        {
            Models.TodoViewModel vm = new Models.TodoViewModel();

            vm.HeaderText = "Lorem ipsum header";
            vm.FooterText = "Lorem ipsum footer";

            vm.TodoList = ReadTodos();

            vm.TodoItem = new Models.Todo();

            return vm;
        }
  
        public IEnumerable<Models.Todo> ReadTodos()
        {
            Boundaries.IReadTodoRequest boundary =
                new Interactors.ReadTodos(this, Repositories.TodoRepo.Instance);

            IEnumerable<TodoResponse> todoReqs =  boundary.Read(null);

            IEnumerable<Models.Todo> todoList = todoReqs.Select(t => new Models.Todo()
                                                {
                                                    ID = t.ID,
                                                    Description = t.Description,
                                                    Completed = t.Completed
                                                }).ToList();

            return todoList;

        }

        public void Response(Events.OperationResultEventArgs e)
        {
            if (e.Success)
            {
                //log yeah!
            }
        }
    }
}
