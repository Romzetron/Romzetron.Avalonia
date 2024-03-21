using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Romzetron.Avalonia.Example.Views;

namespace Romzetron.Avalonia.Example;

public class App : Application
{
    //==================================================
    // Initialize application.
    //==================================================

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    //==================================================
    // Initialization complete.
    //==================================================

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = new MainWindow();

        base.OnFrameworkInitializationCompleted();
    }
}