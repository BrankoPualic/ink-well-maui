using InkWell.MAUI.Business.Dtos.User;

namespace InkWell.MAUI.Business.Dtos.Comment
{
	public class CommentDto
	{
		public Guid Id { get; set; }

		public string? Title { get; set; }

		public string Text { get; set; } = string.Empty;

		public Guid? ParentId { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }

		public int Upvotes { get; set; }

		public int Replies { get; set; }

		public AuthorDto User { get; set; }

		public IEnumerable<CommentDto> ReplyComments { get; set; } = [];
	}
}