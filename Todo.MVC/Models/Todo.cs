﻿using System.ComponentModel.DataAnnotations;

namespace Todo.MVC.Models
{
    public class Todo
    {
        public int ID { get; set; }

        [Required]
        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
