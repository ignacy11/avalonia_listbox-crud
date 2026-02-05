using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text.Json;
using Avalonia.Controls.Primitives;
using Avalonia.Media.TextFormatting;
using listBoxcrud.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace listBoxcrud.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static readonly JsonSerializerOptions _options = new() {WriteIndented = true}; // odpowiada za formatowanie JSON
    private const string FilePath = "Data/characters.json";
    
    public ObservableCollection<Character> Characters { get; } = [];
    
    [Reactive] public string NewName { get; set; } = string.Empty;
    [Reactive] public string NewRole { get; set; } = string.Empty;
    [Reactive] public string NewDescription { get; set; } = string.Empty;

    
    public ReactiveCommand<Unit,Unit> AddCommand { get; }
    
    public ReactiveCommand<Unit,Unit> SaveCommand { get; } 
    
    public MainWindowViewModel()
    {
        LoadCharacters();
        AddCommand = ReactiveCommand.Create(AddCharacter);
        SaveCommand = ReactiveCommand.Create(SavetoJson);
    }

    private void AddCharacter()
    {
        if (new List<string>
            {
                NewName,
                NewRole,
                NewDescription
            }.Any(string.IsNullOrWhiteSpace)) // `.Any()` pozwala na sprawdzenie jakiegokolwiek warunku przekazanego jako argument
        {
            Console.WriteLine("Wszystkie pola muszą być wypełnione");
        }


        var newCharacter = new Character()
        {
            Name = NewName,
            Role = NewRole,
            Description = NewDescription
        };
        
        Characters.Add(newCharacter);
        NewName = string.Empty;
        NewRole = string.Empty;
        NewDescription = string.Empty;
    }
    
    private void SavetoJson()
    {
        try
        {
            // serializacja danych (zamiana realnego obiektu czyli w tym przypadku ObservableCollection na)
            File.WriteAllText(FilePath, JsonSerializer.Serialize(Characters, _options));
            Console.WriteLine("Characters saved to {0}", FilePath);
        }
        // ten blok catch jest bardziej precyzyjny niż ten następny, istnieje po to aby zdefiniować 2 różne zachowania podczas obsługi błędu
        catch (Exception exception) when(exception is IOException or UnauthorizedAccessException or JsonException)
        {
            Console.WriteLine($"Save exception {exception.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private void LoadCharacters()
    {
        if (!File.Exists(FilePath)) return;
        
        try
        {
            var jsonData = File.ReadAllText(FilePath); // reads the entire JSON file from `data/characters.json` into a string named `jsonData`
            var list = JsonSerializer.Deserialize<List<Character>>(jsonData); // attempts to convert (deserialize) that JSON string into a List<Character>
            Characters.Clear(); // empties the current ObservableCollection so you don’t keep old items when reloading
            if (list == null) return; // if deserialization failed or produced no list, exit the method early.
            foreach (var character in list) // Iterates over each in the list and adds it to `ObservableCollection<Character> Characters`
            {
                Characters.Add(character); // Each `Add` triggers UI updates because `Characters` is an `ObservableCollection`
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}