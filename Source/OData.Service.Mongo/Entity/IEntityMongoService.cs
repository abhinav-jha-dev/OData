namespace OData.Service.Mongo.Entity
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEntityMongoService<T> where T : IBaseEntity
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(Guid objectId);

        Task<IEnumerable<T>> Get(FilterDefinition<T> filters);

        Task<IEnumerable<T>> Get(FilterDefinition<T> filters, FindOptions<T> options);

        Task<T> Insert(T entityObject);

        Task<T> Update(T entityObject);

        Task<T> Upsert(T entityObject);

        Task<DeleteResult> Remove(Guid objectId);

        Task<long> Count();

        void RemoveCollection();
    }
}
