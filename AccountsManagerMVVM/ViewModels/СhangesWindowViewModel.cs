using AccountsManagerMVVM.Models;
using ReactiveUI;

namespace AccountsManagerMVVM.ViewModels;

public partial class СhangesWindowViewModel: ViewModelBase,IRoutableViewModel
{
    public string? UrlPathSegment => "changes";
    public IScreen HostScreen { get; }

    public СhangesWindowViewModel(IScreen hostScreen,User targetUser)
    {
        HostScreen = hostScreen;


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
    public void GoBack()
    {
        HostScreen.Router.NavigateBack.Execute();
    }

    
}