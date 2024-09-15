namespace InkWell.MAUI.Business.Dtos.Error;

public class ErrorDto
{
	public List<ValidationErrorDto> SubErrors { get; set; } = [];

	public string Title { get; set; } = string.Empty;

	public string Message { get; set; } = string.Empty;

	public int Code { get; set; }
}