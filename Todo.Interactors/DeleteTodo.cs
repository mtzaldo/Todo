using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo.Interactors
{
    public class DeleteTodo
    {
        Boundaries.ITodoResponse _response = null;
        EntitiesGateway.ITodoRepository _repository = null;

        public DeleteTodo(
            Boundaries.ITodoResponse resp,
            EntitiesGateway.ITodoRepository repo)
        {
            _repository = repo;
            _response = resp;
        }

        public bool Remove(Boundaries.ITodoRequest todo)
        {
            try
            {
                if (todo.ID > 0)
                    _repository.DeleteById(todo.ID);
            }
            catch
            {
                throw new Exception("Unable to remote the todo item");
            }

            return true;
        }
    }
}
