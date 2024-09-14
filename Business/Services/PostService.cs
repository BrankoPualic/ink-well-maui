using InkWell.MAUI.Business.Dtos;
using InkWell.MAUI.Business.Dtos.Post;
using InkWell.MAUI.Business.Interfaces;
using Newtonsoft.Json;

namespace InkWell.MAUI.Business.Services;

public class PostService : BaseService, IPostService
{
	public async Task<GridDto<PostDto>> GetListAsync(string keyword)
	{
		var entryParams = new EntryParams();
		entryParams.QuickSearch = keyword;

		var dictionary = new Dictionary<string, string>()
		{
			{"entryParams", JsonConvert.SerializeObject(entryParams) }
		};
		var response = GetWithQueryParametersResponse<GridDto<PostDto>>("post", dictionary);

		return response.IsSuccessful
			? response.Data
			: new();
	}

	public async Task<PostDto> GetSingleAsync(Guid id)
	{
		var dictionary = new Dictionary<string, string>
		{
			{ "postId", id.ToString() }
		};

		var response = GetWithQueryParametersResponse<PostDto>("post", dictionary);

		return response.IsSuccessful
			? response.Data
			: new();
	}
}