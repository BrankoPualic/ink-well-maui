using InkWell.MAUI.Common.Extensions;

namespace InkWell.MAUI;

public partial class AdminCommentPage : ContentPage
{
	public AdminCommentPage()
	{
		InitializeComponent();
	}

	private void GoToMainPage(object sender, EventArgs e) => RedirectExtensions<MainPage>.Redirect();
}