using PasswordManagement.Services;
using PasswordManagement.ViewModels;

namespace PasswordManagement.Views;

public partial class AddNewPassword : ContentPage
{
    public AddNewPassword(DatabaseServices databaseServices)
	{
		InitializeComponent();
		BindingContext = new AddNewPasswordViewModel(databaseServices);
	}
}