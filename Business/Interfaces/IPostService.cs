using InkWell.MAUI.Business.Dtos;
using InkWell.MAUI.Business.Dtos.Post;
using InkWell.MAUI.Business.Dtos.User;

namespace InkWell.MAUI.Business.Interfaces;

public interface IPostService
{
	Task<GridDto<PostDto>> GetListAsync(string keyword);

	Task<PostDto> GetSingleAsync(Guid id);

	Task LikeAsync(LikeDto data);

	Task DeleteAsync(Guid id);
}