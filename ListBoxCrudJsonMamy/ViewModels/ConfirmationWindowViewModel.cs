using System;
using System.Reactive;
using ReactiveUI;

namespace ListBoxCrudJsonMamy.ViewModels;

public class ConfirmationWindowViewModel : ViewModelBase
{
   public string Message { get; }
   
   public ReactiveCommand<Unit, bool> ConfirmCommand { get; }
   public ReactiveCommand<Unit, bool> CancelCommand { get; }
   
   
   public ConfirmationWindowViewModel(string message)
   {
      Message = message;
      ConfirmCommand = ReactiveCommand.Create(() =>
      {
         Console.WriteLine("Clicked confirm button");
         return true;
      });
      CancelCommand = ReactiveCommand.Create(() =>
      {
         Console.WriteLine("Clicked cancel button");
         return false;
      });
   }
}