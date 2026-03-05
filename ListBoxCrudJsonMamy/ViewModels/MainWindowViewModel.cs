using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia;
using ListBoxCrudJsonMamy.Extensions;
using ListBoxCrudJsonMamy.Models;
using ListBoxCrudJsonMamy.Services;
using ListBoxCrudJsonMamy.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ListBoxCrudJsonMamy.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static readonly JsonSerializerOptions _options = new(){WriteIndented=true};
    private const string FilePath = "Data/characters.json";
    private readonly IDialogService _dialogService;
    public ObservableCollection<Character> Characters { get; } = [];
    
    
    [Reactive] public string NewName { get; set; }= string.Empty;
    [Reactive] public string NewRole { get; set; } = string.Empty;
    [Reactive] public string NewDescription { get; set; } = string.Empty;

    public ReactiveCommand<Unit, Unit> AddCommand { get; }
    public ReactiveCommand<Unit, Unit> SaveCommand { get; }
    public ReactiveCommand<Character, Unit> EditCommand { get; }
    public ReactiveCommand<Character, Unit> DeleteCommand { get; }
    
    public MainWindowViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;
        
        LoadCharacters();
        AddCommand = ReactiveCommand.Create(AddCharacter);
        SaveCommand = ReactiveCommand.Create(SaveToJson);
        EditCommand = ReactiveCommand.CreateFromTask<Character>(OpenEditWindowAsync);
        DeleteCommand = ReactiveCommand.CreateFromTask<Character>(DeleteCharacterAsync);
    }

    private async Task DeleteCharacterAsync(Character? character)
    {
        if (character == null) return;

        var isConfirm = await _dialogService.ShowConfirmationDialogAsync("Czy chcesz usunąć?");

        if (isConfirm)
        {
            Characters.Remove(character);
        }
    }

    private async Task OpenEditWindowAsync(Character character)
    {
        await new EditWindow
        {
            DataContext = new EditCharacterViewModel(character)
        }.ShowDialog(Application.Current!.GetMainWindow()!);
    }
    
    
    
    private void SaveToJson()
    {
        try
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(Characters, _options));
            Console.WriteLine("Characters saved to {0}", FilePath);
        }catch(Exception exception) when(exception is
                                             IOException or
                                             UnauthorizedAccessException or 
                                             JsonException
                                             ) 
        {
            Console.WriteLine($"Save exception {exception.Message}");
            
        } catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }

    private void AddCharacter()
    {
        if (new List<string> { NewName, NewRole, NewDescription }.Any(string.IsNullOrWhiteSpace))
        {
            Console.WriteLine("Wszystkie pola  muszą być wypełnione");
            return;
        }
       
        Characters.Add(new Character()
        {
           Name = NewName,
           Role = NewRole,
           Description = NewDescription
        });
       
        NewName = string.Empty;
        NewRole = string.Empty;
        NewDescription = string.Empty;
           
    }


    private void LoadCharacters()
    {
        if(!File.Exists(FilePath)) return;

        try
        {
            var jsonData =  File.ReadAllText(FilePath);
            var list = JsonSerializer.Deserialize<List<Character>>(jsonData);
            Characters.Clear();
            if (list == null) return;
            foreach (var character in list)
            {
                Characters.Add(character);
            } 
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
        
    }
    
}