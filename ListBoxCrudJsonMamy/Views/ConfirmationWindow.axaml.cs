using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ListBoxCrudJsonMamy.ViewModels;

namespace ListBoxCrudJsonMamy.Views;

public partial class ConfirmationWindow : Window
{
    public ConfirmationWindow()
    {
        InitializeComponent();
    }

    // override metody OnOpened 
    protected override void OnOpened(EventArgs e)
    {
        if (DataContext is ConfirmationWindowViewModel vm)
        {
            vm.ConfirmCommand.Subscribe(result =>
            {
                Close(result);
            });
            
            vm.CancelCommand.Subscribe(result =>
            {
                Close(result);
            });
        }
    }
}