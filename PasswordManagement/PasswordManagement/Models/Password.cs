using System;
using PasswordManagement.ViewModels;
using SQLite;

namespace PasswordManagement.Models;

[Table("stored_password")]
public class StoredPassword : BaseViewModel
{
    private int _id;
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }
     
    private string _name;
    [Column("name")]
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);

    }

    private string _username;
    [Column("username")]
    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }

    private string _password;
     [Column("password")]
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    private string _category;
     [Column("category")]
    public string Category
    {
        get => _category;
        set => SetProperty(ref _category, value);
    }
}
