using InkWell.MAUI.Business.Dtos.Comment;
using InkWell.MAUI.Business.Dtos.Post;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Business.Services;
using InkWell.MAUI.Common;
using InkWell.MAUI.Common.Extensions;
using InkWell.MAUI.Interfaces;
using System.Collections.ObjectModel;

namespace InkWell.MAUI.ViewModels;

public class PostPageVM : BaseVM, IAsyncInitializable
{
	public ObservableCollection<CommentDto> Comments { get; set; } = [];

	public MProp<bool> NoComments { get; set; } = new();

	public MProp<PostDto> Post { get; set; } = new();

	public MProp<Guid> Id { get; set; } = new();

	public MProp<bool> IsSignedIn { get; set; } = new();

	public MProp<string> Username { get; set; } = new();

	public string CreateDetails => $"Created by {Post.Value?.Author.FullName} at {Post.Value?.CreatedAt.ToString(Constants.DATETIME_DATE_MONTH_FORMAT)}";

	private readonly IPostService postService;
	private readonly ICommentService commentService;

	public PostPageVM()
	{
		postService = new PostService();
		commentService = new CommentService();

		IsSignedIn.Value = Functions.IsSignedIn();
		if (IsSignedIn.Value)
		{
			var user = SecureStorage.Default.GetUser();
			Username.Value = user.Username;
		}
	}

	public PostPageVM(Guid id) : this()
	{
		Id.Value = id;
	}

	// methods
	public async Task InitializeAsync() => await FindAsync();

	// private

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
}