using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Application.Interfaces.Services;

namespace TodoList.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        public readonly ITodoService _todoService;

        public TodoController(ITodoService todoService) => _todoService = todoService;

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Todo>>> Get()
        // {
            
        // }
    }
}