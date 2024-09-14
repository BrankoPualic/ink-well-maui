namespace InkWell.MAUI.Common.Extensions;

public static class Extensions
{
	public static bool In<T>(this IEnumerable<T> values, params T[] items) => items.Any(_ => values.Contains(_));
}