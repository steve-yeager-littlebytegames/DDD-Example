namespace DddExample.Domain.Validation.Errors
{
    public class EmptyValidationError : ValidationError
    {
        public EmptyValidationError()
            : base("Can't be empty.")
        {
        }
    }
}