namespace InkWell.MAUI.Business.Dtos.User;

public class AuthorDto
{
	public Guid Id { get; set; }

	public string Username { get; set; } = string.Empty;

	public string? ProfilePictureUrl { get; set; }

	public int Followers { get; set; }

	public int Following { get; set; }

	public int Posts { get; set; }

	public string FullName { get; set; } = string.Empty;

	public DateOnly DateOfBirth { get; set; }
}