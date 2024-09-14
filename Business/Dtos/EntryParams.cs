namespace InkWell.MAUI.Business.Dtos;

public class EntryParams
{
	public string? QuickSearch { get; set; }

	public int PageNumber { get; set; } = 1;

	private int _pageSize = 10;

	public int PageSize
	{
		get => _pageSize;

		set
		{
			if (value > 50
				|| value < 10)
			{
				_pageSize = 10;
				return;
			}
			_pageSize = value;
		}
	}

	public string? SortDirection { get; set; }

	public string? SortColumn { get; set; }
}