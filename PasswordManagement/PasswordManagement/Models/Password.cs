using System;
using PasswordManagement.ViewModels;
using SQLite;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PasswordManagement.Models;

[Table("stored_password")]
[ObservableObject]
public partial class StoredPassword
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string _username;
    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private string category;

}
