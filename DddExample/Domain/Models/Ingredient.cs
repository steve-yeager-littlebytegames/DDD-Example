using DddExample.Domain.Validation;
using FluentValidation;

namespace DddExample.Domain.Models
{
    public class Ingredient
    {
        public class Validator : AbstractValidator<Ingredient>
        {
            public Validator()
            {
                RuleFor(i => i.Name).Length(1, 30);
            }
        }

        public string Name { get; }
        public Quantity Quantity { get; }

        private Ingredient(string name, Quantity quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public static Result<Ingredient> Construct(string name, Quantity quantity, Validator validator)
        {
            name = name.Trim();
            var ingredient = new Ingredient(name, quantity);

            var results = validator.Validate(ingredient);
            return Result<Ingredient>.Construct(ingredient, results);
        }
    }
}