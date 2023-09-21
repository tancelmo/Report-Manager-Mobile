using Microsoft.Extensions.Logging;
using Report_Manager_Mobile.Pages;
using Syncfusion.Maui.Core.Hosting;

namespace Report_Manager_Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
