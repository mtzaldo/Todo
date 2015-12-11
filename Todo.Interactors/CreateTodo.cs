using System;

namespace Todo.Interactors
{
    public class CreateTodo : Boundaries.ICreateTodoRequest
    {
        Boundaries.ICreateTodoResponse _resp = null;
        EntitiesGateway.ITodoRepository _repo = null;

        public CreateTodo(
            Boundaries.ICreateTodoResponse resp,
            EntitiesGateway.ITodoRepository repo)
        {
            _repo = repo;
            _resp = resp;
        }

        public void Save(Boundaries.Models.TodoRequest req)
        {
            int id = 0;

            Entities.Todo entity = new Entities.Todo()
            {
                Description = req.Description,
                Completed = false,
                CreatedDate = DateTime.Now
            };

            if (entity.IsValid)
            {
                 id = _repo.Insert(entity);

                _resp.Response(
                    new Events.OperationResultEventArgs(
                        true, "insert", "created todo #id: " + id.ToString()));
            }
            else
            {
                throw new Exception("[insert] invalid todo item");
            }

            
        }
    }
}
