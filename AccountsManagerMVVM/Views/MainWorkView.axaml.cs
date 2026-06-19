using AccountsManagerMVVM.ViewModels;
using ReactiveUI.Avalonia;
using ReactiveUI;


namespace AccountsManagerMVVM.Views;

public partial class MainWorkView : ReactiveUserControl<MainWorkViewModel>
{
    public MainWorkView()
    {
        InitializeComponent();
        this.WhenActivated(disposables => { });
    }
}