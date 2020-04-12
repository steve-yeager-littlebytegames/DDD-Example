using System;

namespace DddExample.Domain.Validation.Requests
{
    public class CreateRecipeRequest
    {
        public string Name { get; set; } = null!;
        public Guid? VariantID { get; set; }
    }
}