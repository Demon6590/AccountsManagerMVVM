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
    
    
}