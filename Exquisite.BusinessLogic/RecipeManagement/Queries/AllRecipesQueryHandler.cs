using System.Threading;
using System.Threading.Tasks;
using Exquisite.BusinessLogic.Entities;
using Exquisite.BusinessLogic.Helper;
using Exquisite.BusinessLogic.RecipeManagement.Models;
using LiteDB;
using MediatR;

namespace Exquisite.BusinessLogic.RecipeManagement.Queries
{
    public class AllRecipesQueryHandler : IRequestHandler<AllRecipesQuery, AllRecipesResponse>
    {
        private readonly ILiteCollection<Recipe> _collection;

        public AllRecipesQueryHandler(ILiteDatabase liteDatabase)
        {
            _collection = liteDatabase.GetCollection<Recipe>(CollectionNames.Recipe);
        }
        
        public Task<AllRecipesResponse> Handle(AllRecipesQuery request, CancellationToken cancellationToken)
        {
            var recipes = _collection.Query().ToList();
            return Task.FromResult(new AllRecipesResponse {Recipes = recipes});
        }
    }
}