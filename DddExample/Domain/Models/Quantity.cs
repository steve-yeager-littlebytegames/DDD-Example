using DddExample.Domain.Validation;
using DddExample.Domain.Validation.Errors;

namespace DddExample.Domain.Models
{
    public class Quantity
    {
        private const decimal AmountMin = 0.1m;
        private const decimal AmountMax = 10m;
        private const int MeasurementMin = 1;
        private const int MeasurementMax = 10;

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

            measurement = measurement.Trim();
            if(measurement.Length < MeasurementMin || measurement.Length > MeasurementMax)
            {
                ValidationResults.AddError(
                    ref validation,
                    nameof(Measurement),
                    new LengthValidationError(MeasurementMin, MeasurementMax));
            }

            validation?.ThrowIfFailed();

            Amount = amount;
            Measurement = measurement;
        }
    }
}