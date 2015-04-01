using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo.WebForms.Models
{
    public class Todo : Boundaries.ITodoRequest
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}