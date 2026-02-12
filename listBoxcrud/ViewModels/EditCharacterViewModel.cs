using System.Reactive;
using listBoxcrud.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace listBoxcrud.ViewModels;

public class EditCharacterViewModel : ViewModelBase
{
    private readonly Character _character;
    
    [Reactive] public string Name { get; set; } = string.Empty;
    [Reactive] public string Role { get; set; } = string.Empty;
    [Reactive] public string Description { get; set; } = string.Empty;
    
    public ReactiveCommand<Unit, Unit> SaveCommand { get; }
    public ReactiveCommand<Unit, Unit> CancelCommand { get; }

    public EditCharacterViewModel()
    {
        _character = character;

        Name = _character.Name;
        Role = _character.Role;
        Description = _character.Description;

        var isValid = this.WhenAnyValue(
            x => x.Name,
            x => x.Role,
            x => x.Description,
            (name, role, description) =>
                // ...
                )
        
        SaveCommand = ReactiveCommand.Create(() =>
        {

        }, isValid);
    }
}
