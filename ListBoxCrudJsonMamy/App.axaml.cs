using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ListBoxCrudJsonMamy.Services;
using ListBoxCrudJsonMamy.ViewModels;
using ListBoxCrudJsonMamy.Views;

namespace ListBoxCrudJsonMamy;

public partial class App : Application
{
    public static IWindowService? WindowService { get; private set; }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        WindowService = new WindowService();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            IDialogService myDialogService = new DialogService();
            var mainViewModel = new MainWindowViewModel(myDialogService);
            
            desktop.MainWindow = new MainWindow
            {
                DataContext =mainViewModel,
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}