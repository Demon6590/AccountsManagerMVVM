using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using AccountsManagerMVVM.Models;
using ReactiveUI;
using ReactiveUI.SourceGenerators;


namespace AccountsManagerMVVM.ViewModels;

public partial class MainWorkViewModel : ViewModelBase, IRoutableViewModel
{

    public string? UrlPathSegment => "main-work";
    public IScreen HostScreen { get; }

    public MainWorkViewModel(IScreen hostScreen, User currentUser)
    {
        CurrentUser = currentUser;
        HostScreen = hostScreen;
        FilteredUsers();
        this.WhenAnyValue(x => x.SelectedUser)
            .Where(user=>user != null)
            .Subscribe(user =>
            {
                if (user != null)
                {

                    var editViewModel = new ChangesWindowViewModel(HostScreen, user);
                    HostScreen.Router.Navigate.Execute(editViewModel);
                    
                    SelectedUser = null; 
                }
            });
    }
    [Reactive] private User? _selectedUser;
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