using Todo.Service.Mongo.Entity;
using Todo.Service.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Service.Mongo.Services
{
    public class AuthorService : MongoEntityService<Author>, IAuthorService
    {
        public AuthorService(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }
    }
}
