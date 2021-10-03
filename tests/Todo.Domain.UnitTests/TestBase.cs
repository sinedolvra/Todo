using AutoFixture;

namespace Todo.Domain.UnitTests
{
    public class TestBase
    {
        protected readonly Fixture Fixture = new ();
    }
}