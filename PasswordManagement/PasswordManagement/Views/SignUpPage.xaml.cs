using Firebase.Auth;
using PasswordManagement.ViewModels;

namespace PasswordManagement.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(FirebaseAuthClient firebaseAuthClient)
	{
		InitializeComponent();
		BindingContext = new SignUpPageViewModel(firebaseAuthClient);
	}
}