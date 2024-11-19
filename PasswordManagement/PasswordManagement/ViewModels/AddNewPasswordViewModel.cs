using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManagement.Models;
using PasswordManagement.Services;
namespace PasswordManagement.ViewModels;

public partial class AddNewPasswordViewModel : ObservableObject
{

    [ObservableProperty]
    private string id;

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

    private bool isUpdate = false;
    private int count => Password != null ? Passwords.Count : 0;

    // public ICommand RemovePassword { get; set; }
    private ObservableCollection<StoredPassword> _passwords;
    public ObservableCollection<StoredPassword> Passwords
    {
        get => _passwords;
        set => SetProperty(ref _passwords, value);
    }
    private readonly DatabaseServices _databaseService;
    private readonly FirestoreService _firestoreService1;
    // public AddNewPasswordViewModel(DatabaseServices databaseServices)
    // {
    //     _databaseService = databaseServices;
    //     Passwords = [];
    //     AddPassword = new Command(async () => { await AddNewPassword(); });
    //     Reset = new Command(ResetFields);
    //     // RemovePassword = new Command<StoredPassword> (RemovePasswordData);
    //     // Task.Run(async () => { await FetchDataFromDatabase(); }).Wait();
    // }

    public AddNewPasswordViewModel(FirestoreService firestoreService)
    {
        _firestoreService1 = firestoreService;
        Passwords = [];
        AddPassword = new Command(async () => { await AddNewPassword(); });
        Reset = new Command(ResetFields);
        //    RemovePassword = new Command<StoredPassword> (RemovePasswordData);
        Task.Run(async () => { await FetchFirestoreData(); }).Wait();
    }

    private async Task FetchFirestoreData()
    {
        var fetchPassowrd = await _firestoreService1.GetPasswords();
        if (fetchPassowrd != null && fetchPassowrd.Count > 0)
        {
            foreach (var item in fetchPassowrd)
            {
                Passwords.Add(item);
            }
        }
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
            if (isUpdate)
            {
                password.DocId = Id;
                await _firestoreService1.UpdatePassword(password);
                var found = Passwords.FirstOrDefault(x => x.DocId == Id);
                Passwords[Passwords.IndexOf(found)] = password;
                isUpdate = false;
            }
            else
            {
                // await StoreDatabase(password);
                var data = await StoreFirestoreData(password);
                password.DocId = data;
                Passwords.Add(password);
            }

            ResetFields();
        }
    }

    [RelayCommand]
    public async Task RemovePasswordData(StoredPassword password)
    {
        await _firestoreService1.RemovePassword(password);
        Passwords.Remove(password);
    }

    [RelayCommand]
    public async Task EditPasswordData(StoredPassword password)
    {
        isUpdate = true;
        Name = password.Name;
        Username = password.Username;
        Category = password.Category;
        Password = password.Password;
        Id = password.DocId;
    }

    private async Task<string> StoreFirestoreData(StoredPassword password)
    {
        return await _firestoreService1.InsertPassword(password);
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
