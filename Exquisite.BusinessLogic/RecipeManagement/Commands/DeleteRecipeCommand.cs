using System;
using MediatR;

namespace Exquisite.BusinessLogic.RecipeManagement.Commands
{
    public class DeleteRecipeCommand : IRequest
    {
        public Guid RecipeId { get; set; }
    }
}