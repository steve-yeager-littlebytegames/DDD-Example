using DddExample.Domain.Validation;
using DddExample.Domain.Validation.Errors;

namespace DddExample.Domain.Models
{
    public class Ingredient
    {
        public const int NameMin = 2;
        public const int NameMax = 10;

        public string Name { get; }
        public Quantity Quantity { get; }

        public Ingredient(string name, Quantity quantity)
        {
            ValidationResults? validation = null;
            name = name.Trim();
            if(name.Length < NameMin || name.Length > NameMax)
            {
                ValidationResults.AddError(
                    ref validation,
                    nameof(Name),
                    new LengthValidationError(NameMin, NameMax));
            }
            validation?.ThrowIfFailed();

            Name = name;
            Quantity = quantity;
        }
    }
}