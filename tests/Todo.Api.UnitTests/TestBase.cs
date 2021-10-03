using AutoFixture;
using MediatR;
using Moq;

namespace Todo.Api.UnitTests
{
    public class TestBase
    {
        protected readonly Fixture Fixture = new ();
        public readonly Mock<IMediator> Mediator = new();
    }
}