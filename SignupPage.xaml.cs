using InkWell.MAUI.Common.Extensions;

namespace InkWell.MAUI;

public partial class SignupPage : ContentPage
{
	public SignupPage()
	{
		InitializeComponent();
	}

	private void GoToSignin(object sender, EventArgs args) => RedirectExtensions<SigninPage>.Redirect();

	private void GoToMainPage(object sender, EventArgs args) => RedirectExtensions<MainPage>.Redirect();
}