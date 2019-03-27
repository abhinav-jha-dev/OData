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

        [HttpPost]
        public async Task<Author> Post(Author Author)
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
    }
}
