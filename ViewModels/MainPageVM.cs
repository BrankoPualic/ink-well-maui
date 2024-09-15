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

	// Services

	private readonly IPostService postService;

	public MainPageVM()
	{
		postService = new PostService();

		Keyword.OnChange = LoadPosts;

		RefreshCommand = new Command(Refresh);
		SignupCommand = new Command(Signup);
		SigninCommand = new Command(Signin);

		LoadPosts();
	}

	private void Refresh() => LoadPosts();

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