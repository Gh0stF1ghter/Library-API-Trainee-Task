using FluentValidation;
using Core.Resources;

namespace API.Validators
{
    public class SaveGenreResourceValidator : AbstractValidator<SaveGenreResource>
    {
        public SaveGenreResourceValidator()
        {
            RuleFor(g => g.GenreName)
                .NotEmpty()
                .WithMessage("Genre name cannot be empty")
                .MinimumLength(3)
                .MaximumLength(20)
                .WithMessage("Genre name's length must be less than 20 symbols");
        }
    }
}
