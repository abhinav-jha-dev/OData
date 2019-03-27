using Microsoft.AspNetCore.Mvc;
using Todo.Service.Mongo.Models;
using Todo.Service.Mongo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;

namespace TodoAPI.Http.Controllers
{
    [Route("api/[controller]")]
    public class ODataAuthorController : ODataController
    {
        private readonly IAuthorService _authorService;
        public ODataAuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        // [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_authorService.GetAll().Result);
        }
    }
}
