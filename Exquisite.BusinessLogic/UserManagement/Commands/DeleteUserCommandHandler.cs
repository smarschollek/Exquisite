using System.Threading;
using System.Threading.Tasks;
using Exquisite.BusinessLogic.Entities;
using Exquisite.BusinessLogic.Helper;
using FluentValidation;
using LiteDB;
using MediatR;

namespace Exquisite.BusinessLogic.UserManagement.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private ILiteCollection<User> _collection;
        private DeleteUserCommandValidator _validator;

        public DeleteUserCommandHandler(ILiteDatabase liteDatabase)
        {
            _validator = new DeleteUserCommandValidator();
            _collection = liteDatabase.GetCollection<User>(CollectionNames.User);
        }
        
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            _collection.Delete(request.Id);
            
            return Unit.Value;
        }
    }
}