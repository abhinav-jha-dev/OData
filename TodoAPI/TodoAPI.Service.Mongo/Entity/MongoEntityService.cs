namespace Todo.Service.Mongo.Entity
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MongoEntityService<T> : IEntityMongoService<T> where T: IBaseEntity
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<T> _collection;

        public MongoEntityService(string connectionString, string databaseName)
        {
            this._client = new MongoClient(connectionString);
            this._database = _client.GetDatabase(databaseName);
            this._collection = _database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<T> Get(Guid objectId)
        {
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            var list = await this._collection.FindAsync(filter);
            return list.SingleOrDefault();
        }

        public async Task<IEnumerable<T>> Get(FilterDefinition<T> filters)
        {
            var list = await this._collection.FindAsync(filters);
            return list.ToList();
        }

        public async Task<IEnumerable<T>> Get(FilterDefinition<T> filters, FindOptions<T> options)
        {
            var list = await this._collection.FindAsync(filters, options);
            return list.ToList();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var filter = Builders<T>.Filter.Empty;
            var list = await this._collection.FindAsync(filter);
            return list.ToList();
        }

        /// <summary>
        /// Guid needs to be generated before calling insert.
        /// </summary>
        /// <param name="entityObject"></param>
        /// <returns></returns>
        public async Task<T> Insert(T entityObject)
        {
            await this._collection.InsertOneAsync(entityObject);
            return entityObject;
        }

        public async Task<DeleteResult> Remove(Guid objectId)
        {
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            var list = await this._collection.DeleteOneAsync(filter);
            return list;
        }

        [Obsolete]
        public async Task<long> Count()
        {
            var filter = Builders<T>.Filter.Empty;
            var count = await this._collection.CountAsync(filter);
            return count;
        }

        public void RemoveCollection()
        {
            this._database.DropCollection(typeof(T).FullName);
        }

        public async Task<T> Update(T entityObject)
        {
            var filter = Builders<T>.Filter.And(
                Builders<T>.Filter.Eq("_id", entityObject.Id));

            // Concurrency check
            var previousInstance = await this._collection.FindOneAndReplaceAsync(filter, entityObject);
            if (previousInstance == null)
            {
                throw new Exception();
            }
            return entityObject;
        }

        public async Task<T> Upsert(T entityObject)
        {
            await this._collection.ReplaceOneAsync(doc => doc.Id.Equals(entityObject.Id), entityObject,
                new UpdateOptions { IsUpsert = true });
            return entityObject;
        }
    }
}
