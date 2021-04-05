using FluentValidation;

namespace Exquisite.BusinessLogic.RecipeManagement.Commands
{
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Ingredients).NotNull().NotEmpty();
            RuleFor(x => x.Instructions).NotNull().NotEmpty();
        }
    }
}