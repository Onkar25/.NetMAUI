using PasswordManagement.Services;
using PasswordManagement.ViewModels;

namespace PasswordManagement.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel(Navigation);
	}
	  public LoginPage(DatabaseServices databaseServices)
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel(databaseServices);
	}

	 public LoginPage(FirestoreService firestoreService)
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel(firestoreService);
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new SignUpPage());
		// Shell.Current.GoToAsync(nameof(SignUpPage));
    }
}