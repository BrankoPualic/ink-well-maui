using InkWell.MAUI.Business.Dtos;
using InkWell.MAUI.Business.Dtos.Comment;

namespace InkWell.MAUI.Business.Interfaces;

public interface ICommentService
{
	Task<GridDto<CommentDto>> GetListAsync(Guid postId);

	Task<IEnumerable<CommentDto>> GetAllAsync();

	Task UpvoteAsync(Guid commentId);

	Task CreateAsync(EntryCommentDto data);

	Task DeleteAsync(Guid commentId);
}