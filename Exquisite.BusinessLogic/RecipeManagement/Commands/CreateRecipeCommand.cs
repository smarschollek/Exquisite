using System;
using Exquisite.BusinessLogic.Entities;
using Exquisite.BusinessLogic.RecipeManagement.Models;
using MediatR;

namespace Exquisite.BusinessLogic.RecipeManagement.Commands
{
    public class CreateRecipeCommand : IRequest<CreateRecipeResponse>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}