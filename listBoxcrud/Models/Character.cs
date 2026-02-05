namespace listBoxcrud.Models;

public class Character
{
    public string NoweImie = ""; // błąd z lekcji, jeżeli by się dało pole zamiast właściwości to poprzez brak get i set nie działałoby
    
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}