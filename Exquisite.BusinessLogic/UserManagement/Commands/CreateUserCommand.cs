using Exquisite.BusinessLogic.UserManagement.Models;
using MediatR;

namespace Exquisite.BusinessLogic.UserManagement.Commands
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
