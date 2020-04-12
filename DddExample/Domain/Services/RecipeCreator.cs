using System;
using System.Threading.Tasks;
using DddExample.Domain.Models;
using DddExample.Domain.Validation.DTOs;
using DddExample.Domain.Validation.Requests;

namespace DddExample.Domain.Validation.Services
{
    public class RecipeCreator
    {
        public async Task<RecipeDto> Create(CreateRecipeRequest request)
        {
            Recipe.Guid? variantID = null;
            if(request.VariantID != null)
            {
                variantID = new Recipe.Guid(request.VariantID.Value);
            }

            var recipeResult = Recipe.Construct(
                null,
                request.Name,
                variantID,
                new[] {Section.Construct("test", new Section.Validator()).Value!});

            if(!recipeResult.IsValid)
            {
                throw new Exception(recipeResult.ValidationResults?.ToString());
            }

            // TODO: Save to DB.
            await Task.CompletedTask;

            return recipeResult.Value!.ToDto();
        }
    }
}