using System;
using System.Collections.Generic;

namespace Todo.Interactors
{
    public class CreateTodo
    {
        Boundaries.ITodoResponse _response = null;
        EntitiesGateway.ITodoRepository _repository = null;

        public CreateTodo(
            Boundaries.ITodoResponse resp,
            EntitiesGateway.ITodoRepository repo)
        {
            _repository = repo;
            _response = resp;
        }

        public int Save(Boundaries.ITodoRequest todo)
        {
            int id = 0;

            Entities.Todo entity = new Entities.Todo()
            {
                Description = todo.Description,
                Completed = false,
                CreatedDate = DateTime.Now
            };

            if (entity.IsValid)
            {
                 id = _repository.Insert(entity);
            }
            else
                throw new Exception("Todo Entity is invalid.");

            return id;
        }
    }
}
