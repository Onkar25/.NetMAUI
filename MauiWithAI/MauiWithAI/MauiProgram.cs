using Microsoft.Extensions.Logging;

namespace MauiWithAI;

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
		builder.Services.AddTransient<MainPage>();

		OpenAIService svc = new OpenAIService();
		svc.Initialize(Constants.OpenAIKey, Constants.OpenAIEndpoint);
		builder.Services.AddSingleton<OpenAIService>(svc);
		return builder.Build();
	}
}
