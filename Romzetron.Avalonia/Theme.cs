using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace Romzetron.Avalonia;

public abstract class Theme : Styles
{
    //==================================================
    // Properties.
    //==================================================

    public static ColorTheme[] Colors { get; }

    public static readonly AttachedProperty<ColorTheme> ColorThemeProperty =
        AvaloniaProperty.RegisterAttached<Theme, Control, ColorTheme>("ColorTheme");

    //==================================================
    // Static constructor.
    //==================================================

    static Theme()
    {
        Colors =
        [
            ColorTheme.Default,
            ColorTheme.Amber,
            ColorTheme.Blue,
            ColorTheme.BlueGrey,
            ColorTheme.Brown,
            ColorTheme.DeepOrange,
            ColorTheme.DeepPurple,
            ColorTheme.Green,
            ColorTheme.Indigo,
            ColorTheme.Orange,
            ColorTheme.Pink,
            ColorTheme.Purple,
            ColorTheme.Red,
            ColorTheme.Teal
        ];
    }

    //==================================================
    // Get color theme.
    //==================================================

    public static ColorTheme GetColorTheme(Control element)
    {
        return element.GetValue(ColorThemeProperty);
    }

    //==================================================
    // Set color theme.
    //==================================================

    public static void SetColorTheme(Control element, ColorTheme value)
    {
        element.SetValue(ColorThemeProperty, value);
    }
}