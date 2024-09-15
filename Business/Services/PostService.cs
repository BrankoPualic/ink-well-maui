using InkWell.MAUI.Business.Dtos;
using InkWell.MAUI.Business.Dtos.Post;
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

	public async Task<PostDto> GetSingleAsync(Guid id)
	{
		var dictionary = new Dictionary<string, object>
		{
			{ "postId", id }
		};

		var response = GetWithQueryParametersResponse<PostDto>("post", dictionary);

		return response.IsSuccessful
			? response.Data
			: new();
	}
}