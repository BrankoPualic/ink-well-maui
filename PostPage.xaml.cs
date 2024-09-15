using InkWell.MAUI.Common.Extensions;
using InkWell.MAUI.ViewModels;

namespace InkWell.MAUI;

public partial class PostPage : ContentPage
{
	public PostPage()
	{ }

	public PostPage(PostPageVM vm) : this()
	{
		BindingContext = vm;
		InitializeComponent();
	}

	private void GoToSignup(object sender, EventArgs args) => RedirectExtensions<SignupPage>.Redirect();

	private void GoToSignin(object sender, EventArgs args) => RedirectExtensions<SigninPage>.Redirect();

	private void GoToMainPage(object sender, EventArgs args) => RedirectExtensions<MainPage>.Redirect();
}