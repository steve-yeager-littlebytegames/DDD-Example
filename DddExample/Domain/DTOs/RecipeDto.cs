using System;

namespace DddExample.Domain.Validation.DTOs
{
    public class RecipeDto
    {
        public Guid ID { get; }
        public string Name { get; }
        public Guid? VariantID { get; }
        public DateTime CreatedDate { get; }

        public RecipeDto(Guid id, string name, Guid? variantID, DateTime createdDate)
        {
            ID = id;
            Name = name;
            VariantID = variantID;
            CreatedDate = createdDate;
        }
    }
}