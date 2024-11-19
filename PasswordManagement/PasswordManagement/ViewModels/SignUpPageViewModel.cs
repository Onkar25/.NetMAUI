using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Auth;

namespace PasswordManagement.ViewModels;

public partial class SignUpPageViewModel : ObservableObject
{
    // [ObservableProperty]
    // private SignUp _signUp = new();

    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private string emailid;

    public ICommand AddPassword { get; set; }
    public ICommand Reset { get; set; }
    private readonly FirebaseAuthClient _firebaseAuthClient;
    public SignUpPageViewModel(FirebaseAuthClient firebaseAuthClient)
    {
        _firebaseAuthClient = firebaseAuthClient;
        AddPassword = new Command(async () => { await AddNewPassword(); });
        Reset = new Command(async () => { await ResetFields(); });
    }

    private async Task ResetFields()
    {
        await App.Current.MainPage.Navigation.PopAsync();
    }

    private async Task AddNewPassword()
    {
        try
        {
            if (await ValidateEntry())
            {
                //    _signUp= new SignUp { EmailId = Emailid, Username = Username, Password = Password };
                var result = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(Emailid, Password, Username);
                await ResetFields();
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


        if (string.IsNullOrEmpty(Username))
        {
            await ShowPopup(nameof(Username));
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


