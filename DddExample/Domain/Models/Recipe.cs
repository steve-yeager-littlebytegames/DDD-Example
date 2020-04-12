using System;
using System.Collections.Generic;
using DddExample.Domain.Validation;
using DddExample.Domain.Validation.DTOs;
using FluentValidation;
using FluentValidation.Validators;

namespace DddExample.Domain.Models
{
    internal class Recipe
    {
        public class Validator : AbstractValidator<Recipe>
        {
            public Validator()
            {
                RuleFor(r => r).Custom(VariantIDNotID);
                RuleFor(r => r.Name).Length(1, 50);
                RuleFor(r => r.Sections).NotEmpty();
            }

            private void VariantIDNotID(Recipe recipe, CustomContext context)
            {
                if(recipe.VariantID?.Value == recipe.ID.Value)
                {
                    context.AddFailure(nameof(VariantID), $"Can't be the same as {nameof(ID)}");
                }
            }
        }

        public readonly struct Guid
        {
            public System.Guid Value { get; }

            public Guid(System.Guid value)
            {
                Value = value;
            }
        }

        public Guid ID { get; }
        public string Name { get; }
        public Guid? VariantID { get; }
        public IReadOnlyCollection<Section> Sections { get; }
        public DateTime CreatedDate { get; }

        private Recipe(Guid id, string name, Guid? variantID, IReadOnlyCollection<Section> sections, DateTime createdDate)
        {
            ID = id;
            Name = name;
            VariantID = variantID;
            Sections = sections;
            CreatedDate = createdDate;
        }

        public RecipeDto ToDto()
        {
            return new RecipeDto(ID.Value, Name, VariantID?.Value, CreatedDate);
        }

        public static Result<Recipe> Construct(Guid? id, string name, Guid? variantID, IReadOnlyCollection<Section> sections, Validator? validator = null)
        {
            var createdDate = DateTime.UtcNow;
            id ??= new Guid(new System.Guid());
            var recipe = new Recipe(id.Value, name, variantID, sections, createdDate);

            validator ??= new Validator();
            var results = validator.Validate(recipe);
            return Result<Recipe>.Construct(recipe, results);
        }
    }
}