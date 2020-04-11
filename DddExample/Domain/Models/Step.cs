using System.Collections.Generic;
using DddExample.Domain.Validation;

namespace DddExample.Domain.Models
{
    public class Step
    {
        public string Instruction { get; }
        public IReadOnlyCollection<Ingredient>? Ingredients { get; }

        public Step(string instruction, IReadOnlyCollection<Ingredient>? ingredients)
        {
            ValidationResults validation = null;
            if(string.IsNullOrWhiteSpace(instruction))
            {
                ValidationResults.AddError(ref validation, nameof(Instruction), new ValidationError("Can't be empty."));
            }

            validation?.ThrowIfFailed();

            Instruction = instruction;
            Ingredients = ingredients;
        }
    }
}