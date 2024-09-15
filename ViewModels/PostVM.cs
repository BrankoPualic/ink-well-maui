using InkWell.MAUI.Business.Dtos.Post;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Business.Services;
using InkWell.MAUI.Common;
using InkWell.MAUI.Interfaces;

namespace InkWell.MAUI.ViewModels;

public class PostVM : BaseVM, IAsyncInitializable
{
	public MProp<PostDto> Post { get; set; } = new();

	public MProp<Guid> Id { get; set; } = new();

	public string CreateDetails => $"Created by {Post.Value?.Author.FullName} at {Post.Value?.CreatedAt.ToString(Constants.DATETIME_DATE_MONTH_FORMAT)}";

	private readonly IPostService postService;

	public PostVM()
	{
		postService = new PostService();
	}

	public PostVM(Guid id) : this()
	{
		Id.Value = id;
	}

	// methods
	public async Task InitializeAsync() => await FindAsync();

	// private

	private async Task FindAsync()
	{
		var post = await postService.GetSingleAsync(Id.Value);

		if (post is null)
			Post.Error = "Not Found";
		else
		{
			Post.Value = post;
			OnPropertyChanged(nameof(CreateDetails));
		}
	}
}