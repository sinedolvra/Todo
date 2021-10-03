using System.Collections.Generic;

namespace Todo.Shared
{
    public class ErrorResponse
    {
        public List<string> Errors { get; set; }

        public ErrorResponse(List<string> errors)
        {
            Errors = errors;
        }
        
        public ErrorResponse(string error)
        {
            Errors = new List<string>(){error};
        }
    }
}