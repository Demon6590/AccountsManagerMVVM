using System.Linq;
using System.Xml.Linq;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace AccountsManagerMVVM.ViewModels;

public partial class RestoringAccessWindowViewModel : ViewModelBase,IRoutableViewModel
{    
    
    public string? UrlPathSegment => "restoring-access";
    public IScreen HostScreen { get; }

    public RestoringAccessWindowViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }
    [Reactive]
    private string _email = string.Empty;


    [ReactiveCommand]
    public void RecoverPassword()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            return;
        }
        var listUsers = App.DbPostgres.GetAllUsers();

        var user = listUsers.FirstOrDefault(u => string.Equals(u.Email, Email));
        if (user == null)
        {
            return;
        }
        var newUser = user with { Password = "Temp1234" };
        bool updateUser = App.DbPostgres.UpdateUser(newUser);
        if (!updateUser)
        {
            return;
        }
        var nextViewModel = new AuthWindowViewModel(HostScreen);
        HostScreen.Router.NavigateAndReset.Execute(nextViewModel);
    }

    [ReactiveCommand]
    public void OpenPreviousWindow()
    {
        HostScreen.Router.NavigateBack.Execute();
    }
    
}