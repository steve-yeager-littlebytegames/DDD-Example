using DddExample.Domain.Validation;
using FluentValidation;

namespace DddExample.Domain.Models
{
    public class IngredientValidator : AbstractValidator<Ingredient>
    {
        public IngredientValidator()
        {
            RuleFor(i => i.Name).Length(1, 30);
        }
    }

    public class Ingredient
    {
        public string Name { get; }
        public Quantity Quantity { get; }

        private Ingredient(string name, Quantity quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public static Result<Ingredient> Construct(string name, Quantity quantity, IngredientValidator validator)
        {
            name = name.Trim();
            var ingredient = new Ingredient(name, quantity);

            var results = validator.Validate(ingredient);
            return Result<Ingredient>.Construct(ingredient, results);
        }
    }
}