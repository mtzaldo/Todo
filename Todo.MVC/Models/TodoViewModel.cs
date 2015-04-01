using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo.MVC.Models
{
    public class TodoViewModel
    {
        public string HeaderText { get; set; }
        public string FooterText { get; set; }

        public List<Boundaries.ITodoRequest> TodoList { get; set; }

        public Boundaries.ITodoRequest TodoItem { get; set; }

    }
}