using InkWell.MAUI.Business.Dtos;
using InkWell.MAUI.Business.Dtos.User;
using InkWell.MAUI.Business.Interfaces;

namespace InkWell.MAUI.Business.Services;

public class UserService : BaseService, IUserService
{
	public async Task DeleteAsync(Guid id)
	{
		var response = DeleteResponse($"user/${id}");
		return;
	}

	public async Task<GridDto<PersonalInformationsDto>> GetListByAdminAsync()
	{
		var response = GetResponse<GridDto<PersonalInformationsDto>>("user/detailed");

		return response.IsSuccessful
			? response.Data
			: new();
	}
}