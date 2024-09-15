using FluentValidation;
using InkWell.MAUI.ViewModels;

namespace InkWell.MAUI.Validators;

public class SigninValidator : AbstractValidator<SigninPageVM>
{
	public SigninValidator()
	{
		RuleFor(_ => _.Email.Value)
			.NotEmpty().WithMessage("Email is required.")
			.EmailAddress().WithMessage("Invalid email format.")
			.MaximumLength(60).WithMessage("Email can't be longer than 60 characters.");

		RuleFor(_ => _.Password.Value)
			.NotEmpty().WithMessage("Password is required.");
	}
}