using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo.Repositories
{
    public class TodoRepo : EntitiesGateway.ITodoRepository
    {
        static TodoRepo _db = new TodoRepo();

        public static TodoRepo Instance
        {
            get { return _db; }
        }

        List<Entities.Todo> _items = null;

        List<Entities.Todo> TodoList
        {
            get
            {
                if (_items == null)
                {
                    _items = new List<Entities.Todo>();
                    _items.Add(new Entities.Todo()
                    {
                        ID = 1,
                        Completed = true,
                        Description = "Buy milk",
                        CompletedDate = DateTime.Now
                    });
                    _items.Add(new Entities.Todo()
                    {
                        ID = 2,
                        Description = "Watch a random movie"
                    });
                    _items.Add(new Entities.Todo()
                    {
                        ID = 3,
                        Description = "Walk the dog"
                    });
                }

                return _items;
            }
        }

        public List<Entities.Todo> SelectAll()
        {
            return this.TodoList;
        }

        public Entities.Todo SelectById(int id)
        {
            return this.TodoList.Single(item => item.ID == id);
        }

        public int Insert(Entities.Todo item)
        {
            int id = 0;

            if (this.TodoList.Count > 0)
                id = this.TodoList.Max(i => i.ID);

            item.ID = ++id;

            this.TodoList.Add(item);

            return id;
        }

        public void Update(Entities.Todo item)
        {
            Entities.Todo todoItem = TodoList.Single(i => i.ID == item.ID);
            int index = TodoList.IndexOf(todoItem);

            if (index >= 0)
            {
                this.TodoList[index].Completed = item.Completed;
                this.TodoList[index].Description = item.Description;
            }

        }

        public void DeleteById(int id)
        {
            Entities.Todo todoItem = this.TodoList.Single(i => i.ID == id);
            this.TodoList.Remove(todoItem);
        }

        public List<Entities.Todo> SelectTop(int n)
        {
            if (this.TodoList.Count >= n)
               return this.TodoList.Take(n).ToList();

            return this.TodoList;
        }
    }
}
