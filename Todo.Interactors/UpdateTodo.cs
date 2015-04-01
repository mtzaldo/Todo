using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Interactors
{
    public class UpdateTodo
    {
        Boundaries.ITodoResponse _response = null;
        EntitiesGateway.ITodoRepository _repository = null;

        public UpdateTodo(
            Boundaries.ITodoResponse resp,
            EntitiesGateway.ITodoRepository repo)
        {
            _repository = repo;
            _response = resp;
        }

        public void Save(Boundaries.ITodoRequest t)
        {
            if (t.ID > 0)
                _repository.Update(
                    new Entities.Todo()
                    {
                        ID = t.ID,
                        Description = t.Description,
                        Completed = t.Completed
                    });
        }
    }
}
