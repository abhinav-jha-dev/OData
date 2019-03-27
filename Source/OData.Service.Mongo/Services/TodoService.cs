using OData.Service.Mongo.Entity;
using OData.Service.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OData.Service.Mongo.Services
{
    public class TodoService : MongoEntityService<Todo>, ITodoService
    {
        public TodoService(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }
    }
}
