using InkWell.MAUI.Common.Extensions;

namespace InkWell.MAUI;

public partial class PostPage : ContentPage
{
	public Guid Id { get; }

	public PostPage()
	{ }

	public PostPage(Guid id) : this()
	{
		InitializeComponent();

		Id = id;
	}

	// methods

	private async void LoadPost()
	{ }

	private void GoToSignup(object sender, EventArgs args) => RedirectExtensions<SignupPage>.Redirect();

	private void GoToSignin(object sender, EventArgs args) => RedirectExtensions<SigninPage>.Redirect();
}