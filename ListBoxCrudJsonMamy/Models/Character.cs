using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ListBoxCrudJsonMamy.Models;

public class Character : ReactiveObject
{
    
    [Reactive] public string Name { get; set; } = string.Empty;
    [Reactive] public string Role { get; set; } = string.Empty;
    [Reactive] public string Description { get; set; } =  string.Empty;
}