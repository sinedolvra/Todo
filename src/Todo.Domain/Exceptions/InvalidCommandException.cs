using System;

namespace Todo.Domain.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(string msg) : base(msg)
        {
            
        }
    }
}