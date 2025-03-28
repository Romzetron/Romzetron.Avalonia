﻿using System;
using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;

namespace Romzetron.Avalonia;

/// <summary>
/// Represents the color theme class for Romzetron.Avalonia.
/// </summary>
public class RomzetronTheme : Styles
{
    //==================================================
    // Private theme resource variables.
    //==================================================

    /// <summary>
    /// Amber color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemeAmber;

    /// <summary>
    /// Blue color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemeBlue;

    /// <summary>
    /// Blue Grey color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemeBlueGrey;

    /// <summary>
    /// Brown color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemeBrown;

    /// <summary>
    /// Deep Orange color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemeDeepOrange;

    /// <summary>
    /// Deep Purple color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemeDeepPurple;

    /// <summary>
    /// Green color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemeGreen;

    /// <summary>
    /// Indigo color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemeIndigo;

    /// <summary>
    /// Orange color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemeOrange;

    /// <summary>
    /// Pink color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemePink;

    /// <summary>
    /// Purple color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemePurple;

    /// <summary>
    /// Red color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemeRed;

    /// <summary>
    /// Teal color theme resource.
    /// </summary>
    private readonly ResourceInclude _colorThemeTeal;

    /// <summary>
    /// Currently active color theme resource.
    /// </summary>
    private ResourceInclude? _colorTheme;

    //==================================================
    // Color theme styled property.
    //==================================================

    /// <summary>
    /// A styled property that holds the color theme for the application.
    /// Default value is set to <see cref="ColorTheme.Blue"/>.
    /// </summary>
    public static readonly StyledProperty<ColorTheme> ColorThemeProperty =
        AvaloniaProperty.Register<RomzetronTheme, ColorTheme>(nameof(ColorTheme), defaultValue: ColorTheme.Blue);

    /// <summary>
    /// Represents the selected color theme.
    /// The value determines the color palette used within the application.
    /// </summary>
    public ColorTheme ColorTheme
    {
        get => GetValue(ColorThemeProperty);
        set
        {
            SetValue(ColorThemeProperty, value);
            SelectColorTheme(value);
        }
    }

    //==================================================
    // Constructor.
    //==================================================

    /// <summary>
    /// RomzetronTheme is a class derived from Styles that supports applying different color themes
    /// to Avalonia applications by loading predefined color resources.
    /// </summary>
    public RomzetronTheme(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);

        var uriAmber = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemeAmber.xaml");
        var uriBlue = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemeBlue.xaml");
        var uriBlueGrey = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemeBlueGrey.xaml");
        var uriBrown = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemeBrown.xaml");
        var uriDeepOrange = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemeDeepOrange.xaml");
        var uriDeepPurple = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemeDeepPurple.xaml");
        var uriGreen = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemeGreen.xaml");
        var uriIndigo = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemeIndigo.xaml");
        var uriOrange = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemeOrange.xaml");
        var uriPink = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemePink.xaml");
        var uriPurple = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemePurple.xaml");
        var uriRed = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemeRed.xaml");
        var uriTeal = new Uri("avares://Romzetron.Avalonia/Resources/Color/ColorThemeTeal.xaml");

        _colorThemeAmber = new ResourceInclude(uriAmber) { Source = uriAmber };
        _colorThemeBlue = new ResourceInclude(uriBlue) { Source = uriBlue };
        _colorThemeBlueGrey = new ResourceInclude(uriBlueGrey) { Source = uriBlueGrey };
        _colorThemeBrown = new ResourceInclude(uriBrown) { Source = uriBrown };
        _colorThemeDeepOrange = new ResourceInclude(uriDeepOrange) { Source = uriDeepOrange };
        _colorThemeDeepPurple = new ResourceInclude(uriDeepPurple) { Source = uriDeepPurple };
        _colorThemeGreen = new ResourceInclude(uriGreen) { Source = uriGreen };
        _colorThemeIndigo = new ResourceInclude(uriIndigo) { Source = uriIndigo };
        _colorThemeOrange = new ResourceInclude(uriOrange) { Source = uriOrange };
        _colorThemePink = new ResourceInclude(uriPink) { Source = uriPink };
        _colorThemePurple = new ResourceInclude(uriPurple) { Source = uriPurple };
        _colorThemeRed = new ResourceInclude(uriRed) { Source = uriRed };
        _colorThemeTeal = new ResourceInclude(uriTeal) { Source = uriTeal };

        SelectColorTheme(ColorTheme.Blue);
    }

    //==================================================
    // Select color theme.
    //==================================================

    /// <summary>
    /// Selects and applies a new color theme to the application.
    /// </summary>
    /// <param name="colorTheme">The color theme to be applied. This parameter is of type <see cref="ColorTheme"/> and can be one of various predefined color themes.</param>
    private void SelectColorTheme(ColorTheme colorTheme)
    {
        var newColorTheme = colorTheme switch
        {
            ColorTheme.Amber => _colorThemeAmber,
            ColorTheme.Blue => _colorThemeBlue,
            ColorTheme.BlueGrey => _colorThemeBlueGrey,
            ColorTheme.Brown => _colorThemeBrown,
            ColorTheme.DeepOrange => _colorThemeDeepOrange,
            ColorTheme.DeepPurple => _colorThemeDeepPurple,
            ColorTheme.Green => _colorThemeGreen,
            ColorTheme.Indigo => _colorThemeIndigo,
            ColorTheme.Orange => _colorThemeOrange,
            ColorTheme.Pink => _colorThemePink,
            ColorTheme.Purple => _colorThemePurple,
            ColorTheme.Red => _colorThemeRed,
            ColorTheme.Teal => _colorThemeTeal,
            _ => _colorThemeBlue
        };

        if (newColorTheme == _colorTheme)
            return;

        if (_colorTheme is not null)
            Resources.MergedDictionaries.Remove(_colorTheme);

        Resources.MergedDictionaries.Insert(0, newColorTheme);
        _colorTheme = newColorTheme;
    }
}