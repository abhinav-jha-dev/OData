using Microsoft.AspNetCore.Mvc;
using OData.Service.Mongo.Models;
using OData.Service.Mongo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OData.Http.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IEnumerable<Todo>> GetAll()
        {
            return await _todoService.GetAll();
        }

        [HttpPost]
        public async Task<Todo> Post(Todo todo)
        {
            if (todo == null)
                return null;

            return await _todoService.Insert(todo);
        }

        [HttpPut]
        public async Task<Todo> Put(Todo todo)
        {
            if (todo == null)
                return null;

            return await _todoService.Update(todo);
        }

        [HttpDelete]
        public async Task Delete(Guid guid)
        {
            await _todoService.Remove(guid);
        }
    }
}
