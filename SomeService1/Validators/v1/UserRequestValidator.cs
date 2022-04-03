using FluentValidation;
using Shared.Additions.Extensions;
using Shared.Additions.FluentValidators.Options.Enums;
using SomeService1.Contracts.v1.Requests;

namespace SomeService1.Validators.v1;

public class UserRequestValidator : AbstractValidator<UserRequest>
{
    public UserRequestValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.Name))
            .WithMessage("The maximum name name length is 100 characters")
            .IsLetter()
            .When(x => !string.IsNullOrEmpty(x.Name))
            .WithMessage("Only letters are allowed in the name");

        RuleFor(x => x.Surname)
            .Cascade(CascadeMode.Stop)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.Surname))
            .WithMessage("The maximum surname name length is 100 characters")
            .IsLetter()
            .When(x => !string.IsNullOrEmpty(x.Surname))
            .WithMessage("Only letters are allowed in the surname");

        RuleFor(x => x.MiddleName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("The middlename is required")
            .MaximumLength(100)
            .WithMessage("The maximum middlename length is 100 characters")
            .IsLetter()
            .WithMessage("Only letters are allowed in the middlename");


        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage(x => $"Email '{x.Email}' is invalid.");

        RuleFor(x => x.PhoneNumber)
            .IsPhoneNumber(option =>
            {
                option.PhoneType = PhoneNumberType.Mobile;
                option.CountryCode = "RU";
                option.PhoneFormat = PhoneNumberFormat.E164;
            })
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber));
    }
}