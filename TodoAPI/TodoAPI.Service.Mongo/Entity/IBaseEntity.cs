using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Service.Mongo.Entity
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}
