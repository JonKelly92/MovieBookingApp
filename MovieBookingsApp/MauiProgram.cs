using Microsoft.Extensions.Logging;

namespace MovieBookingsApp;

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
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// Transient means a new verion of this page will be created each time it's called 
        builder.Services.AddTransient<MovieInfo_ViewModel>();
        builder.Services.AddTransient<MovieInfo>();

        return builder.Build();
	}
}
