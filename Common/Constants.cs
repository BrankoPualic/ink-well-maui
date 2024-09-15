namespace InkWell.MAUI.Common;

public static class Constants
{
	public const string CLAIM_ROLE = "role";
	public const string CLAIM_ID = "nameid";
	public const string CLAIM_EXP = "exp";

	public const string STORAGE_USER = "user";

	public static readonly DateTime DATETIME_BEGINNING_UTC = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
	public static readonly DateTime DATETIME_MIN_DATE = new(1900, 1, 1, 0, 0, 0, DateTimeKind.Local);

	public const string ROLE_MEMEBER = "Member";
	public const string ROLE_MODERATOR = "Moderator";
	public const string ROLE_USERADMIN = "UserAdmin";
	public const string ROLE_BLOGGER = "Blogger";
	public const string ROLE_ADMINISTRATOR = "Administrator";

	public const string DATETIME_DATE_FOMRAT = "MM/dd/yyyy";
	public const string DATETIME_DATE_MONTH_FORMAT = "dd MMMM yyyy";
	public const string DATETIME_DATE_HTTP_BODY_FORMAT = "yyyy-MM-dd";
}