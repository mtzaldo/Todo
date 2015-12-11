using System;

namespace Todo.Interactors
{
    public class DeleteTodo : Boundaries.IDeleteTodoRequest
    {
        Boundaries.IDeleteTodoResponse _resp = null;
        EntitiesGateway.ITodoRepository _repo = null;

        public DeleteTodo(
            Boundaries.IDeleteTodoResponse resp,
            EntitiesGateway.ITodoRepository repo)
        {
            _repo = repo;
            _resp = resp;
        }

        public void Delete(Boundaries.Models.TodoRequest req)
        {
            try
            {
                if (req.ID > 0)
                    _repo.DeleteById(req.ID);

                _resp.Response(new Events.OperationResultEventArgs(true, "delete", "deleted todo #id " + req.ID.ToString()));
            }
            catch
            {
                throw new Exception("Unable to delete the todo item");
            }
        }
    }
}
