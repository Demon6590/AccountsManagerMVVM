using System;
using System.IO;
using System.Reflection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AccountsManagerMVVM.ViewModels;
using AccountsManagerMVVM.Views;
using ReactiveUI;
using ReactiveUI.Avalonia;
using Splat;

namespace AccountsManagerMVVM;

public partial class App : Application
{
    //public static DbContext DbContext = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets","accounts.db"));
    
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {

        Locator.CurrentMutable.Register(() => new AvaloniaActivationForViewFetcher(),
            typeof(IActivationForViewFetcher));
    

        Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {

            var mainWindowViewModel = new MainWindowViewModel();

            desktop.MainWindow = new MainWindow
            {
                DataContext = mainWindowViewModel,
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}