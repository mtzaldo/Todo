using System;
using System.Collections.Generic;

namespace Todo.EntitiesGateway
{
    public interface ITodoRepository
    {
        List<Entities.Todo> SelectAll();
        List<Entities.Todo> SelectTop(int n);
        Entities.Todo SelectById(int id);
        int Insert(Entities.Todo item);
        void Update(Entities.Todo item);
        void DeleteById(int id);
    }
}
