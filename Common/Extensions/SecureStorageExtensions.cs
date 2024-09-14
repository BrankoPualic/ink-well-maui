using InkWell.MAUI.Business.Dtos.Auth;
using System.IdentityModel.Tokens.Jwt;

namespace InkWell.MAUI.Common.Extensions;

public static class SecureStorageExtensions
{
	public static UserAuth GetUser(this ISecureStorage storage)
	{
		var token = Task.Run(async () => await storage.GetAsync(Constants.STORAGE_TOKEN)).Result;

		if (token is null)
			return null;

		var handler = new JwtSecurityTokenHandler();
		var jsonToken = handler.ReadToken(token);
		var tokenS = jsonToken as JwtSecurityToken;

		var id = tokenS.Claims.First(_ => _.Type == Constants.CLAIM_ID).Value;
		var role = tokenS.Claims.First(_ => _.Type == Constants.CLAIM_ROLE).Value;
		var exp = tokenS.Claims.First(_ => _.Type == Constants.CLAIM_EXP).Value;

		long expTimestamp = long.Parse(exp);

		DateTime dateTime = UnixTimeStampToDateTime(expTimestamp);

		if (dateTime < DateTime.Now)
		{
			SecureStorage.Default.Remove(Constants.STORAGE_TOKEN);
			return null;
		}

		return new()
		{
			Id = Guid.Parse(id),
			Token = new(token),
			Username = ""
		};
	}

	public static DateTime UnixTimeStampToDateTime(long unixTimeStamp) =>
		Constants.DATETIME_BEGINNING_UTC.AddSeconds(unixTimeStamp).ToLocalTime();
}