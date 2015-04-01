using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Entities
{
    public class Todo
    {

        public int ID { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }

        public bool IsValid
        {
            get
            {
                return true;
            }
        }
    }
}
