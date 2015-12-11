using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo.MVC.Models
{
    public class TodoViewModel
    {
        public string Message { get; set; }
        public string HeaderText { get; set; }
        public string FooterText { get; set; }

        public IEnumerable<Models.Todo> TodoList { get; set; }

        public Models.Todo TodoItem { get; set; }

    }
}