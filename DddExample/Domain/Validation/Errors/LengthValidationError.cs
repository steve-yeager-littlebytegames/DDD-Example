namespace DddExample.Domain.Validation.Errors
{
    public class LengthValidationError : ValidationError
    {
        public LengthValidationError(int min, int max)
            : base($"Length must be between {min} and {max}.")
        {
        }
    }
}