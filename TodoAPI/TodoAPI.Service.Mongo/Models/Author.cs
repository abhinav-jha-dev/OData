using OData.Service.Mongo.Entity;
using OData.Service.Mongo.Utilities.Enums;
using System;
using System.Collections.Generic;

namespace OData.Service.Mongo.Models
{
    public class Author : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }

        public IList<TodoTask> Tasks { get; set; }
    }
}
