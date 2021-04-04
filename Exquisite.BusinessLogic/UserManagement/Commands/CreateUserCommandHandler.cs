using Exquisite.BusinessLogic.Entities;
using Exquisite.BusinessLogic.Helper;
using Exquisite.BusinessLogic.Helper.StringEncryption;
using Exquisite.BusinessLogic.UserManagement.Models;
using LiteDB;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exquisite.BusinessLogic.UserManagement.Commands
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IPasswordEncrypter _passwordEncrypter;
        private readonly ILiteCollection<User> _collection;

        public CreateUserCommandHandler(ILiteDatabase liteDatabase, IPasswordEncrypter passwordEncrypter)
        {
            _collection = liteDatabase.GetCollection<User>(CollectionNames.User);
            _passwordEncrypter = passwordEncrypter;
        }

        public Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var salt = Guid.NewGuid().ToString();
            var hashedPassword = _passwordEncrypter.Encrypt(request.Password, salt);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = hashedPassword,
                Salt = salt,
            };

            _collection.Insert(user);

            return Task.FromResult(new CreateUserResponse());
        }
    }
}
