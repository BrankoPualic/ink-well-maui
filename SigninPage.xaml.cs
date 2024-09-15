using InkWell.MAUI.Common.Extensions;

namespace InkWell.MAUI;

public partial class SigninPage : ContentPage
{
	public SigninPage()
	{
		InitializeComponent();
	}

	private void GoToSignup(object sender, EventArgs args) => RedirectExtensions<SignupPage>.Redirect();

	private void GoToMainPage(object sender, EventArgs args) => RedirectExtensions<MainPage>.Redirect();
}