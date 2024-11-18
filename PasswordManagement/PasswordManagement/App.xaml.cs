using PasswordManagement.Services;
using PasswordManagement.Views;

namespace PasswordManagement;

public partial class App : Application
{
	public App(FirestoreService firestoreService)
	{
		InitializeComponent();

		MainPage = new AddNewPassword(firestoreService);
	}
}
