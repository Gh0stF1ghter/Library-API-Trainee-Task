using Core.Resources;
using FluentValidation;

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
                .WithMessage("Book Name cannot be null or longer than 50 characters");

            RuleFor(b => b.BookISBN)
                .Length(13)
                .WithMessage("ISBN should have 13 digits")
                .Must(x =>
                {
                    var chars = x.ToCharArray();

                    if (chars.Length != 13)
                        return false;

                    double result = 0;

                    for (int i = 1; i < 13; i += 2)
                        result += char.GetNumericValue(chars[i]) * 3;
                    for (int i = 0; i < 13; i += 2)
                        result += char.GetNumericValue(chars[i]);

                    return result % 10 == 0;
                })
                .WithMessage("Isbn check digit is invalid");

            RuleFor(b => b.BookReturnDate)
                .GreaterThan(b => b.BookTakeDate);
        }
    }
}
