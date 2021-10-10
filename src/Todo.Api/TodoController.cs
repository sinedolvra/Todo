using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Repositories;
using Todo.Shared;

namespace Todo.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITodoRepository _repository;

        public TodoController(IMediator mediator, ITodoRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodo request)
        {
            try
            {
                var result = (GenericCommandResult) await _mediator.Send(request);
                if (!result.Success) return BadRequest(result);

                return CreatedAtRoute("", result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(e.Message));
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTodo(string id)
        {
            var todo = await _repository.Get(id);
            if (todo is null) return NotFound(new ErrorResponse($"No todo was found with this id {id}"));
            
            return Ok(todo);
        }
        
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _repository.GetAll();
            return Ok(todos);
        }
        
        [Route("undone")]
        [HttpGet]
        public async Task<IActionResult> GetUnDone()
        {
            var todos = await _repository.GetUnDone();
            return Ok(todos);
        }
        
        [Route("done")]
        [HttpGet]
        public async Task<IActionResult> GetDone()
        {
            var todos = await _repository.GetDone();
            return Ok(todos);
        }
    }
}