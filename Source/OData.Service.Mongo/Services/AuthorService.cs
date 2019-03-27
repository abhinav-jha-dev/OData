using OData.Service.Mongo.Entity;
using OData.Service.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OData.Service.Mongo.Services
{
    public class AuthorService : MongoEntityService<Todo>, IAuthorService
    {
        public AuthorService(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }
    }
}
