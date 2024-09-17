using InkWell.MAUI.Business.Dtos.Comment;
using InkWell.MAUI.Business.Dtos.Post;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Business.Services;
using InkWell.MAUI.Common;
using InkWell.MAUI.Common.Extensions;
using InkWell.MAUI.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InkWell.MAUI.ViewModels;

public class PostPageVM : BaseVM, IAsyncInitializable
{
	public ObservableCollection<CommentDto> Comments { get; set; } = [];

	public MProp<bool> NoComments { get; set; } = new();

	public MProp<PostDto> Post { get; set; } = new();

	public MProp<Guid> Id { get; set; } = new();

	public MProp<bool> IsSignedIn { get; set; } = new();

	public MProp<string> Username { get; set; } = new();

	public MProp<bool> IsAdmin { get; set; } = new();

	public string CreateDetails => $"Created by {Post.Value?.Author.FullName} at {Post.Value?.CreatedAt.ToString(Constants.DATETIME_DATE_MONTH_FORMAT)}";

	private readonly IPostService postService;
	private readonly ICommentService commentService;

	public MProp<string> CommentTitle { get; set; } = new();

	public MProp<string> CommentText { get; set; } = new();

	public ICommand SubmitCommentCommand { get; }

	public ICommand SignupCommand { get; }

	public ICommand SigninCommand { get; }

	public ICommand SignoutCommand { get; }

	public ICommand LikeCommand { get; }

	public ICommand AdminPanelCommand { get; }

	public PostPageVM()
	{
		SubmitCommentCommand = new Command(SubmitComment);
		SignupCommand = new Command(Signup);
		SigninCommand = new Command(Signin);
		SignoutCommand = new Command(Signout);
		LikeCommand = new Command(Like);
		AdminPanelCommand = new Command(AdminPanel);

		postService = new PostService();
		commentService = new CommentService();

		IsSignedIn.Value = Functions.IsSignedIn();
		if (IsSignedIn.Value)
		{
			var user = Functions.GetUserFromStorage();
			Username.Value = user.Username;
			IsAdmin.Value = Functions.IsAdmin();
		}
	}

	public PostPageVM(Guid id) : this()
	{
		Id.Value = id;
	}

	// methods
	public async Task InitializeAsync() => await FindAsync();

	// private

	private async void Like()
	{
		LikeDto data = new();
		data.ToDtoFromVm(this);
		await postService.LikeAsync(data);
		await FindAsync();
	}

	private void AdminPanel() => RedirectExtensions<AdminPage>.Redirect();

	private void Signup() => RedirectExtensions<SignupPage>.Redirect();

	private void Signin() => RedirectExtensions<SigninPage>.Redirect();

	private void Signout()
	{
		SecureStorage.Default.Remove(Constants.STORAGE_USER);
		IsSignedIn.Value = false;
		Username.Value = string.Empty;
	}

	private async Task FindAsync()
	{
		var post = await postService.GetSingleAsync(Id.Value);
		var comments = await commentService.GetListAsync(Id.Value);

		if (post is null)
			Post.Error = "Not Found";
		else
		{
			Post.Value = post;
			OnPropertyChanged(nameof(CreateDetails));
		}

		if (comments is null)
			NoComments = new(true, "Post doesn't have any comments yet.");
		else
		{
			Comments.Clear();
			Comments = new(comments.Items);
			OnPropertyChanged(nameof(Comments));
		}
	}

	private async void SubmitComment()
	{
		EntryCommentDto data = new();
		data.ToDtoFromVM(this);
		await commentService.CreateAsync(data);

		CommentText.Value = string.Empty;
		CommentTitle.Value = string.Empty;

		await FindAsync();
	}
}