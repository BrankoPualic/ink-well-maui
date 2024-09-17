using InkWell.MAUI.Business.Dtos;
using InkWell.MAUI.Business.Dtos.Comment;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Common;

namespace InkWell.MAUI.Business.Services;

public class CommentService : BaseService, ICommentService
{
	private readonly IPostService postService;

	public CommentService()
	{
		postService = new PostService();
	}

	public async Task CreateAsync(EntryCommentDto data)
	{
		var isSignedIn = Functions.IsSignedIn();
		if (!isSignedIn) return;

		PostResponse("comment", data);

		return;
	}

	public async Task<GridDto<CommentDto>?> GetListAsync(Guid postId)
	{
		var response = GetResponse<GridDto<CommentDto>>($"comment/{postId}");

		return response.IsSuccessful
			? response.Data
			: null;
	}

	public async Task<IEnumerable<CommentDto>> GetAllAsync()
	{
		var posts = await postService.GetListAsync(string.Empty);
		if (posts.Items is null)
			return [];

		IEnumerable<CommentDto> comments = [];
		foreach (var post in posts.Items)
		{
			var response = await GetListAsync(post.Id);
			if (response is null)
				continue;
			else if (response.Items is null)
				continue;
			comments = comments.Concat(response.Items);
		}

		return comments;
	}

	public async Task UpvoteAsync(Guid commentId)
	{
		var isSignedIn = Functions.IsSignedIn();
		if (!isSignedIn) return;

		PostResponse("upvote", new EntryUpvoteDto { CommentId = commentId });

		return;
	}

	public async Task DeleteAsync(Guid commentId)
	{
		var response = DeleteResponse($"comment/{commentId}");
		return;
	}
}