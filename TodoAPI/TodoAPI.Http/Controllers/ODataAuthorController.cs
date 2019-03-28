using Microsoft.AspNetCore.Mvc;
using Todo.Service.Mongo.Models;
using Todo.Service.Mongo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Query;

namespace TodoAPI.Http.Controllers
{
    [ODataRoutePrefix("Author")]
    public class ODataAuthorController : ODataController
    {
        private readonly IAuthorService _authorService;
        public ODataAuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [ODataRoute]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_authorService.GetAll().Result);
        }
    }
}
