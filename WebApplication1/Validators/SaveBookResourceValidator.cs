using FluentValidation;
using API.Resources;

namespace API.Validators
{
    public class SaveBookResourceValidator : AbstractValidator<SaveBookResource>
    {
        public SaveBookResourceValidator()
        {
            RuleFor(b => b.BookAuthorId)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Author Id cannot be empty or negative");

            RuleFor(b => b.BookName)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(50)
                .WithMessage("Book Name cannot be null");

            RuleFor(b => b.BookISBN)
                .NotEmpty()
                .NotNull()
                .Length(13);
        }
    }
}
