using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Xunit;

namespace Todo.Domain.UnitTests.QueryTests
{
    public class TodoQueriesTests : TestBase
    {
        private readonly List<TodoItem> _unDoneTodos;
        private readonly List<TodoItem> _doneTodos;
        private readonly List<TodoItem> _todos;

        public TodoQueriesTests()
        {
            _unDoneTodos = Fixture.Build<TodoItem>()
                .With(x => x.Done, false)
                .CreateMany().ToList();
            _doneTodos = Fixture.Build<TodoItem>()
                .With(x => x.Done, true)
                .CreateMany().ToList();
            _todos = new List<TodoItem>();
            _todos.AddRange(_unDoneTodos);
            _todos.AddRange(_doneTodos);
        }
        
        [Fact]
        public void GetUnDone_GivenACall_ShouldReturnAllThatAreUnDone()
        {
            var todos = _todos.Where(TodoQueries.GetUnDone().Compile()).ToList();
            todos.Should().BeEquivalentTo(_unDoneTodos);
            todos.Should().HaveSameCount(_unDoneTodos);
        }
        
        [Fact]
        public void GetDone_GivenACall_ShouldReturnAllThatAreDone()
        {
            var todos = _todos.Where(TodoQueries.GetDone().Compile()).ToList();
            todos.Should().BeEquivalentTo(_doneTodos);
            todos.Should().HaveSameCount(_doneTodos);
        }
        
        [Fact]
        public void GetAll_GivenACall_ShouldReturnAll()
        {
            var todos = _todos.Where(TodoQueries.GetAll().Compile()).ToList();
            todos.Should().BeEquivalentTo(_todos);
            todos.Should().HaveSameCount(_todos);
        }
    }
}