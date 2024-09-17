using InkWell.MAUI.Business.Dtos.Auth;
using InkWell.MAUI.Common.Extensions;

namespace InkWell.MAUI.Common;

public static class Functions
{
	public static DateTime GetLocalToday() => DateTime.Today;

	public static UserAuth GetUserFromStorage() => SecureStorage.Default.GetUser();

	public static bool IsSignedIn() => GetUserFromStorage() is not null;

	public static bool IsAdmin() => IsSignedIn() && GetUserFromStorage().Roles.Has(Constants.ROLE_ADMINISTRATOR);
}