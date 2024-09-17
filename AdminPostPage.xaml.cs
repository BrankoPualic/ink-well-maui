using InkWell.MAUI.Common.Extensions;

namespace InkWell.MAUI;

public partial class AdminPostPage : ContentPage
{
	public AdminPostPage()
	{
		InitializeComponent();
	}

	private void GoToMainPage(object sender, EventArgs e) => RedirectExtensions<MainPage>.Redirect();
}