using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Boundaries
{
    public interface ITodoRequest
    {
        int ID { get; set; }
        string Description { get; }
        bool Completed { get; }
    }
}
