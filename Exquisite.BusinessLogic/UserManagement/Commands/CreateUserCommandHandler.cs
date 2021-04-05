using Exquisite.BusinessLogic.Entities;
using Exquisite.BusinessLogic.Helper;
using Exquisite.BusinessLogic.UserManagement.Models;
using LiteDB;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Exquisite.BusinessLogic.Helper.PasswordEncryption;
using FluentValidation;

namespace Exquisite.BusinessLogic.UserManagement.Commands
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IPasswordEncryptor _passwordEncryptor;
        private readonly ILiteCollection<User> _collection;
        private readonly CreateUserCommandValidator _validator;

        public CreateUserCommandHandler(ILiteDatabase liteDatabase, IPasswordEncryptor passwordEncryptor)
        {
            _validator = new CreateUserCommandValidator();
            _collection = liteDatabase.GetCollection<User>(CollectionNames.User);
            _passwordEncryptor = passwordEncryptor;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            
            var salt = Guid.NewGuid().ToString();
            var hashedPassword = _passwordEncryptor.Encrypt(request.Password, salt);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = hashedPassword,
                Roles = new [] { "user" } ,
                Salt = salt,
            };

            _collection.Insert(user);

            return new CreateUserResponse();
        }
    }
}
