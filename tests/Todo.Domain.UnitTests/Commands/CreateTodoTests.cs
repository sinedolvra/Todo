using System;
using AutoFixture;
using FluentAssertions;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Xunit;

namespace Todo.Domain.UnitTests.Commands
{
    public class CreateTodoTests : TestBase
    {
        [Fact]
        public void Construct_GivenAValidParameters_ShouldConstructAValidCommand()
        {
            var title = Fixture.Create<string>();
            var description = Fixture.Create<string>();
            var done = Fixture.Create<bool>();

            var result = new CreateTodo(title, description, done);

            result.Title.Should().BeEquivalentTo(title);
            result.Description.Should().BeEquivalentTo(description);
            result.Done.Should().Be(done);
            result.CreationDate.Date.Should().BeSameDateAs(DateTime.UtcNow.Date);
        }

        [Fact]
        public void Validate_GivenAValidCreateTodoCommand_ShouldReturnATrueValidationResult()
        {
            var validCommand = Fixture.Build<CreateTodo>()
                .With(x => x.CreationDate, DateTime.UtcNow)
                .Create();
            
            validCommand.Validate();

            validCommand.GetValidationResult().Success.Should().BeTrue();
        }

        [Fact]
        public void Validate_GivenAnInValidCreateTodoCommand_ShouldReturnAFalseValidationResult()
        {
            var validCommand = Fixture.Build<CreateTodo>()
                .With(x => x.Title, "")
                .Create();
            
            validCommand.Validate();

            validCommand.GetValidationResult().Success.Should().BeFalse();
        }

        [Fact]
        public void ToTodo_GivenAValidCommand_ShouldReturnATodoItem()
        {
            var command = Fixture.Create<CreateTodo>();
            var result = command.ToTodo();

            result.Should().BeOfType<TodoItem>();
            result.Title.Should().BeEquivalentTo(command.Title);
            result.Description.Should().BeEquivalentTo(command.Description);
            result.Done.Should().Be(command.Done);
            result.CreationDate.Should().BeSameDateAs(command.CreationDate);
        }
    }
}