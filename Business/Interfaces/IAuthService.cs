using InkWell.MAUI.Business.Dtos.Auth;
using InkWell.MAUI.Common;

namespace InkWell.MAUI.Business.Interfaces;

public interface IAuthService
{
	MProp<bool> InvalidCredentials { get; set; }

	Task Signin(SigninDto data);

	Task Signup(SignupDto data);
}