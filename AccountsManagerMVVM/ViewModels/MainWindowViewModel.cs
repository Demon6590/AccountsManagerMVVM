using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace AccountsManagerMVVM.ViewModels;

public class MainWindowViewModel : ViewModelBase,IScreen
{
    public ObservableCollection<ViewItem> Views => 
    [
        new ()
        {
            Name = "Авторизация",
            ViewModel = new AuthWindowViewModel()
        },
        new ()
        {
            Name = "Регистрация",
            ViewModel = new RegistrationWindowViewModel()
        },
        new ()
        {
            Name = "Восстановление доступа",
            ViewModel = new RestoringAccessWindowViewModel()
        },
    ];

    [Reactive] private ViewItem _currentViewModel;

    public MainWindowViewModel()
    {
        CurrentViewModel = Views[1];
    }
    [ReactiveCommand]
    private void SelectView(string viewName)
    {
        var targetView = Views.FirstOrDefault(v => v.Name == viewName);
        if (targetView != null)
        {
            CurrentViewModel = targetView;
        }
    }

    public RoutingState Router { get; }
}
public class ViewItem
{
    public required string Name { get; init;}
    public required ViewModelBase ViewModel { get; init; }
}