using System;
using MediatR;

namespace Exquisite.BusinessLogic.RecipeManagement.Commands
{
    public class SetLabelsCommand : IRequest
    {
        public Guid RecipeId { get; set; }
        public string[] Labels { get; set; }
    }
}