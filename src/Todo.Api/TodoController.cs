using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;

namespace Todo.Api
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
            var result = (GenericCommandResult) await _mediator.Send(request);
            if (!result.Success) return BadRequest(result.Message);

            return OkObjectResult(result);
        }
    }
}