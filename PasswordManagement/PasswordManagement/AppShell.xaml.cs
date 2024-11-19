using PasswordManagement.Services;
using PasswordManagement.Views;

namespace PasswordManagement;

public partial class AppShell : Shell
{
	public AppShell(FirestoreService firestoreService)
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
		Routing.RegisterRoute(nameof(AddNewPassword), typeof(AddNewPassword));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
	}
}
