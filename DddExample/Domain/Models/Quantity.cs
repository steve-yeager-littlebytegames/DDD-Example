using DddExample.Domain.Validation;
using FluentValidation;

namespace DddExample.Domain.Models
{
    public class QuantityValidator : AbstractValidator<Quantity>
    {
        public QuantityValidator()
        {
            RuleFor(q => q.Amount).InclusiveBetween(0.1m, 10m);
            RuleFor(q => q.Measurement).Length(1, 10);
        }
    }

    public class Quantity
    {
        public decimal Amount { get; }
        public string Measurement { get; }

        private Quantity(decimal amount, string measurement)
        {
            Amount = amount;
            Measurement = measurement;
        }

        public static Result<Quantity> Construct(decimal amount, string measurement, QuantityValidator validator)
        {
            measurement = measurement.Trim();
            var quantity = new Quantity(amount, measurement);

            var result = validator.Validate(quantity);
            return Result<Quantity>.Construct(quantity, result);
        }
    }
}