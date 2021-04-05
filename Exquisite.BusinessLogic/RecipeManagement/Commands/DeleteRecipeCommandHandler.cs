using System.Threading;
using System.Threading.Tasks;
using Exquisite.BusinessLogic.Entities;
using Exquisite.BusinessLogic.Helper;
using FluentValidation;
using LiteDB;
using MediatR;

namespace Exquisite.BusinessLogic.RecipeManagement.Commands
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand>
    {
        private DeleteRecipeCommandValidator _validator;
        private ILiteCollection<Recipe> _collection;

        public DeleteRecipeCommandHandler(ILiteDatabase liteDatabase)
        {
            _validator = new DeleteRecipeCommandValidator();
            _collection = liteDatabase.GetCollection<Recipe>(CollectionNames.Recipe);
        }
        
        public async Task<Unit> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            _collection.Delete(request.RecipeId);
            return Unit.Value;
        }
    }
}