using Microsoft.AspNetCore.Mvc;
using Todo.Service.Mongo.Models;
using Todo.Service.Mongo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Todo.Service.Mongo.Utilities.Enums;

namespace TodoAPI.Http.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorService.GetAll();
        }

        [HttpGet]
        [Route("dummy/{recordCount}")]
        public async Task<IEnumerable<Author>> InsertDummy(int recordCount)
        {
            if (recordCount < 500000)
            {
                List<Author> authors = new List<Author>();
                for (int i = 0; i < recordCount; i++)
                {
                    Author newAuthor = new Author
                    {
                        Name = RandomString(10, false),
                        Description = RandomString(50, false),
                        Tasks = GetTasks(RandomNumber(0, 10))
                    };

                    await _authorService.Insert(newAuthor);
                }
            }
            return await _authorService.GetAll();
        }

        [HttpPost]
        public async Task<Author> Post([FromBody] Author Author)
        {
            if (Author == null)
                return null;

            return await _authorService.Insert(Author);
        }

        [HttpPut]
        public async Task<Author> Put(Author Author)
        {
            if (Author == null)
                return null;

            return await _authorService.Update(Author);
        }

        [HttpDelete]
        public async Task Delete(Guid guid)
        {
            await _authorService.Remove(guid);
        }

        private List<TodoTask> GetTasks(int recordCount)
        {
            List<TodoTask> todoTasks = new List<TodoTask>();
            for (int i = 0; i < recordCount; i++)
            {
                todoTasks.Add(new TodoTask
                {
                    Title = RandomString(10, false),
                    Description = RandomString(50, false),
                    Tags = new List<string> { RandomString(5, false), RandomString(5, false) },
                    Status = RandomEnumValue<TaskPriority>(),
                    Color = RandomEnumValue<TaskColor>()
                });
            }
            return todoTasks;
        }
        // Generate a random number between two numbers    
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size    
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        // Fetch Random Enum Value
        private static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }
    }
}
