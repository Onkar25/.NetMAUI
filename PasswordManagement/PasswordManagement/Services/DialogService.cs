using System;

namespace PasswordManagement.Services;

internal class DialogService //: IDialogService
{
public Task<bool> ShowConfirmationAsync(string title, string message)
{
return Application.Current.MainPage.DisplayAlert(title, message, "ok", "no");
}

public Task ShowAlertAsync(string title, string message, string accept, string cancel)
{
return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
}

// public Task<string> ShowActionsAsync(string title, string message, string destruction, params string[] buttons)
// {
// return Application.Current.MainPage.DisplayActionSheet(title, Resources.CloseText, destruction, buttons);
// }

// public Task ToastAsync(string message, int duration)
// {
// return Application.Current.MainPage.DisplayToastAsync(message, duration);
// }

// public Task<bool> SnackBarAsync(string message, string actionText, Func<task> action)
// {
// return Application.Current.MainPage.DisplaySnackBarAsync(message, actionText, action);
// }
}