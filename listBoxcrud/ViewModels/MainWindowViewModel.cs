using System.Collections.ObjectModel;
using System.IO;
using listBoxcrud.Models;

namespace listBoxcrud.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private const string FilePath = "Data/characters.json";
    public ObservableCollection<Character> Characters { get; } = [];

    public MainWindowViewModel()
    {
        LoadCharacters();
    }

    private void LoadCharacters()
    {
        if (!File.Exists(FilePath)) return;
    }
}