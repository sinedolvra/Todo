using System.Linq;
using AutoFixture;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace Todo.Shared.UnitTests
{
    public class ListExtensionsUnitTests : TestBase
    {
        [Fact]
        public void Construct_GivenAValidList_ShouldReturnAnEquivalentErrorResponse()
        {
            var validationFailures = Fixture.CreateMany<ValidationFailure>().ToList();

            var result = validationFailures.GetErrorsValidation();
            result.Errors.Should().HaveCount(validationFailures.Count);
        }
    }
}