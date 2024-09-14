namespace InkWell.MAUI.Common.Extensions;

public static class RedirectExtensions<T>
	where T : Page, new()
{
	public static void Redirect() => App.Current.MainPage = new T();
}