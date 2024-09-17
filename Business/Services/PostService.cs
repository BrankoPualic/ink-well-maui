using InkWell.MAUI.Business.Dtos;
using InkWell.MAUI.Business.Dtos.Post;
using InkWell.MAUI.Business.Dtos.User;
using InkWell.MAUI.Business.Interfaces;

namespace InkWell.MAUI.Business.Services;

public class PostService : BaseService, IPostService
{
	public async Task<GridDto<PostDto>> GetListAsync(string keyword)
	{
		var entryParams = new EntryParams
		{
			QuickSearch = keyword,
		};

		var dictionary = new Dictionary<string, object>()
		{
			{nameof(EntryParams.QuickSearch), entryParams.QuickSearch }
		};
		var response = GetWithQueryParametersResponse<GridDto<PostDto>>("post", dictionary);

		return response.IsSuccessful
			? response.Data
			: new();
	}

	public async Task<PostDto?> GetSingleAsync(Guid id)
	{
		var response = GetResponse<PostDto>($"post/{id}");

		return response.IsSuccessful
			? response.Data
			: null;
	}

	public async Task LikeAsync(LikeDto data)
	{
		var response = PostResponse("like", data);

		return;
	}

	public async Task DeleteAsync(Guid id)
	{
		var response = DeleteResponse($"post/{id}");
		return;
	}
}