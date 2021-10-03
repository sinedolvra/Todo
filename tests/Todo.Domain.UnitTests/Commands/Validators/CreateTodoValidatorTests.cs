using System;
using AutoFixture;
using FluentAssertions;
using FluentValidation.TestHelper;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Validators;
using Xunit;

namespace Todo.Domain.UnitTests.Commands.Validators
{
    public class CreateTodoValidatorTests : TestBase
    {
        private readonly CreateTodoValidator Validator = new ();

        [Fact]
        public void GivenAValidCreateTodo_ShouldShouldNotHaveAnyValidationErrors()
        {
            var createTodo = Fixture.Build<CreateTodo>()
                .With(x => x.CreationDate, DateTime.UtcNow)
                .Create();
            
            var result = Validator.TestValidate(createTodo);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void GivenACommandWithoutTitle_ShouldShouldHaveValidationErrorForTitle()
        {
            var createTodo = Fixture.Build<CreateTodo>()
                .With(x => x.Title, "")
                .Create();
            
            var result = Validator.TestValidate(createTodo);
            result.ShouldHaveValidationErrorFor(x => x.Title);
        }
        
        [Fact]
        public void GivenACommandWithInvalidCreationDate_ShouldShouldHaveValidationErrorForCreationDate()
        {
            var createTodo = Fixture.Build<CreateTodo>()
                .With(x => x.CreationDate, default(DateTime))
                .Create();
            
            var result = Validator.TestValidate(createTodo);
            result.ShouldHaveValidationErrorFor(x => x.CreationDate);
        }
    }
}