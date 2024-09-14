using InkWell.MAUI.Business.Dtos.Auth;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace InkWell.MAUI.Common.Extensions;

public static class SecureStorageExtensions
{
	public static UserAuth GetUser(this ISecureStorage storage)
	{
		var user = Task.Run(async () => await storage.GetAsync(Constants.STORAGE_USER)).Result;

		if (user is null)
			return null;

		var userDeserialized = JsonConvert.DeserializeObject<AuthResponseDto>(user);

		var handler = new JwtSecurityTokenHandler();
		var jsonToken = handler.ReadToken(userDeserialized?.Token);
		var tokenS = jsonToken as JwtSecurityToken;

		var id = tokenS!.Claims.First(_ => _.Type == Constants.CLAIM_ID).Value;
		var role = tokenS.Claims.First(_ => _.Type == Constants.CLAIM_ROLE).Value;
		var exp = tokenS.Claims.First(_ => _.Type == Constants.CLAIM_EXP).Value;

		long expTimestamp = long.Parse(exp);

		DateTime dateTime = UnixTimeStampToDateTime(expTimestamp);

		if (dateTime < DateTime.Now)
		{
			SecureStorage.Default.Remove(Constants.STORAGE_USER);
			return null;
		}

		return new()
		{
			Id = Guid.Parse(id!),
			Token = userDeserialized!.Token,
			Username = userDeserialized!.Username,
			Roles = role.Split(',')
		};
	}

	public static DateTime UnixTimeStampToDateTime(long unixTimeStamp) =>
		Constants.DATETIME_BEGINNING_UTC.AddSeconds(unixTimeStamp).ToLocalTime();
}