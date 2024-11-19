using PasswordManagement.Services;
using PasswordManagement.ViewModels;

namespace PasswordManagement.Views;

public partial class AddNewPassword : ContentPage
{

	public AddNewPassword()
	{
		InitializeComponent();
	}
	public AddNewPassword(DatabaseServices databaseServices)
	{
		InitializeComponent();
		BindingContext = new AddNewPasswordViewModel(databaseServices);
	}

	public AddNewPassword(FirestoreService firestoreService)
	{
		InitializeComponent();
		BindingContext = new AddNewPasswordViewModel(firestoreService);
	}
}