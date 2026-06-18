using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace AccountsManagerMVVM.ViewModels;

public partial class MainWindowViewModel : ViewModelBase,IScreen
{
    public RoutingState Router { get; } = new ();

    public MainWindowViewModel()
    {
        Router.NavigateAndReset.Execute(new AuthWindowViewModel(this));
    }
}
