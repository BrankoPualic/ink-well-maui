using InkWell.MAUI.Business.Dtos;
using InkWell.MAUI.Business.Dtos.Comment;

namespace InkWell.MAUI.Business.Interfaces;

public interface ICommentService
{
	Task<GridDto<CommentDto>> GetListAsync(Guid postId);

	Task UpvoteAsync(Guid commentId);
}