using InkWell.MAUI.Business.Dtos.Auth;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Common;
using InkWell.MAUI.Common.Extensions;
using Newtonsoft.Json;

namespace InkWell.MAUI.Business.Services;

public class AuthService : BaseService, IAuthService
{
	public MProp<bool> InvalidCredentials { get; set; }

	public async Task Signin(SigninDto data) => await ProcessAuthorization("auth/signin", data);

	public async Task Signup(SignupDto data) => await ProcessAuthorization("auth/signup", data);

	// private

	private async Task ProcessAuthorization<T>(string url, T data) where T : class
	{
		var response = PostResponse<AuthResponseDto>(url, data);

		if (response.IsSuccessful)
		{
			await SecureStorage.Default.SetAsync(Constants.STORAGE_USER, JsonConvert.SerializeObject(response.Data));

			InvalidCredentials.Value = false;

			//App.Current.MainPage = new UserPage();
			UserAuth user = SecureStorage.Default.GetUser();

			try
			{
				App.Current.MainPage = user.Roles switch
				{
					//var roles when roles.In(Constants.ROLE_ADMINISTRATOR) => new AdminPage(),
					//var roles when roles.In(Constants.ROLE_MEMEBER) => new MemberPage(),
					_ => throw new InvalidOperationException("Unknown role.")
				};
			}
			catch (Exception ex)
			{
				InvalidCredentials = new(true, ex.Message);
			}
		}
		else
			InvalidCredentials = new(true, "Error validating.");
	}
}