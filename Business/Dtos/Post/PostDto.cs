using InkWell.MAUI.Business.Dtos.User;

namespace InkWell.MAUI.Business.Dtos.Post;

public class PostDto
{
	public Guid Id { get; set; }

	public string Title { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public string Text { get; set; } = string.Empty;

	public int ViewCount { get; set; }

	public string PostImageUrl { get; set; } = string.Empty;

	public string Category { get; set; } = string.Empty;

	public DateTime CreatedAt { get; set; }

	public int Comments { get; set; }

	public int Likes { get; set; }

	public AuthorDto Author { get; set; }
}