using Firebase.Auth;
using PasswordManagement.Services;
using PasswordManagement.Views;

namespace PasswordManagement;

public partial class App : Application
{
	public App(FirestoreService firestoreService, FirebaseAuthClient firebaseAuthClient)
	{
		InitializeComponent();

		MainPage = new NavigationPage(new LoginPage(firestoreService , firebaseAuthClient));
	}
}
