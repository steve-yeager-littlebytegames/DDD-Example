using DddExample.Domain.Models;
using DddExample.Test.Utility;
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
            ValidationResultAssert.FirstMessage(
                nameof(Ingredient.Name),
                "Can't be empty.",
                () => new Ingredient(name, quantity));
        }
    }
}