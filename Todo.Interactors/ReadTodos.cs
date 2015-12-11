using System.Collections.Generic;
using System.Linq;
using Todo.Boundaries.Models;

namespace Todo.Interactors
{
    public class ReadTodos : Boundaries.IReadTodoRequest
    {
        Boundaries.IReadTodoResponse _response = null;
        EntitiesGateway.ITodoRepository _repository = null;

        public ReadTodos(
            Boundaries.IReadTodoResponse resp,
            EntitiesGateway.ITodoRepository repo)
        {
            _repository = repo;
            _response = resp;
        }

        public IEnumerable<Boundaries.Models.TodoResponse> Read(TodoRequest req)
        {
            List<Entities.Todo> items = 
                _repository.SelectAll();

            List<Boundaries.Models.TodoResponse> todoResp =
                items.Select(t => new Boundaries.Models.TodoResponse() {
                    ID = t.ID,
                    Description = t.Description,
                    Completed = t.Completed
                }).ToList();

            _response.Response(new Events.OperationResultEventArgs(true, "read", "read a lot of todos"));

            return todoResp;

        }
    }
}
