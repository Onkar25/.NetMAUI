using CommunityToolkit.Maui;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Microsoft.Extensions.Logging;
using PasswordManagement.Services;
using PasswordManagement.ViewModels;
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

		// Services
		builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig() { ApiKey = "AIzaSyCrciBVoWwcJqXkVmcJmdEBU7KuqGs7vAs", AuthDomain = "maui-password-mgmt.firebaseapp.com", Providers = [new EmailProvider()] ,UserRepository = new FileUserRepository("SecretPassword")}));
		builder.Services.AddSingleton<DatabaseServices>();
		builder.Services.AddSingleton<FirestoreService>();

		//View Models
		builder.Services.AddSingleton<AddNewPasswordViewModel>();
		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<SignUpPageViewModel>();
		builder.Services.AddSingleton<AppShell>();

		// Pages
		builder.Services.AddTransient<AddNewPassword>();
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<SignUpPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
