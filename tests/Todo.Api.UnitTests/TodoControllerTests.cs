using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Todo.Api.Controllers;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Xunit;

namespace Todo.Api.UnitTests
{
    public class TodoControllerTests : TestBase
    {
        private readonly TodoController _controller;
        private readonly Mock<ITodoRepository> _repository;

        public TodoControllerTests()
        {
            _controller = new TodoController(Mediator.Object);
            _repository = new Mock<ITodoRepository>();
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

            result.Should().BeOfType(typeof(CreatedAtRouteResult));
        }

        [Fact]
        public async Task CreateTodo_GivenAnException_ShouldReturns500()
        {
            var request = Fixture.Create<CreateTodo>();

            var result = (ObjectResult) await _controller.CreateTodo(request);

            result.Should().BeOfType(typeof(ObjectResult));
            result.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }

        [Fact]
        public async Task GetTodo_GivenANotFoundTodo_ReturnANotFoundResponse()
        {
            var result = await _controller.GetTodo(Fixture.Create<string>(), _repository.Object);
            result.Should().BeOfType<NotFoundObjectResult>();
        }
        
        [Fact]
        public async Task GetTodo_GivenAValidReturnedTodo_ReturnAOkResponse()
        {
            var validTodo = Fixture.Create<TodoItem>();
            _repository.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(validTodo);
            var result = await _controller.GetTodo(Fixture.Create<string>(), _repository.Object);
            result.Should().BeOfType<OkObjectResult>();
        }
        
        [Fact]
        public async Task GetAll_GivenAValidReturnedTodo_ReturnAOkResponse()
        {
            var validTodos = Fixture.CreateMany<TodoItem>().ToList();
            _repository.Setup(x => x.GetAll()).ReturnsAsync(validTodos);
            var result = await _controller.GetAll(_repository.Object);
            result.Should().BeOfType<OkObjectResult>();
        }
        
        [Fact]
        public async Task GetAll_GivenAEmptyReturnedList_ReturnAOkResponseWithEmptyList()
        {
            var result = await _controller.GetAll(_repository.Object);
            result.Should().BeOfType<OkObjectResult>();
        }
        
        [Fact]
        public async Task GetUnDone_GivenAValidReturnedTodo_ReturnAOkResponse()
        {
            var validTodos = Fixture.Build<TodoItem>().With(x => x.Done, false).CreateMany().ToList();
            _repository.Setup(x => x.GetAll()).ReturnsAsync(validTodos);
            var result = await _controller.GetUnDone(_repository.Object);
            result.Should().BeOfType<OkObjectResult>();
        }
        
        [Fact]
        public async Task GetDone_GivenAValidReturnedTodo_ReturnAOkResponse()
        {
            var validTodos = Fixture.Build<TodoItem>().With(x => x.Done, true).CreateMany().ToList();
            _repository.Setup(x => x.GetAll()).ReturnsAsync(validTodos);
            var result = await _controller.GetDone(_repository.Object);
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}