using InkWell.MAUI.ViewModels;

namespace InkWell.MAUI.Business.Dtos.Comment
{
	public class EntryCommentDto
	{
		public Guid PostId { get; set; }

		public string? Title { get; set; }

		public string Text { get; set; } = string.Empty;

		public Guid? ParentId { get; set; }

		public void ToDtoFromVM(PostPageVM vm)
		{
			PostId = vm.Id.Value;
			Title = vm.CommentTitle.Value;
			Text = vm.CommentText.Value;
		}
	}
}