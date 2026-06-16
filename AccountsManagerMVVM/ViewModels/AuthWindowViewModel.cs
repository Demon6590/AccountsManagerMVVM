using System;
using System.Linq;
using Avalonia.Interactivity;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
namespace AccountsManagerMVVM.ViewModels;
using System;
using Avalonia.Interactivity;

public partial class AuthWindowViewModel : ViewModelBase, IRoutableViewModel
{    
    
    public string? UrlPathSegment => "auth";
    public IScreen HostScreen { get; }
    public AuthWindowViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }

    [Reactive]
    private string _login = string.Empty;
    
    [Reactive]
    private string _password = string.Empty;
}