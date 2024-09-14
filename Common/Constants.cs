namespace InkWell.MAUI.Common;

public static class Constants
{
	public const string CLAIM_ROLE = "role";
	public const string CLAIM_ID = "nameid";
	public const string CLAIM_EXP = "exp";

	public const string STORAGE_TOKEN = "token";

	public static readonly DateTime DATETIME_BEGINNING_UTC = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
}