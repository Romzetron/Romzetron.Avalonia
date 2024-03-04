using System;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;

namespace Romzetron.Avalonia;

public class RomzetronTheme : Styles
{
    private readonly ResourceInclude _colorThemeAmber;
    private readonly ResourceInclude _colorThemeBlue;
    private readonly ResourceInclude _colorThemeBlueGrey;
    private readonly ResourceInclude _colorThemeBrown;
    private readonly ResourceInclude _colorThemeDeepOrange;
    private readonly ResourceInclude _colorThemeDeepPurple;
    private readonly ResourceInclude _colorThemeGreen;
    private readonly ResourceInclude _colorThemeIndigo;
    private readonly ResourceInclude _colorThemeOrange;
    private readonly ResourceInclude _colorThemePink;
    private readonly ResourceInclude _colorThemePurple;
    private readonly ResourceInclude _colorThemeRed;
    private readonly ResourceInclude _colorThemeTeal;
    private ResourceInclude? _ColorTheme;

    public RomzetronTheme(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);

        var uriAmber = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemeAmber.xaml");
        var uriBlue = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemeBlue.xaml");
        var uriBlueGrey = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemeBlueGrey.xaml");
        var uriBrown = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemeBrown.xaml");
        var uriDeepOrange = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemeDeepOrange.xaml");
        var uriDeepPurple = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemeDeepPurple.xaml");
        var uriGreen = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemeGreen.xaml");
        var uriIndigo = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemeIndigo.xaml");
        var uriOrange = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemeOrange.xaml");
        var uriPink = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemePink.xaml");
        var uriPurple = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemePurple.xaml");
        var uriRed = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemeRed.xaml");
        var uriTeal = new Uri(@"avares://Romzetron.Avalonia/Resources/Color/ColorThemeTeal.xaml");

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

    public void SelectColorTheme(ColorTheme colorTheme)
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

        if (newColorTheme == _ColorTheme)
            return;

        if (_ColorTheme is not null)
            Resources.MergedDictionaries.Remove(_ColorTheme);

        Resources.MergedDictionaries.Insert(0, newColorTheme);
        _ColorTheme = newColorTheme;
    }
}