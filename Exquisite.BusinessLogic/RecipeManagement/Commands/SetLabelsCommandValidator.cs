using FluentValidation;

namespace Exquisite.BusinessLogic.RecipeManagement.Commands
{
    public class SetLabelsCommandValidator : AbstractValidator<SetLabelsCommand>
    {
        public SetLabelsCommandValidator()
        {
            RuleFor(x => x.RecipeId).NotEmpty().NotNull();
            RuleFor(x => x.Labels).NotNull();
        }
    }
}