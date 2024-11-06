using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace Romzetron.Avalonia.Shared;

/// <summary>
/// The Theme class is an abstract class that extends Avalonia's Styles class.
/// It provides methods and properties for managing color themes in a user interface.
/// </summary>
public abstract class Theme : Styles
{
    //==================================================
    // Properties.
    //==================================================

    /// <summary>
    /// A static property representing an array of pre-defined color themes available in the application.
    /// </summary>
    /// <remarks>
    /// The available color themes include:
    /// <list type="bullet">
    /// <item>Default</item>
    /// <item>Amber</item>
    /// <item>Blue</item>
    /// <item>BlueGrey</item>
    /// <item>Brown</item>
    /// <item>DeepOrange</item>
    /// <item>DeepPurple</item>
    /// <item>Green</item>
    /// <item>Indigo</item>
    /// <item>Orange</item>
    /// <item>Pink</item>
    /// <item>Purple</item>
    /// <item>Red</item>
    /// <item>Teal</item>
    /// </list>
    /// </remarks>
    public static ColorTheme[] Colors { get; }

    /// <summary>
    /// Represents an attached property that allows setting a color theme
    /// on a control. This can be used to apply different color schemes
    /// to the controls in an Avalonia application.
    /// </summary>
    /// <remarks>
    /// The available color themes are defined in the <see cref="ColorTheme"/>
    /// enum, which includes themes such as Amber, Blue, Green, Red, etc.
    /// This property is intended for use with the Avalonia UI framework.
    /// </remarks>
    public static readonly AttachedProperty<ColorTheme> ColorThemeProperty =
        AvaloniaProperty.RegisterAttached<Theme, Control, ColorTheme>("ColorTheme");

    //==================================================
    // Static constructor.
    //==================================================

    /// <summary>
    /// Represents an abstract base class for defining theme styles in an Avalonia application.
    /// </summary>
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

    /// <summary>
    /// Gets the color theme of a specified control.
    /// </summary>
    /// <param name="element">The control from which to get the color theme.</param>
    /// <returns>The color theme applied to the specified control.</returns>
    public static ColorTheme GetColorTheme(Control element)
    {
        return element.GetValue(ColorThemeProperty);
    }

    //==================================================
    // Set color theme.
    //==================================================

    /// <summary>
    /// Sets the color theme for the specified control.
    /// </summary>
    /// <param name="element">The control for which to set the color theme.</param>
    /// <param name="value">The color theme to set.</param>
    public static void SetColorTheme(Control element, ColorTheme value)
    {
        element.SetValue(ColorThemeProperty, value);
    }
}