using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using Todo.Domain.CommandHandlers;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Xunit;

namespace Todo.Domain.UnitTests.CommandHandlers
{
    public class CreateTodoCommandHandlerTests : TestBase
    {
        private readonly CreateTodoCommandHandler _handler;
        private readonly Mock<ITodoRepository> _repository;

        public CreateTodoCommandHandlerTests()
        {
            _repository = new Mock<ITodoRepository>();
            _handler = new CreateTodoCommandHandler(_repository.Object);
        }

        [Fact]
        public async Task Handle_GivenAValidCommand_ShouldReturnAnEquivalentResult()
        {
            var validCommand = Fixture.Build<CreateTodo>().With(x => x.CreationDate, DateTime.UtcNow).Create();
            var expectedTodoItem = validCommand.ToTodo();
            _repository.Setup(x => x.Add(It.IsAny<TodoItem>())).ReturnsAsync(expectedTodoItem);
            
            var result = (GenericCommandResult) await _handler.Handle(validCommand, CancellationToken.None);

            result.Success.Should().BeTrue();
            result.Payload.Should().BeEquivalentTo(expectedTodoItem);
            result.Message.Should().BeEquivalentTo("Todo created sucessfully!");
        }

        [Fact]
        public async Task Handle_GivenAnInValidCommand_ShouldReturnAnEquivalentResult()
        {
            var invalidCommand = Fixture.Build<CreateTodo>().With(x => x.Title, "").Create();
            
            var result = (GenericCommandResult) await _handler.Handle(invalidCommand, CancellationToken.None);

            result.Should().BeEquivalentTo(invalidCommand.GetValidationResult());
        }
    }
}