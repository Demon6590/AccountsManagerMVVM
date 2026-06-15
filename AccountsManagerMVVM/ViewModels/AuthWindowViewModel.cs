using System;
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
    [ReactiveProperty] 
    private bool _canLogin = false;
    
    [ReactiveCommand]
    private void Cancel()
    {
        Environment.Exit(0);
    }

    [ReactiveCommand(CanExecute = nameof(CanLogin))]
    private async  void UserLogin(object? sender, RoutedEventArgs e)
    {

        
    }
}