using Exquisite.BusinessLogic.RecipeManagement.Models;
using MediatR;

namespace Exquisite.BusinessLogic.RecipeManagement.Queries
{
    public class AllRecipesQuery : IRequest<AllRecipesResponse>
    {
    }
}