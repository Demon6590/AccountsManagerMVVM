using System;
using System.Linq;
using Avalonia.Interactivity;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
namespace AccountsManagerMVVM.ViewModels;
using System;
using Avalonia.Interactivity;

public partial class AuthWindowViewModel : ViewModelBase, IRoutableViewModel
{    
    
    public string? UrlPathSegment => "auth";
    public IScreen HostScreen { get; }
    public AuthWindowViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }

    [Reactive]
    private string _login = string.Empty;
    
    [Reactive]
    private string _password = string.Empty;
    [ReactiveCommand]
    private void UserLogin()
    {
        if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
        {
            return;
        }
        
        var listUsers = App.DbPostgres.GetAllUsers();
        if (!listUsers.Any(u => string.Equals(u.Email, Login)))
        {
            return;
        }

        var nextViewModel = new MainWorkViewModel(HostScreen);
        HostScreen.Router.NavigateAndReset.Execute(nextViewModel);
    }
    [ReactiveCommand]
    private void Cancel()
    {
        Environment.Exit(0);
    }
    [ReactiveCommand]
    private void OpenRegistration()
    {
        var registerVm = new RegistrationWindowViewModel(HostScreen);
        HostScreen.Router.Navigate.Execute(registerVm);
    }

    [ReactiveCommand]
    private void OpenRestoringAccess()
    {
        var restoreVm = new RestoringAccessWindowViewModel(HostScreen);
        HostScreen.Router.Navigate.Execute(restoreVm);
    }
}