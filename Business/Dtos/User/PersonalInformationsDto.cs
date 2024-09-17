namespace InkWell.MAUI.Business.Dtos.User;

public class PersonalInformationsDto : AuthorDto
{
	public string Email { get; set; } = string.Empty;

	public List<string> Roles { get; set; } = [];

	public bool IsActive { get; set; }

	public DateTime CreatedAt { get; set; }

	public DateTime? ModifiedAt { get; set; }

	public Guid? ModifiedBy { get; set; }

	public DateTime? DeletedAt { get; set; }

	public Guid? DeletedBy { get; set; }
}