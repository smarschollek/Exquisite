using FluentValidation;

namespace Exquisite.BusinessLogic.UserManagement.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Password).MinimumLength(8).NotEmpty().NotNull();
            RuleFor(x => x.Username).NotEmpty().NotNull();
        }
    }
}