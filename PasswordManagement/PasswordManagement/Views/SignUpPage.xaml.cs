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

	private void Button_Clicked(object sender, EventArgs e)
	{
		// if (PasswordValidation.IsNotValid)
		// {
		// 	// foreach (var error in PasswordValidation.Errors)
		// 	// {
		// 	// 	// ValidationMessage += "Email :" + error.ToString() + Environment.NewLine;
		// 	// }
		// 	// isValiad = false;
		// }
	}
}