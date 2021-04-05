using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Exquisite.BusinessLogic.Entities;
using Exquisite.BusinessLogic.Helper;
using Exquisite.BusinessLogic.RecipeManagement.Models;
using FluentValidation;
using LiteDB;
using MediatR;

namespace Exquisite.BusinessLogic.RecipeManagement.Commands
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, CreateRecipeResponse>
    {
        private readonly CreateRecipeCommandValidator _validator;
        private readonly ILiteCollection<Recipe> _collection;

        public CreateRecipeCommandHandler(ILiteDatabase liteDatabase)
        {
            _validator = new CreateRecipeCommandValidator();
            _collection = liteDatabase.GetCollection<Recipe>(CollectionNames.Recipe);
        }
        
        public async Task<CreateRecipeResponse> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var recipeId = Guid.NewGuid();

            var recipe = new Recipe
            {
                Id = recipeId,
                UserId = request.UserId,
                Ingredients = request.Ingredients,
                Instructions = request.Instructions,
                Labels = new List<string>(),
                Name = request.Name
            };

            _collection.Insert(recipe);

            return new CreateRecipeResponse {RecipeId = recipeId };
        }
    }
}