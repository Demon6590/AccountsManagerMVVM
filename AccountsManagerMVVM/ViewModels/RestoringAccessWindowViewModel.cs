using ReactiveUI;

namespace AccountsManagerMVVM.ViewModels;

public partial class RestoringAccessWindowViewModel : ViewModelBase,IRoutableViewModel
{    
    
    public string? UrlPathSegment => "restoring-access";
    public IScreen HostScreen { get; }

    public RestoringAccessWindowViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }
}