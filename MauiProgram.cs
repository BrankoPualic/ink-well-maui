using InkWell.MAUI.Business.Interfaces;
using InkWell.MAUI.Business.Services;
using Microsoft.Extensions.Logging;

namespace InkWell;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("fa-solid-900.ttf", "FontAwesome");
			});

		builder.Services.AddScoped<IAuthService, AuthService>();
		builder.Services.AddScoped<IPostService, PostService>();
		builder.Services.AddScoped<ICommentService, CommentService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}