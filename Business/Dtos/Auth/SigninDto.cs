using InkWell.MAUI.ViewModels;

namespace InkWell.MAUI.Business.Dtos.Auth;

public class SigninDto
{
	public string Email { get; set; } = string.Empty;

	public string Password { get; set; } = string.Empty;

	public void ToDtoFromVM(SigninPageVM vm)
	{
		Email = vm.Email.Value;
		Password = vm.Password.Value;
	}
}