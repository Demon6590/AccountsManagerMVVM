using AccountsManagerMVVM.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI.Avalonia;

namespace AccountsManagerMVVM.Views;

public partial class ChangesWindowView :  ReactiveUserControl<ChangesWindowViewModel>
{
    public ChangesWindowView()
    {
        InitializeComponent();
    }
}