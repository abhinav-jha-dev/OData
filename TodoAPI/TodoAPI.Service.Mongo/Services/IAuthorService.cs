using Todo.Service.Mongo.Entity;
using Todo.Service.Mongo.Models;

namespace Todo.Service.Mongo.Services
{
    public interface IAuthorService: IEntityMongoService<Author>
    {
    }
}