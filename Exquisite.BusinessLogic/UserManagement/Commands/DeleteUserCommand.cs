using System;
using MediatR;

namespace Exquisite.BusinessLogic.UserManagement.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}