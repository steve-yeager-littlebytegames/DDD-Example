using DddExample.Domain.Models;

namespace DddExample.Test.Domain
{
    public class IngredientTest
    {
        private static readonly Quantity quantity = Quantity.Construct(1, "C", new Quantity.Validator()).Value;

        //[TestCase("")]
        //[TestCase(" ")]
        //public void Ctor_EmptyName_ValidationError(string name)
        //{
        //    var exception = Assert.Throws<ValidationException>(() => new Ingredient(name, quantity));

        //    Assert.IsInstanceOf<LengthValidationError>(exception.Errors[nameof(Ingredient.Name)][0]);
        //}
    }
}