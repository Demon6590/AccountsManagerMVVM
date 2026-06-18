using System;
using System.Reactive;
using AccountsManagerMVVM.Models;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace AccountsManagerMVVM.ViewModels;

public partial class RegistrationWindowViewModel : ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment => "registration";
    public IScreen HostScreen { get; }

    public RegistrationWindowViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }

    [Reactive] private string _lastName = string.Empty;
    [Reactive] private string _firstName = string.Empty;
    [Reactive] private string _patronymic = string.Empty;
    [Reactive] private string _email = string.Empty;
    [Reactive] private string _password = string.Empty;
    [Reactive] private string _passwordConfirm = string.Empty;

    [ReactiveCommand]
    public void Login()
    {
        if (string.IsNullOrWhiteSpace(LastName))
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(FirstName))
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(Patronymic))
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(Email))
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(Password))
        {
            return;
        }

        if (PasswordConfirm != Password)
        {
            return;
        }

        UserInsert newUser = new UserInsert(LastName, FirstName, Patronymic, Email, Password);
        App.DbPostgres.AddUser(newUser);

        var nextViewModel = new AuthWindowViewModel(HostScreen);
        HostScreen.Router.NavigateAndReset.Execute(nextViewModel);
    }


    [ReactiveCommand]
    public void Cancel()
    {
        Environment.Exit(0);
    }


    [ReactiveCommand]
    public void OpenAuthWindow()
    {
        HostScreen.Router.NavigateAndReset.Execute(new AuthWindowViewModel(HostScreen));
    }


    [ReactiveCommand]
    public void OpenRestoringAccessWindow()
    {
        HostScreen.Router.NavigateAndReset.Execute(new RestoringAccessWindowViewModel(HostScreen));
    }
}