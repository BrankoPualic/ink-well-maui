using InkWell.MAUI.Business.Dtos.Auth;

namespace InkWell.MAUI.Business.Interfaces;

public interface IAuthService
{
	Task Signin(SigninDto data);

	Task Signup(SignupDto data);
}