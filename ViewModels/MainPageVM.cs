using InkWell.MAUI.Business.Dtos.Post;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Common;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InkWell.MAUI.ViewModels;

public class MainPageVM
{
	public MProp<string> Keyword { get; set; } = new();

	public ObservableCollection<PostDto> Posts { get; set; } = [];

	// Commands

	public ICommand RefreshCommand { get; }

	public ICommand SignupCommand { get; }

	public ICommand SigninCommand { get; }

	public MainPageVM()
	{
		RefreshCommand = new Command(Refresh);
		SignupCommand = new Command(Signup);
		SigninCommand = new Command(Signin);
	}

	public MainPageVM(IAuthService authService) : this()
	{
	}

	private void Refresh()
	{ }

	private void Signup()
	{ }

	private void Signin()
	{ }
}