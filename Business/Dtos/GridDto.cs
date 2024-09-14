namespace InkWell.MAUI.Business.Dtos;

public class GridDto<T>
{
	public IEnumerable<T> Items { get; set; } = [];
}