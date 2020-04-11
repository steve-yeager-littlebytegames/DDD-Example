using DddExample.Domain.Models;
using DddExample.Test.Utility;
using NUnit.Framework;

namespace DddExample.Test.Domain
{
    public class QuantityTest
    {
        [TestCase(0)]
        [TestCase(-1)]
        public void Ctor_InvalidAmount_ValidationError(decimal amount)
        {
            ValidationResultAssert.FirstError(
                nameof(Quantity.Amount),
                "Needs to be greater than 0.",
                () => new Quantity(amount, "C"));
        }

        [TestCase("")]
        [TestCase(" ")]
        public void Ctor_MissingMeasurement_ValidationError(string measurement)
        {
            ValidationResultAssert.FirstError(
                nameof(Quantity.Measurement),
                "Can't be empty.",
                () => new Quantity(1, measurement));
        }
    }
}