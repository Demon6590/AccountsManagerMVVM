using System;
using System.Linq;
using Avalonia.Interactivity;
using ReactiveUI.SourceGenerators;
namespace AccountsManagerMVVM.ViewModels;
using System;
using Avalonia.Interactivity;

using MsBox.Avalonia;
public class AuthWindowViewModel : ViewModelBase
{
    [ReactiveProperty] 
    private string _login = string.Empty;
    
    [ReactiveProperty] 
    private string _password = string.Empty;

    [ReactiveCommand]
    private void Cancel()
    {
        Environment.Exit(0);
    }

    [ReactiveCommand]
    private async  void UserLogin(object? sender, RoutedEventArgs e)
    {

        if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Поля почты и пароля не могут быть пустыми")
                .ShowAsync();
            return;
        }

        var listUsers=App.DbContext.GetAllUsers();
        if (!listUsers.Any(u => string.Equals(u.Email, Login)))
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка авторизаций", "Пользователь с такой почтой не зарегистрирован")
                .ShowAsync();
            return;
        }
        
    }
}