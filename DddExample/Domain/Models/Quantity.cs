using DddExample.Domain.Validation;
using DddExample.Domain.Validation.Errors;

namespace DddExample.Domain.Models
{
    public class Quantity
    {
        public decimal Amount { get; }
        public string Measurement { get; }

        public Quantity(decimal amount, string measurement)
        {
            ValidationResults? validation = null;
            if(amount <= 0)
            {
                ValidationResults.AddError(
                    ref validation,
                    nameof(Amount),
                    new RangeValidationError<decimal>(0, decimal.MaxValue));
            }

            if(string.IsNullOrWhiteSpace(measurement))
            {
                ValidationResults.AddError(
                    ref validation,
                    nameof(Measurement),
                    new EmptyValidationError());
            }

            validation?.ThrowIfFailed();

            Amount = amount;
            Measurement = measurement;
        }
    }
}