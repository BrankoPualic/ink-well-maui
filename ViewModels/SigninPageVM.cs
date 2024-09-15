using InkWell.MAUI.Business.Dtos.Auth;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Business.Services;
using InkWell.MAUI.Common;
using InkWell.MAUI.Common.Extensions;
using InkWell.MAUI.Validators;
using System.Windows.Input;

namespace InkWell.MAUI.ViewModels;

public class SigninPageVM : BaseVM
{
	public MProp<string> Email { get; set; } = new();

	public MProp<string> Password { get; set; } = new();

	public MProp<bool> InvalidCredentials { get; set; } = new();

	public ICommand SigninCommand { get; }

	private readonly IAuthService authService;

	public SigninPageVM()
	{
		authService = new AuthService();

		SigninCommand = new Command(Signin);

		Email.OnChange = Validate;
		Password.OnChange = Validate;
	}

	private void Validate()
	{
		SigninValidator validator = new();

		var result = validator.Validate(this);

		if (!result.IsValid)
		{
			Email.Error = result.GetError(nameof(Email));
			Password.Error = result.GetError(nameof(Password));
		}
		else
		{
			Email.Error = string.Empty;
			Password.Error = string.Empty;
		}
	}

	private async void Signin()
	{
		InvalidCredentials = new();

		SigninDto data = new();
		data.ToDtoFromVM(this);

		await authService.Signin(data);

		InvalidCredentials = new(authService.InvalidCredentials.Value, authService.InvalidCredentials.Error);

		OnPropertyChanged(nameof(InvalidCredentials));
	}
}