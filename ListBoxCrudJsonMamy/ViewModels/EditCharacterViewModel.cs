using System.Linq;
using System.Reactive;
using Avalonia.Controls.ApplicationLifetimes;
using ListBoxCrudJsonMamy.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ListBoxCrudJsonMamy.ViewModels;

public class EditCharacterViewModel : ViewModelBase
{
    private readonly Character _character;
    
    [Reactive] public string Name { get; set; } = string.Empty;
    [Reactive] public string Role { get; set; } = string.Empty;
    [Reactive] public string Description { get; set; } = string.Empty;
    
    public ReactiveCommand<Unit, Unit> SaveCommand { get; }
    public ReactiveCommand<Unit, Unit> CancelCommand { get; }


    public EditCharacterViewModel(Character character)
    {
        _character = character;
        
        Name = _character.Name;
        Role = _character.Role;
        Description = _character.Description;

        var isValid = this.WhenAnyValue(
            x => x.Name,
            x => x.Role,
            x => x.Description,
            (n, r, d) =>
                !string.IsNullOrWhiteSpace(n)
                && !string.IsNullOrWhiteSpace(r)
                && !string.IsNullOrWhiteSpace(d)
        );
        
        SaveCommand = ReactiveCommand.Create(() =>
        {
            _character.Name = Name.Trim();
            _character.Role = Role.Trim();
            _character.Description = Description.Trim();
            CloseWindow();

        }, isValid );

        CancelCommand = ReactiveCommand.Create(CloseWindow);
    }

    private void CloseWindow()
    {
        App.WindowService!.CloseWindow(this); 
    }
}