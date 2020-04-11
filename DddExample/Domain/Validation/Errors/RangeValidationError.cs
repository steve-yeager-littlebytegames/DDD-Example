namespace DddExample.Domain.Validation.Errors
{
    public class RangeValidationError<T> : ValidationError
    {
        public RangeValidationError(T min, T max)
            : base($"Must be between {min} and {max}.")
        {
        }
    }
}