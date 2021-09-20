using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Application.DTOs.Todo;
using TodoList.Core.Application.Interfaces.Services;
using TodoList.Core.Application.Wrappers;
using TodoList.Core.Domain.Entities;

namespace TodoList.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodoController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<Todo>>>> Get()
        {
            var todos = await _todoService.GetAllAsync();
            return Ok(new Response<IEnumerable<Todo>>(todos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Todo>>> Get(int id)
        {
            var todo = await _todoService.GetByIdAsync(id);
            return Ok(new Response<Todo>(todo));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoRequest request)
        {
            int id = await _todoService.AddAsync(_mapper.Map<Todo>(request));
            var todo = await _todoService.GetByIdAsync(id);
            return Created($"/api/Todo/{id}", new Response<Todo>(todo));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TodoRequest request)
        {
            var todo = _mapper.Map<Todo>(request);
            todo.Id = id;
            await _todoService.UpdateAsync(todo);
            return Ok();
        }
    }
}