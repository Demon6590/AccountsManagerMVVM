using ReactiveUI;

namespace AccountsManagerMVVM.ViewModels;

public partial class RegistrationWindowViewModel : ViewModelBase,IRoutableViewModel
{    
    
    public string? UrlPathSegment => "registration";
    public IScreen HostScreen { get; }
    public RegistrationWindowViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }
}