using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Romzetron.Avalonia.Example.Views;

namespace Romzetron.Avalonia.Example;

public class App : Application
{
    private readonly RomzetronTheme _theme = new();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        var app = (App) Current!;
        app.Styles.Add(_theme);
    }

    public void SetTheme(ColorTheme theme)
    {
        _theme.SelectColorTheme(theme);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = new MainWindow();

        base.OnFrameworkInitializationCompleted();
    }
}