using DddExample.Domain.Models;
using DddExample.Domain.Validation;
using DddExample.Domain.Validation.Errors;
using NUnit.Framework;

namespace DddExample.Test.Domain
{
    public class QuantityTest
    {
        [TestCase(0)]
        [TestCase(-1)]
        public void Ctor_AmountInvalidRange_RangeError(decimal amount)
        {
            var exception = Assert.Throws<ValidationException>(() => new Quantity(amount, "C"));

            Assert.IsInstanceOf<RangeValidationError<decimal>>(exception.Errors[nameof(Quantity.Amount)][0]);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("xxxxxxxxxxx")]
        public void Ctor_MeasurementInvalidLength_LengthError(string measurement)
        {
            var exception = Assert.Throws<ValidationException>(() => new Quantity(1, measurement));

            Assert.IsInstanceOf<LengthValidationError>(exception.Errors[nameof(Quantity.Measurement)][0]);
        }
    }
}