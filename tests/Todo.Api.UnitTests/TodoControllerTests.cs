using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Xunit;

namespace Todo.Api.UnitTests
{
    public class TodoControllerTests : TestBase
    {
        private readonly TodoController _controller;

        public TodoControllerTests()
        {
            _controller = new TodoController(Mediator.Object);
        }

        [Fact]
        public async Task CreateTodo_GivenAnInvalidRequest_ShouldReturnBadRequest()
        {
            var invalidRequest = Fixture.Create<CreateTodo>();

            var commandResult = new GenericCommandResult(false, new object(), new object());
            Mediator.Setup(x => x.Send(It.IsAny<Command>(), CancellationToken.None)).ReturnsAsync(commandResult);
            
            var result = await _controller.CreateTodo(invalidRequest);

            result.Should().BeOfType(typeof(BadRequestObjectResult));
        }
        
        [Fact]
        public async Task CreateTodo_GivenAValidRequest_ShouldReturnOk()
        {
            var request = Fixture.Create<CreateTodo>();

            var commandResult = new GenericCommandResult(true, new object(), new object());
            Mediator.Setup(x => x.Send(It.IsAny<Command>(), CancellationToken.None)).ReturnsAsync(commandResult);
            
            var result = await _controller.CreateTodo(request);

            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async Task CreateTodo_GivenAnException_ShouldReturns500()
        {
            var request = Fixture.Create<CreateTodo>();

            var result = (ObjectResult) await _controller.CreateTodo(request);

            result.Should().BeOfType(typeof(ObjectResult));
            result.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }
    }
}