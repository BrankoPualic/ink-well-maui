using InkWell.MAUI.Business.Dtos;
using InkWell.MAUI.Business.Dtos.User;

namespace InkWell.MAUI.Business.Interfaces;

public interface IUserService
{
	Task<GridDto<PersonalInformationsDto>> GetListByAdminAsync();

	Task DeleteAsync(Guid id);
}