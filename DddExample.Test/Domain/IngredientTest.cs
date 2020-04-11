using DddExample.Domain.Models;
using DddExample.Domain.Validation;
using DddExample.Domain.Validation.Errors;
using NUnit.Framework;

namespace DddExample.Test.Domain
{
    public class IngredientTest
    {
        private static readonly Quantity quantity = new Quantity(1, "C");

        [TestCase("")]
        [TestCase(" ")]
        public void Ctor_EmptyName_ValidationError(string name)
        {
            var exception = Assert.Throws<ValidationException>(() => new Ingredient(name, quantity));

            Assert.IsInstanceOf<LengthValidationError>(exception.Errors[nameof(Ingredient.Name)][0]);
        }
    }
}