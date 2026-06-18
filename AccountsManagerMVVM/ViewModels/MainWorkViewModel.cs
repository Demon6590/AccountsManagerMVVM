using System.Collections.ObjectModel;
using System.Linq;
using AccountsManagerMVVM.Models;
using ReactiveUI;

namespace AccountsManagerMVVM.ViewModels;

public class MainWorkViewModel : ViewModelBase, IRoutableViewModel
{

    public string? UrlPathSegment => "main-work";
    public IScreen HostScreen { get; }

    public MainWorkViewModel(IScreen hostScreen, User currentUser)
    {
        CurrentUser = currentUser;
        HostScreen = hostScreen;
        FilteredUsers();
    }

    public User CurrentUser { get; }
    public ObservableCollection<User> Users { get; } = new();

    private void FilteredUsers()
    {
        var usersFromDb = App.DbPostgres.GetAllUsers();

        if (CurrentUser.IsAdmin)
        {
            foreach (var user in usersFromDb)
            {
                Users.Add(user);
            }
        }
        else
        {

            var self = usersFromDb.FirstOrDefault(u => u.PersonId == CurrentUser.PersonId);
            if (self != null)
            {
                Users.Add(self);
            }
        }
    }
}