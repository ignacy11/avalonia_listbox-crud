using Avalonia.Controls;
using Avalonia.ReactiveUI;
using listBoxcrud.ViewModels;

namespace listBoxcrud.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }
}