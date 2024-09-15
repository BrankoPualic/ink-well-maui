using InkWell.MAUI.Common.Extensions;

namespace InkWell.MAUI.Common;

public static class Functions
{
	public static DateTime GetLocalToday() => DateTime.Today;

	public static bool IsSignedIn() => SecureStorage.Default.GetUser() is not null;
}