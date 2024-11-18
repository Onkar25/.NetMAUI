﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PasswordManagement.Services;
using PasswordManagement.Views;

namespace PasswordManagement;

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

			builder.Services.AddSingleton<DatabaseServices>();
			// builder.Services.AddTransient<AddNewPassword>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}