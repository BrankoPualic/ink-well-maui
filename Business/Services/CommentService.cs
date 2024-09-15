using InkWell.MAUI.Business.Dtos;
using InkWell.MAUI.Business.Dtos.Comment;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Common;

namespace InkWell.MAUI.Business.Services;

public class CommentService : BaseService, ICommentService
{
	public async Task<GridDto<CommentDto>?> GetListAsync(Guid postId)
	{
		var response = GetResponse<GridDto<CommentDto>>($"comment/{postId}");

		return response.IsSuccessful
			? response.Data
			: null;
	}

	public async Task UpvoteAsync(Guid commentId)
	{
		var isSignedIn = Functions.IsSignedIn();
		if (!isSignedIn) return;

		PostResponse("upvote", new EntryUpvoteDto { CommentId = commentId });

		return;
	}
}