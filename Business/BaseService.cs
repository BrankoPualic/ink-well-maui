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

	// Requests

	#region Requests

	public static RestRequest Get(string url) => new(url);

	public static RestRequest GetWithQueryParameters(string url, IDictionary<string, object> parameters)
	{
		var request = new RestRequest(url);

		foreach (var item in parameters)
		{
			request.AddParameter(item.Key, item.Value, ParameterType.QueryString);
		}

		return request;
	}

	public static RestRequest Post(string url, object body) => new RestRequest(url, Method.Post).AddJsonBody(body);

	public static RestRequest Put(string url, object body) => new RestRequest(url, Method.Put).AddJsonBody(body);

	public static RestRequest PutWithQueryParameters(string url, object body, string parameterKey, string parameterValue) =>
		new RestRequest(url, Method.Put)
			.AddParameter(parameterKey, parameterValue, ParameterType.QueryString)
			.AddJsonBody(body);

	public static RestRequest Delete(string url, string parameterKey, string parameterValue) =>
		new RestRequest(url, Method.Delete)
			.AddParameter(parameterKey, parameterValue, ParameterType.QueryString);

	#endregion Requests

	// Responses

	#region Responses

	public static RestResponse<T> GetResponse<T>(string url) => Client.Execute<T>(Get(url));

	public static RestResponse<T> GetWithQueryParametersResponse<T>(string url, IDictionary<string, object> parameters) =>
		Client.Execute<T>(GetWithQueryParameters(url, parameters));

	public static RestResponse<T> PostResponse<T>(string url, object body) => Client.Execute<T>(Post(url, body));

	public static RestResponse PostResponse(string url, object body) => Client.Execute(Post(url, body));

	public static RestResponse PutResponse(string url, object body) => Client.Execute(Put(url, body));

	public static RestResponse PutWithQueryParametersResponse(string url, object body, string parameterKey, string parameterValue) => Client.Execute(PutWithQueryParameters(url, body, parameterKey, parameterValue));

	public static RestResponse DeleteResponse(string url, string parameterKey, string parameterValue) =>
		Client.Execute(Delete(url, parameterKey, parameterValue));

	#endregion Responses
}