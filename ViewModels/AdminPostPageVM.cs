using InkWell.MAUI.Business.Dtos.Post;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Business.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InkWell.MAUI.ViewModels;

public class AdminPostPageVM : BaseVM
{
	public ObservableCollection<PostDto> Posts { get; set; } = [];

	public ICommand DeleteCommand { get; }

	private readonly IPostService postService;

	public AdminPostPageVM()
	{
		postService = new PostService();
		DeleteCommand = new Command<PostDto>(Delete);

		LoadPosts();
	}

	private async void Delete(PostDto data)
	{
		await postService.DeleteAsync(data.Id);

		LoadPosts();
	}

	private async void LoadPosts()
	{
		var response = await postService.GetListAsync(string.Empty);

		Posts.Clear();

		Posts = new(response.Items);

		OnPropertyChanged(nameof(Posts));
	}
}