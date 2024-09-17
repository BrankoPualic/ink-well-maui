using InkWell.MAUI.Business.Dtos.User;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Business.Services;
using InkWell.MAUI.Common;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InkWell.MAUI.ViewModels;

public class AdminUserPageVM : BaseVM
{
	public ObservableCollection<PersonalInformationsDto> Users { get; set; } = [];

	public ICommand DeleteCommand { get; }

	private readonly IUserService userService;

	public AdminUserPageVM()
	{
		userService = new UserService();
		DeleteCommand = new Command<PersonalInformationsDto>(Delete);

		LoadUsers();
	}

	private async void Delete(PersonalInformationsDto data)
	{
		if (data.Id == Functions.GetUserFromStorage().Id)
			return;

		await userService.DeleteAsync(data.Id);

		LoadUsers();
	}

	private async void LoadUsers()
	{
		var response = await userService.GetListByAdminAsync();

		Users.Clear();

		Users = new(response.Items);

		OnPropertyChanged(nameof(Users));
	}
}