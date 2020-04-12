using System.Collections.Generic;
using DddExample.Domain.Validation;
using FluentValidation;

namespace DddExample.Domain.Models
{
    public class Step
    {
        public class Validator : AbstractValidator<Step>
        {
            public Validator()
            {
                RuleFor(s => s.Instruction).Length(1, 100);
            }
        }

        public string Instruction { get; }
        public IReadOnlyCollection<Ingredient>? Ingredients { get; }

        private Step(string instruction, IReadOnlyCollection<Ingredient>? ingredients)
        {
            Instruction = instruction;
            Ingredients = ingredients;
        }

        public static Result<Step> Construct(string instruction, IReadOnlyCollection<Ingredient>? ingredients, Validator validator)
        {
            var step = new Step(instruction, ingredients);

            var results = validator.Validate(step);
            return Result<Step>.Construct(step, results);
        }
    }
}