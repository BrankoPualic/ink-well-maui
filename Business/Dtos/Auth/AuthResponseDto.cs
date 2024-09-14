namespace InkWell.MAUI.Business.Dtos.Auth;

public class AuthResponseDto
{
	public string Username { get; set; } = string.Empty;
	public string? ProfilePictureUrl { get; set; }
	public DateOnly DateOfBirth { get; set; }
	public string Token { get; set; } = string.Empty;
}