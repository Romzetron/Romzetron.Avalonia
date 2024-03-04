using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace Romzetron.Avalonia;

public enum ColorTheme
{
    Default,
    Amber,
    Blue,
    BlueGrey,
    Brown,
    DeepOrange,
    DeepPurple,
    Green,
    Indigo,
    Orange,
    Pink,
    Purple,
    Red,
    Teal
}

public abstract class Theme : Styles
{
    public static readonly AttachedProperty<ColorTheme> ColorThemeProperty =
        AvaloniaProperty.RegisterAttached<Theme, Control, ColorTheme>("ColorTheme");

    public static ColorTheme GetColorTheme(Control element) => element.GetValue(ColorThemeProperty);
    public static void SetColorTheme(Control element, ColorTheme value) => element.SetValue(ColorThemeProperty, value);
}