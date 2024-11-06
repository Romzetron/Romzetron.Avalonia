using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia;
using Avalonia.Dialogs;
using Avalonia.ReactiveUI;

namespace Romzetron.Avalonia.Example;

/// <summary>
/// A class containing the entry point for the Avalonia application.
/// </summary>
[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
internal class Program
{
    /// <summary>
    /// Entry point for the application.
    /// </summary>
    /// <param name="args">Command-line arguments passed to the application.</param>
    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    /// <summary>
    /// Configures and builds the Avalonia application.
    /// </summary>
    /// <returns>An instance of <see cref="AppBuilder"/> configured with the necessary settings for the application.</returns>
    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseManagedSystemDialogs()
            .LogToTrace()
            .UseReactiveUI();
    }
}