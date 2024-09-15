using FluentValidation;
using InkWell.MAUI.ViewModels;

namespace InkWell.MAUI.Validators;

public class SignupValidator : AbstractValidator<SignupPageVM>
{
	public SignupValidator()
	{
		RuleFor(_ => _.FirstName.Value)
				.NotEmpty().WithMessage("First name is required.")
				.Length(3, 20).WithMessage("First name must be between 3 and 30 characters.");

		RuleFor(_ => _.LastName.Value)
			.NotEmpty().WithMessage("Last name is required.")
			.Length(3, 50).WithMessage("Last name must be between 3 and 50 characters.");

		RuleFor(_ => _.Email.Value)
			.NotEmpty().WithMessage("Email is required.")
			.EmailAddress().WithMessage("Invalid email format.")
			.MaximumLength(60).WithMessage("Email can't be longer than 60 characters.");

		RuleFor(_ => _.Username.Value)
			.NotEmpty().WithMessage("Username is required.")
			.Length(4, 20).WithMessage("Username must be between 4 and 20 cahracters.");

		RuleFor(_ => _.Password.Value)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
			.Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
			.Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
			.Matches("[0-9]").WithMessage("Password must contain at least one digit.")
			.Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

		RuleFor(_ => _.ConfirmPassword.Value)
			.NotEmpty().WithMessage("Confirm password is required.")
			.Equal(_ => _.Password.Value).WithMessage("Confirm password and password do not match.");

		RuleFor(_ => _.DateOfBirth.Value)
			.NotEmpty().WithMessage("Date of birth is required.")
			.Must(BeAtLeastTenYearsOld).WithMessage("User must be at least 10 years old.");
	}

	private bool BeAtLeastTenYearsOld(DateTime dob)
	{
		DateTime minimumDob = DateTime.Today.AddYears(-10);
		return dob <= minimumDob;
	}
}