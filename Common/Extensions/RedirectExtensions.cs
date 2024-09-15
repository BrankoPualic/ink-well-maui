using InkWell.MAUI.Interfaces;

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

	public static async Task Redirect<TViewModel, TParam>(TParam parameter)
		where TViewModel : class, new()
	{
		var ctor = typeof(TViewModel).GetConstructor([typeof(TParam)]);
		if (ctor is not null)
		{
			var vm = (TViewModel)ctor.Invoke([parameter]);

			if (vm is IAsyncInitializable asyncInitializable)
			{
				await asyncInitializable.InitializeAsync();
			}

			var pageCtor = typeof(T).GetConstructor([typeof(TViewModel)]);
			if (pageCtor is not null)
			{
				var page = (T)pageCtor.Invoke([vm]);

				App.Current.MainPage = page;
			}
			else
			{
				throw new InvalidOperationException($"No constructor found in {typeof(T).Name} that accepts a ViewModel of type {typeof(TViewModel).Name}.");
			}
		}
		else
		{
			throw new InvalidOperationException($"No constructor found in {typeof(TViewModel).Name} that accepts a parameter of type {typeof(TParam).Name}.");
		}
	}
}