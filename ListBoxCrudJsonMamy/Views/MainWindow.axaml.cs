using Avalonia.Controls;
using ListBoxCrudJsonMamy.ViewModels;
using ReactiveUI.Avalonia;

namespace ListBoxCrudJsonMamy.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel> 
{
    public MainWindow()
    {
        InitializeComponent();
    }
}