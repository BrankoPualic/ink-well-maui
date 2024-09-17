using InkWell.MAUI.Common.Extensions;

namespace InkWell.MAUI;

public partial class AdminUsersPage : ContentPage
{
	public AdminUsersPage()
	{
		InitializeComponent();
	}

	private void GoToMainPage(object sender, EventArgs e) => RedirectExtensions<MainPage>.Redirect();
}