using FluentValidation.Results;

namespace DddExample.Domain.Validation
{
    public class Result<T> where T: class
    {
        public T? Value { get; }
        public ValidationResult? ValidationResults { get; }

        public bool IsValid => Value != null;

        private Result(T? value, ValidationResult? validationResults)
        {
            Value = value;
            ValidationResults = validationResults;
        }

        public static Result<T> Construct(T value, ValidationResult result)
        {
            return result.IsValid ? new Result<T>(value, null) : new Result<T>(null, result);
        }
    }
}