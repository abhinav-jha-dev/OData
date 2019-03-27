using System;
using System.Collections.Generic;
using System.Text;

namespace OData.Service.Mongo.Entity
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}
