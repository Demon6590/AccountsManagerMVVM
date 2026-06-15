using ReactiveUI;

namespace AccountsManagerMVVM.ViewModels;

public class MainWorkViewModel: ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment => "main-work";
    public IScreen HostScreen { get; }

    public MainWorkViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }
}