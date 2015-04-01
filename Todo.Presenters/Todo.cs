using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo.Presenters
{
    public class Todo
    {
        private Boundaries.ITodo _b = null;

        public Todo(Boundaries.ITodo b)
        {
            this._b = b;
        }

        public ViewModels.TodoViewModel Intitialize()
        {
            ViewModels.TodoViewModel vm = new ViewModels.TodoViewModel();
            
            vm.FooterTest = "Footer Lorem Ipsum";
            vm.HeaderText = "Header Lorem Ipsum";

            return vm;
        }

        public void CreateTodoItem()
        {
            Interactors.CreateTodo inter = 
                new Interactors.CreateTodo(_b);

            inter.Save();
        }

        public void ReadTodos()
        {
            Interactors.ReadTodos inter =
                new Interactors.ReadTodos(_b);

            _b.TodoList = inter.GetItems();
        }

        public void UpdateTodo()
        {
            Interactors.UpdateTodo inter =
                new Interactors.UpdateTodo(_b);

            inter.Save();
        }

        public void DeleteTodo()
        {
            Interactors.DeleteTodo inter =
                new Interactors.DeleteTodo(_b);

            inter.Remove();
        }




    }
}
