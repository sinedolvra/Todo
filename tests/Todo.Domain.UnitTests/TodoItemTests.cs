using System;
using AutoFixture;
using FluentAssertions;
using Todo.Domain.Entities;
using Xunit;

namespace Todo.Domain.UnitTests
{
    public class TodoItemTests : TestBase
    {
        [Fact]
        public void Construct_GivenAValidParameters_ShouldCreateAValidTodoItem()
        {
            var title = Fixture.Create<string>();
            var description = Fixture.Create<string>();
            var creationDate = Fixture.Create<DateTime>();
            var done = Fixture.Create<bool>();

            var result = new TodoItem(title, description, creationDate, done);

            result.Title.Should().BeEquivalentTo(title);
            result.Description.Should().BeEquivalentTo(description);
            result.CreationDate.Should().BeSameDateAs(creationDate);
            result.Done.Should().Be(done);
            result.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void MarkAsDone_GivenACall_ShouldReturnDoneAsTrue()
        {
            var todo = Fixture.Create<TodoItem>();
            todo.MarkAsDone();

            todo.Done.Should().BeTrue();
        }

        [Fact]
        public void MarkAsUnDone_GivenACall_ShouldReturnDoneAsFalse()
        {
            
            var todo = Fixture.Create<TodoItem>();
            todo.MarkAsUnDone();

            todo.Done.Should().BeFalse();
        }
    }
}