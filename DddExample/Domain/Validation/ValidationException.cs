using System;
using System.Collections.Generic;

namespace DddExample.Domain.Validation
{
    public class ValidationException : Exception
    {
        public IReadOnlyDictionary<string, IReadOnlyList<string>> Errors { get; }

        public ValidationException(IReadOnlyDictionary<string, IReadOnlyList<string>> errors)
        {
            Errors = errors;
        }
    }
}