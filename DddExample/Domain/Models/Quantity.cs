using DddExample.Domain.General;
using DddExample.Domain.Validation;
using DddExample.Domain.Validation.Errors;

namespace DddExample.Domain.Models
{
    public class Quantity
    {
        private const decimal AmountMin = 0.1m;
        private const decimal AmountMax = 10m;
        private static readonly Range measurementLength = new Range(1, 10);

        public decimal Amount { get; }
        public string Measurement { get; }

        public Quantity(decimal amount, string measurement)
        {
            ValidationResults? validation = null;
            if(amount < AmountMin || amount > AmountMax)
            {
                ValidationResults.AddError(
                    ref validation,
                    nameof(Amount),
                    new RangeValidationError<decimal>(AmountMin, AmountMax));
            }

            Amount = amount;
            Measurement = ValidationResults.Validate(measurement, nameof(Measurement), measurementLength, ref validation);

            validation?.ThrowIfFailed();
        }
    }
}