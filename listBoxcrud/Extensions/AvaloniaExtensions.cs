using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace listBoxcrud.Extensions;

public static class AvaloniaExtensions // rozszerzenie klasy Application, klasa statyczna
{
    /*
     * 
    nasza metoda jest `public static`
    jej pierwszym argumentem jest `this`:
        w języku C# słowo kluczowe `this` przed pierwszym argumentem metody statycznej zmienia sposób, w jaki możemy z niej korzystać.
        powoduje, że ta metoda jest metodą rozszerzającą
        czyli znaczy to samo co:
            "Dodaj tę metodę jako metodę instancyjną do klasy Application"
     */
    public static Window? GetMainWindow(this Application app)
        => (app.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime )?.MainWindow;
    // pierwszy `?` jest po to że window może nie istnieć i zwrócić null
    // drugi `?` jest po to,
}