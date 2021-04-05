using System.Threading;
using System.Threading.Tasks;
using Exquisite.BusinessLogic.Entities;
using Exquisite.BusinessLogic.Helper;
using FluentValidation;
using LiteDB;
using MediatR;

namespace Exquisite.BusinessLogic.RecipeManagement.Commands
{
    public class SetLabelsCommandHandler : IRequestHandler<SetLabelsCommand>
    {
        private readonly SetLabelsCommandValidator _validator;
        private readonly ILiteCollection<Recipe> _collection;

        public SetLabelsCommandHandler(ILiteDatabase liteDatabase)
        {
            _validator = new SetLabelsCommandValidator();
            _collection = liteDatabase.GetCollection<Recipe>(CollectionNames.Recipe);
        }
        
        public async Task<Unit> Handle(SetLabelsCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var recipe = _collection.FindOne(x => x.Id == request.RecipeId);
            recipe.Labels = request.Labels;

            _collection.Update(recipe);
            
            return Unit.Value;
        }
    }
}