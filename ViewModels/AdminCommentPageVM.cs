using InkWell.MAUI.Business.Dtos.Comment;
using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Business.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InkWell.MAUI.ViewModels;

public class AdminCommentPageVM : BaseVM
{
	public ObservableCollection<CommentDto> Comments { get; set; } = [];

	public ICommand DeleteCommand { get; }
	private readonly ICommentService commentService;

	public AdminCommentPageVM()
	{
		commentService = new CommentService();
		DeleteCommand = new Command<CommentDto>(Delete);

		LoadComments();
	}

	private async void Delete(CommentDto data)
	{
		await commentService.DeleteAsync(data.Id);

		LoadComments();
	}

	private async void LoadComments()
	{
		var response = await commentService.GetAllAsync();

		Comments.Clear();

		Comments = new(response);

		OnPropertyChanged(nameof(Comments));
	}
}