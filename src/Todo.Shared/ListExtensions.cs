using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Todo.Shared
{
    public static class ListExtensions
    {
        public static ErrorResponse GetErrorsValidation(this List<ValidationFailure> validationFailures)
        {
            var errors = validationFailures.Select(x => x.ErrorMessage);
            return new ErrorResponse(errors.ToList());
        }
    }
}