namespace Todo.Interactors
{
    public class UpdateTodo : Boundaries.IUpdateTodoRequest
    {
        Boundaries.IUpdateTodoResponse _response = null;
        EntitiesGateway.ITodoRepository _repository = null;

        public UpdateTodo(
            Boundaries.IUpdateTodoResponse resp,
            EntitiesGateway.ITodoRepository repo)
        {
            _repository = repo;
            _response = resp;
        }

        public void Save(Boundaries.Models.TodoRequest req)
        {
            Entities.Todo entity = new Entities.Todo()
            {
                ID = req.ID,
                Description = req.Description,
                Completed = req.Completed
            };

            if (entity.ID > 0 && entity.IsValid)
            {
                _repository.Update(entity);
            }
            else
            {
                throw new System.Exception("[update] invalid todo item.");
            }
                
        }
    }
}
