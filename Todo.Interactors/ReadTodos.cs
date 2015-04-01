using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo.Interactors
{
    public class ReadTodos
    {
        Boundaries.ITodoResponse _response = null;
        EntitiesGateway.ITodoRepository _repository = null;

        public ReadTodos(
            Boundaries.ITodoResponse resp,
            EntitiesGateway.ITodoRepository repo)
        {
            _repository = repo;
            _response = resp;
        }

        public List<Boundaries.ITodoRequest> GetItems()
        {
            List<Entities.Todo> items = 
                _repository.SelectAll();

            List<Boundaries.ITodoRequest> todoList = 
                new List<Boundaries.ITodoRequest>();

            Boundaries.ITodoRequest todo;

            foreach(var i in items)
            {
                todo = new Models.Todo()
                {
                    ID = i.ID,
                    Description = i.Description,
                    Completed = i.Completed
                };

                todoList.Add(todo);
            }

            return todoList;
        }
    }
}
