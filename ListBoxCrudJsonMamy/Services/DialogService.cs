using System.Threading.Tasks;
using Avalonia;
using ListBoxCrudJsonMamy.Extensions;
using ListBoxCrudJsonMamy.ViewModels;
using ListBoxCrudJsonMamy.Views;

namespace ListBoxCrudJsonMamy.Services;

public class DialogService : IDialogService
{
    public async Task<bool> ShowConfirmationDialogAsync(string message)
    {
        var viewModel = new ConfirmationWindowViewModel(message);
        var window = new ConfirmationWindow
        {
            DataContext = viewModel
        };

        var mainWindow = Application.Current?.GetMainWindow();
        var result = await window.ShowDialog<bool>(mainWindow!);
        
        return result;
    }
}