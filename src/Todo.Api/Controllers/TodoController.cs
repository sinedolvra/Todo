using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Repositories;
using Todo.Shared;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<IActionResult> GetTodo(string id, [FromServices] ITodoRepository repository)
        {
            var todo = await repository.Get(id);
            if (todo is null) return NotFound(new ErrorResponse($"No todo was found with this id {id}"));
            
            return Ok(todo);
        }
        
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] ITodoRepository repository)
        {
            var todos = await repository.GetAll();
            return Ok(todos);
        }
        
        [Route("undone")]
        [HttpGet]
        public async Task<IActionResult> GetUnDone([FromServices] ITodoRepository repository)
        {
            var todos = await repository.GetUnDone();
            return Ok(todos);
        }
        
        [Route("done")]
        [HttpGet]
        public async Task<IActionResult> GetDone([FromServices] ITodoRepository repository)
        {
            var todos = await repository.GetDone();
            return Ok(todos);
        }

        [Route("")]
        [HttpPatch]
        public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodo request,[FromServices] ITodoRepository repository)
        {
            try
            {
                var result = (GenericCommandResult) await _mediator.Send(request);
                if (!result.Success) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(e.Message));
            }
        }
    }
}