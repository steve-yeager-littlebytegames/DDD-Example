using System;

namespace DddExample.Domain.Validation
{
    public class ValidationError
    {
        public string Message { get; }

        public ValidationError(string message)
        {
            if(string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Can't be empty.", nameof(message));
            }

            Message = message;
        }

        public override string ToString() => Message;
    }
}