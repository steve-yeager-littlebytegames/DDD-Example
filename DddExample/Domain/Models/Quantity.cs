using DddExample.Domain.Validation;

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
                    new ValidationError("Needs to be greater than 0."));
            }

            if(string.IsNullOrWhiteSpace(measurement))
            {
                ValidationResults.AddError(
                    ref validation,
                    nameof(Measurement),
                    new ValidationError("Can't be empty."));
            }

            validation?.ThrowIfFailed();

            Amount = amount;
            Measurement = measurement;
        }
    }
}