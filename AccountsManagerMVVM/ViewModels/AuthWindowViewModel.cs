using System;
using System.Linq;
using Avalonia.Interactivity;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using Avalonia.Interactivity;
namespace AccountsManagerMVVM.ViewModels;


public partial class AuthWindowViewModel : ViewModelBase, IRoutableViewModel
{    
    
    public string? UrlPathSegment => "auth";
    public IScreen HostScreen { get; }
    public AuthWindowViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }

    [Reactive]
    private string _email = string.Empty;
    
    [Reactive]
    private string _password = string.Empty;
    
    
    [Reactive] 
    private bool _emailHasError;
    [Reactive]
    private bool _passwordHasError;
    
    [ReactiveCommand]
    private void UserLogin()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            return;
        }
        if (_emailHasError)
        {
            return;
        }
        if (_emailHasError)
        {
            return;
        }
        
        var listUsers = App.DbPostgres.GetAllUsers();
        
        var user = listUsers.FirstOrDefault(u => string.Equals(u.Email, Email) && string.Equals(u.Password, Password));
        if (user == null)
        {
            return;
        }

        var nextViewModel = new MainWorkViewModel(HostScreen, user);
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