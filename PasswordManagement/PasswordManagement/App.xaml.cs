using PasswordManagement.Services;
using PasswordManagement.Views;

namespace PasswordManagement;

public partial class App : Application
{
	public App(DatabaseServices databaseServices)
	{
		InitializeComponent();

		MainPage = new AddNewPassword(databaseServices);
	}
}
