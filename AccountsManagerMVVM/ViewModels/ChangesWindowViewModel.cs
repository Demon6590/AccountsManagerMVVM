using AccountsManagerMVVM.Models;
using ReactiveUI;
using Avalonia.Interactivity;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using Avalonia.Interactivity;
namespace AccountsManagerMVVM.ViewModels;

public partial class ChangesWindowViewModel: ViewModelBase,IRoutableViewModel
{
    public string? UrlPathSegment => "changes";
    public IScreen HostScreen { get; }
    

    public ChangesWindowViewModel(IScreen hostScreen,User targetUser)
    {
        HostScreen = hostScreen;
        TargetUser = targetUser;

        LastName = targetUser.LastName;
        FirstName = targetUser.FirstName;
        Patronymic = targetUser.Patronymic;
        Email = targetUser.Email;
        Password = targetUser.Password;   
    }
    public User TargetUser { get; }
    
    [Reactive] 
    private string _lastName = string.Empty;
    [Reactive] 
    private string _firstName = string.Empty;
    [Reactive] 
    private string _patronymic = string.Empty;
    [Reactive] 
    private string _email = string.Empty;
    [Reactive] 
    private string _password = string.Empty;
    [Reactive] 
    private bool _emailHasError;
    [Reactive] 
    private bool _passwordHasError;


    [ReactiveCommand]
    public void Save()
    {
        if (string.IsNullOrWhiteSpace(FirstName))
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(LastName))
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(Patronymic))
        {
            Patronymic = "";
        }

        if (_emailHasError)
        {
            return;
        }

        if (_passwordHasError)
        {
            return;
        }
        var updatedUser = TargetUser with 
        { 
            LastName = LastName, 
            FirstName = FirstName, 
            Patronymic = Patronymic,
            Email = Email,
            Password = Password
        };


        bool success = App.DbPostgres.UpdateUser(updatedUser);

        if (success)
        {
            HostScreen.Router.NavigateBack.Execute();
        }
    }

    [ReactiveCommand]
    public void Cancel()
    {
        HostScreen.Router.NavigateBack.Execute();
    }

    
}