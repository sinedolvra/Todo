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
    public class UpdateTodoCommandHandlerTests : TestBase
    {
        private readonly UpdateTodoCommandHandler _handler;
        private readonly Mock<ITodoRepository> _repository;

        public UpdateTodoCommandHandlerTests()
        {
            _repository = new Mock<ITodoRepository>();
            _handler = new UpdateTodoCommandHandler(_repository.Object);
        }

        [Fact]
        public async Task Handle_GivenAValidCommand_ShouldReturnAnEquivalentResult()
        {
            var originalTodo = Fixture.Build<TodoItem>().Create();
            var validCommand = Fixture.Build<UpdateTodo>().Create();
            originalTodo.Update(validCommand);

            _repository.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(originalTodo);
            
            var result = (GenericCommandResult) await _handler.Handle(validCommand, CancellationToken.None);

            result.Success.Should().BeTrue();
            result.Payload.Should().BeEquivalentTo(originalTodo);
            result.Message.Should().BeEquivalentTo("Todo updated sucessfully!");
        }
        
        [Fact]
        public async Task Handle_GivenAValidCommand_ShouldReturnUpdateTodoAndSaveIt()
        {
            var originalTodo = Fixture.Build<TodoItem>().Create();
            var validCommand = Fixture.Build<UpdateTodo>().Create();
            originalTodo.Update(validCommand);

            _repository.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(originalTodo);
            
            var result = (GenericCommandResult) await _handler.Handle(validCommand, CancellationToken.None);

            _repository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public async Task Handle_GivenAnInValidCommand_ShouldReturnAnEquivalentResult()
        {
            var invalidCommand = Fixture.Build<UpdateTodo>().With(x => x.Title, "").Create();
            
            var result = (GenericCommandResult) await _handler.Handle(invalidCommand, CancellationToken.None);

            result.Should().BeEquivalentTo(invalidCommand.GetValidationResult());
        }
    }
}