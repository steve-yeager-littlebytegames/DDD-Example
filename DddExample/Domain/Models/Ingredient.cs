using DddExample.Domain.Validation;

namespace DddExample.Domain.Models
{
    public class Ingredient
    {
        public string Name { get; }
        public Quantity Quantity { get; }

        public Ingredient(string name, Quantity quantity)
        {
            ValidationResults? validation = null;
            if(string.IsNullOrWhiteSpace(name))
            {
                ValidationResults.AddError(ref validation, nameof(Name), new ValidationError("Can't be empty."));
            }
            validation?.ThrowIfFailed();

            Name = name;
            Quantity = quantity;
        }
    }
}