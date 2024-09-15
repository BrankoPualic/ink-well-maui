using InkWell.MAUI.Business.Dtos.Auth;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Business.Services;
using InkWell.MAUI.Common;
using InkWell.MAUI.Common.Extensions;
using InkWell.MAUI.Validators;
using System.Windows.Input;

namespace InkWell.MAUI.ViewModels;

public class SignupPageVM : BaseVM
{
	private DateTime _maxDate;
	private DateTime _minDate;

	public MProp<string> FirstName { get; set; } = new();

	public MProp<string> LastName { get; set; } = new();

	public MProp<string> Email { get; set; } = new();

	public MProp<string> Username { get; set; } = new();

	public MProp<string> Password { get; set; } = new();

	public MProp<string> ConfirmPassword { get; set; } = new();

	public MProp<DateTime> DateOfBirth { get; set; } = new();

	public MProp<bool> InvalidCredentials { get; set; } = new();

	public ICommand SignupCommand { get; }

	private readonly IAuthService authService;

	public DateTime MinDate
	{
		get => _minDate;

		set
		{
			if (_minDate != value)
			{
				_minDate = value;
				OnPropertyChanged(nameof(MinDate));
			}
		}
	}

	public DateTime MaxDate
	{
		get => _maxDate;

		set
		{
			if (_maxDate != value)
			{
				_maxDate = value;
				OnPropertyChanged(nameof(MaxDate));
			}
		}
	}

	public SignupPageVM()
	{
		DateTime now = Functions.GetLocalToday();
		DateOfBirth.Value = now;
		_maxDate = now;
		_minDate = Constants.DATETIME_MIN_DATE;

		authService = new AuthService();

		SignupCommand = new Command(Signup);

		FirstName.OnChange = Validate;
		LastName.OnChange = Validate;
		Email.OnChange = Validate;
		Username.OnChange = Validate;
		Password.OnChange = Validate;
		ConfirmPassword.OnChange = Validate;
		DateOfBirth.OnChange = Validate;
	}

	private void Validate()
	{
		SignupValidator validator = new();

		var result = validator.Validate(this);

		if (!result.IsValid)
		{
			FirstName.Error = result.GetError(nameof(FirstName));
			LastName.Error = result.GetError(nameof(LastName));
			Email.Error = result.GetError(nameof(Email));
			Username.Error = result.GetError(nameof(Username));
			Password.Error = result.GetError(nameof(Password));
			ConfirmPassword.Error = result.GetError(nameof(ConfirmPassword));
			DateOfBirth.Error = result.GetError(nameof(DateOfBirth));
		}
		else
		{
			FirstName.Error = string.Empty;
			LastName.Error = string.Empty;
			Email.Error = string.Empty;
			Username.Error = string.Empty;
			Password.Error = string.Empty;
			ConfirmPassword.Error = string.Empty;
			DateOfBirth.Error = string.Empty;
		}
	}

	private async void Signup()
	{
		InvalidCredentials = new();

		SignupDto data = new();
		data.ToDtoFromVM(this);

		await authService.Signup(data);

		InvalidCredentials = new(authService.InvalidCredentials.Value, authService.InvalidCredentials.Error);

		OnPropertyChanged(nameof(InvalidCredentials));
	}
}