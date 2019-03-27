using OData.Service.Mongo.Entity;
using OData.Service.Mongo.Models;

namespace OData.Service.Mongo.Services
{
    public interface ITodoService: IEntityMongoService<Todo>
    {
    }
}
