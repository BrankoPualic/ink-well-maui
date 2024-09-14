using InkWell.MAUI.Common.Extensions;
using RestSharp;

namespace InkWell.MAUI.Business;

public class BaseService
{
	private static RestClient _client;
	private static bool authorizationSet = false;

	public static string BaseUrl => "https://localhost:7219/api/";

	public static RestClient Client
	{
		get
		{
			_client ??= new RestClient(BaseUrl);

			var user = SecureStorage.Default.GetUser();

			if (user is not null && !authorizationSet)
			{
				authorizationSet = true;
				_client.AddDefaultHeader("Authorization", "Bearer " + user.Token);
			}

			return _client;
		}
	}
}