using MauiApp1.ViewModels;
using MauiApp1.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<QuizVM>();

		builder.Services.AddTransient<QuizPage>();

//#if DEBUG
//		builder.Logging.AddDebug();
//#endif

		return builder.Build();
	}
}
