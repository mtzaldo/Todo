using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo.WebForms.Presenters
{
    public class TodoPresenter
    {

        public Models.TodoViewModel Intitialize()
        {
            Models.TodoViewModel vm = new Models.TodoViewModel();
            
            vm.FooterText = "Footer Lorem Ipsum";
            vm.HeaderText = "Header Lorem Ipsum";

            return vm;
        }

        public void CreateTodoItem(Models.Todo todo)
        {
            Interactors.CreateTodo interactor = 
                new Interactors.CreateTodo(
                    null, 
                    Repositories.TodoRepo.Instance);

            interactor.Save(todo);
        }

        public List<Boundaries.ITodoRequest> ReadTodos()
        {
            Interactors.ReadTodos interactor =
                new Interactors.ReadTodos(
                    null,
                    Repositories.TodoRepo.Instance);

            return interactor.GetItems();
        }

        public void UpdateTodo(Models.Todo todo)
        {
            Interactors.UpdateTodo interactor =
                new Interactors.UpdateTodo(
                    null,
                    Repositories.TodoRepo.Instance);

            interactor.Save(todo);
        }

        public void DeleteTodo(Models.Todo todo)
        {
            Interactors.DeleteTodo inter =
                new Interactors.DeleteTodo(
                    null,
                    Repositories.TodoRepo.Instance);

            inter.Remove(todo);
        }




    }
}
