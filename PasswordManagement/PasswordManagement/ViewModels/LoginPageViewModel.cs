using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.Shapes;
using PasswordManagement.Services;
using PasswordManagement.Views;

namespace PasswordManagement.ViewModels;

public partial class LoginPageViewModel : ObservableObject
{
    private readonly DatabaseServices _databaseService;
    private readonly FirestoreService _firestoreService1;
    public INavigation Navigation { get; set;}

    public ICommand SignUpCommand { get; set; }

    public LoginPageViewModel(INavigation navigation)
    {
        SignUpCommand = new Command(async () => { await SignUp(); });
          this.Navigation = navigation;
    }

    public LoginPageViewModel(DatabaseServices databaseServices)
    {
        _databaseService = databaseServices;
        SignUpCommand = new Command(async () => { await SignUp(); });
    }

    public LoginPageViewModel(FirestoreService firestoreService)
    {
        _firestoreService1 = firestoreService;
        SignUpCommand = new Command(async () => { await SignUp(); });

    }
    public async Task SignUp()
    {
        //Working with App Shell.
        // App.Current.MainPage = new AppShell(_firestoreService1);
        await App.Current.MainPage.Navigation.PushAsync(new SignUpPage());
    }


}
