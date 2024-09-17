using InkWell.MAUI.Business.Dtos.Post;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Business.Services;
using InkWell.MAUI.Common;
using InkWell.MAUI.Common.Extensions;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InkWell.MAUI.ViewModels;

public class MainPageVM : BaseVM
{
	public MProp<string> Keyword { get; set; } = new();

	public ObservableCollection<PostDto> Posts { get; set; } = [];

	// Commands

	public ICommand RefreshCommand { get; }

	public ICommand SignupCommand { get; }

	public ICommand SigninCommand { get; }

	public ICommand SignoutCommand { get; }

	public ICommand AdminPanelCommand { get; }

	// Services

	private readonly IPostService postService;

	public MProp<bool> IsSignedIn { get; set; } = new();

	public MProp<string> Username { get; set; } = new();

	public MProp<bool> IsAdmin { get; set; } = new();

	public MainPageVM()
	{
		postService = new PostService();

		IsSignedIn.Value = Functions.IsSignedIn();
		if (IsSignedIn.Value)
		{
			var user = Functions.GetUserFromStorage();
			Username.Value = user.Username;
			IsAdmin.Value = Functions.IsAdmin();
		}

		Keyword.OnChange = LoadPosts;

		RefreshCommand = new Command(Refresh);
		SignupCommand = new Command(Signup);
		SigninCommand = new Command(Signin);
		SignoutCommand = new Command(Signout);
		AdminPanelCommand = new Command(AdminPanel);

		LoadPosts();
	}

	private void Signout()
	{
		SecureStorage.Default.Remove(Constants.STORAGE_USER);
		IsSignedIn.Value = false;
		Username.Value = string.Empty;
	}

	private void Refresh() => LoadPosts();

	private void AdminPanel() => RedirectExtensions<AdminPage>.Redirect();

	private void Signup() => RedirectExtensions<SignupPage>.Redirect();

	private void Signin() => RedirectExtensions<SigninPage>.Redirect();

	private async void LoadPosts()
	{
		var response = await postService.GetListAsync(Keyword.Value);

		Posts.Clear();

		Posts = new(response.Items);

		OnPropertyChanged(nameof(Posts));
	}
}