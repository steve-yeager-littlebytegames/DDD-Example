namespace DddExample.Domain.Validation.Errors
{
    public class RangeValidationError<T> : ValidationError
    {
        public RangeValidationError(T min, T max, bool inclusiveMin = true, bool inclusiveMax = true)
            : base($"Must be between {min} and {max}.")
        {
        }
    }
}