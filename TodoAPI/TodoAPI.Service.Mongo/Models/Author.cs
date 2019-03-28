using Todo.Service.Mongo.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Todo.Service.Mongo.Models
{
    public class Author : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string Description { get; set; }

        public IList<TodoTask> Tasks { get; set; }
    }
}
