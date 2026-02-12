using ReactiveUI.Fody.Helpers;

namespace listBoxcrud.Models;

public class Character
{
    public string NoweImie = ""; // błąd z lekcji, jeżeli by się dało pole zamiast właściwości to poprzez brak get i set nie działałoby
    
    [Reactive] public string Name { get; set; } = string.Empty;
    [Reactive] public string Role { get; set; } = string.Empty;
    [Reactive] public string Description { get; set; } = string.Empty;
}