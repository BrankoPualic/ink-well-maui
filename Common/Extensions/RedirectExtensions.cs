namespace InkWell.MAUI.Common.Extensions;

public static class RedirectExtensions<T>
	where T : Page, new()
{
	public static void Redirect() => App.Current.MainPage = Activator.CreateInstance<T>();

	public static void Redirect<TParam>(TParam parameter)
	{
		var ctor = typeof(T).GetConstructor([typeof(TParam)]);
		if (ctor is not null)
		{
			var page = (T)ctor.Invoke([parameter]);
			App.Current.MainPage = page;
		}
		else
			throw new InvalidOperationException($"No constructor found in {typeof(T).Name} that accepts a parameter of type {typeof(TParam).Name}.");
	}
}