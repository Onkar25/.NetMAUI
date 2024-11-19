using PasswordManagement.ViewModels;

namespace PasswordManagement.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
		BindingContext = new SignUpPageViewModel();
	}
}