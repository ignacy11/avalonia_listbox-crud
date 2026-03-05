using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

namespace ListBoxCrudJsonMamy.Services;

public class WindowService: IWindowService 
{
    public void CloseWindow(object viewModel)
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop) return;
        desktop.Windows.FirstOrDefault(w => w.DataContext == viewModel)?.Close(); 
    }
}