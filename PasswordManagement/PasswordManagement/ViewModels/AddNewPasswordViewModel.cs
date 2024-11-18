using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using PasswordManagement.Models;
using PasswordManagement.Services;
namespace PasswordManagement.ViewModels;

[ObservableObject]
public partial class AddNewPasswordViewModel
{
    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private string category;

    public ICommand AddPassword { get; set; }
    public ICommand Reset { get; set; }
    private ObservableCollection<StoredPassword> _passwords;
    public ObservableCollection<StoredPassword> Passwords
    {
        get => _passwords;
        set => SetProperty(ref _passwords, value);
    }
    private readonly DatabaseServices _databaseService;
    public AddNewPasswordViewModel(DatabaseServices databaseServices)
    {
        _databaseService = databaseServices;
        Passwords = [];
        AddPassword = new Command(async () => { await AddNewPassword(); });
        Reset = new Command(ResetFields);
        Task.Run(async () => { await FetchDataFromDatabase(); }).Wait();
    }

    private async Task FetchDataFromDatabase()
    {
        var fetchPassowrd = await _databaseService.GetStoredPasswordsAsync();
        if (fetchPassowrd != null && fetchPassowrd.Count > 0)
        {
            foreach (var item in fetchPassowrd)
            {
                Passwords.Add(item);
            }
        }
    }

    private async Task AddNewPassword()
    {
        if (await ValidateEntry())
        {
            StoredPassword password = new StoredPassword { Name = Name, Username = Username, Category = Category, Password = Password };
            await StoreDatabase(password);
            Passwords.Add(password);
            ResetFields();
        }
    }

    private async Task StoreDatabase(StoredPassword password)
    {
        await _databaseService.InsertPasswordData(password);
    }

    private void ResetFields()
    {
        Name = string.Empty;
        Username = string.Empty;
        Category = string.Empty;
        Password = string.Empty;
    }


    private async Task<bool> ValidateEntry()
    {
        if (string.IsNullOrEmpty(Name))
        {
            await ShowPopup(nameof(Name));
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

        if (string.IsNullOrEmpty(Category))
        {
            await ShowPopup(nameof(Category));
            return false;
        }

        return true;
    }

    private async Task ShowPopup(string type)
    {
        await App.Current.MainPage.DisplayAlert("Alert", $"Please enter valid {type}.", "OK");
    }
}
