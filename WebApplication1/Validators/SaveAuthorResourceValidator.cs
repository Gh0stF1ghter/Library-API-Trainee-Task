using FluentValidation;
using API.Resources;

namespace API.Validators
{
    public class SaveAuthorResourceValidator : AbstractValidator<SaveAuthorResource>
    {
        public SaveAuthorResourceValidator()
        {
            RuleFor(a => a.AuthorFirstMidName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(a => a.AuthorLastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
        }
    }
}
