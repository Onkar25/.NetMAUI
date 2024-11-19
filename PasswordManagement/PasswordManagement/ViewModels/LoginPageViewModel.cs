using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Auth;
using PasswordManagement.Services;
using PasswordManagement.Views;

namespace PasswordManagement.ViewModels;

public partial class LoginPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private string emailid;
    private readonly DatabaseServices _databaseService;
    private readonly FirestoreService _firestoreService;
    private readonly FirebaseAuthClient _firebaseAuthClient;
    public INavigation Navigation { get; set; }

    public ICommand SignUpCommand { get; set; }

    public ICommand SignInCommand { get; set; }

    public LoginPageViewModel(INavigation navigation)
    {
        SignUpCommand = new Command(async () => { await SignUp(); });
        SignInCommand = new Command(async () => { await SignIn(); });
        this.Navigation = navigation;
    }

    public LoginPageViewModel(DatabaseServices databaseServices)
    {
        _databaseService = databaseServices;
        SignUpCommand = new Command(async () => { await SignUp(); });
        SignInCommand = new Command(async () => { await SignIn(); });
    }

    public LoginPageViewModel(FirestoreService firestoreService, FirebaseAuthClient firebaseAuthClient)
    {
        _firestoreService = firestoreService;
        _firebaseAuthClient = firebaseAuthClient;
        SignUpCommand = new Command(async () => { await SignUp(); });
        SignInCommand = new Command(async () => { await SignIn(); });

    }
    public async Task SignUp()
    {
        await App.Current.MainPage.Navigation.PushAsync(new SignUpPage(_firebaseAuthClient));
    }

    public async Task SignIn()
    {
        try
        {
            if (await ValidateEntry())
            {
                var result = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(Emailid, Password);
                if (!string.IsNullOrWhiteSpace(result?.User?.Info?.Email))
                {
                    App.Current.MainPage = new AppShell(_firestoreService);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    private async Task ShowPopup(string type)
    {
        await App.Current.MainPage.DisplayAlert("Alert", $"Please enter valid {type}.", "OK");
    }
    private async Task<bool> ValidateEntry()
    {
        if (string.IsNullOrEmpty(Emailid))
        {
            await ShowPopup(nameof(Emailid));
            return false;
        }

        if (string.IsNullOrEmpty(Password))
        {
            await ShowPopup(nameof(Password));
            return false;
        }

        return true;
    }

}
