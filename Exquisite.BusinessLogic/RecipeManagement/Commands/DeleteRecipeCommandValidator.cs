using FluentValidation;

namespace Exquisite.BusinessLogic.RecipeManagement.Commands
{
    public class DeleteRecipeCommandValidator : AbstractValidator<DeleteRecipeCommand>
    {
        public DeleteRecipeCommandValidator()
        {
            RuleFor(x => x.RecipeId).NotEmpty().NotNull();
        }
    }
}