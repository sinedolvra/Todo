using AutoFixture;
using FluentAssertions;
using Todo.Domain.Commands.Contracts;
using Xunit;

namespace Todo.Domain.UnitTests.Commands.Contracts
{
    public class GenericCommandResultTests : TestBase
    {
        [Fact]
        public void Construct_GivenAValidParameters_ShouldConstructAValidCommandResult()
        {
            var success = Fixture.Create<bool>();
            var message = Fixture.Create<string>();
            var command = Fixture.Create<object>();

            var result = new GenericCommandResult(success, message, command);

            result.Success.Should().Be(success);
            result.Message.Should().BeEquivalentTo(message);
            result.Payload.Should().BeEquivalentTo(command);
        }
    }
}