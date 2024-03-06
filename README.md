# Romzetron.Avalonia Theme Library

[![GitHub License](https://img.shields.io/github/license/Romzetron/Romzetron.Avalonia)](https://github.com/Romzetron/Romzetron.Avalonia/blob/main/LICENSE.md)
[![NuGet Version](https://img.shields.io/nuget/v/Romzetron.Avalonia)](https://www.nuget.org/packages/Romzetron.Avalonia)

[Romzetron.Avalonia](https://github.com/Romzetron/Romzetron.Avalonia) is a UI theme library designed to work with the [Avalonia](https://avaloniaui.net) cross-platform UI framework.
Light and dark modes are supported, and one of several color themes can be chosen that apply to most controls. Some of the controls can have their color set explicitly to override
the theme color.

![](https://raw.githubusercontent.com/Romzetron/Romzetron.Avalonia/main/Images/RometronAvaloniaExample.png)

## Installation

The [Romzetron.Avalonia](https://github.com/Romzetron/Romzetron.Avalonia) theme library is available on [nuget.org](https://www.nuget.org/packages/Romzetron.Avalonia) and can be added to your
project with using the **Nuget Package Manager** within **Visual Studio** or **Jetbrains Rider**, or with the following terminal command:

```bash
dotnet add package Romzetron.Avalonia
```

## Usage

The theme can be added to an application by modifying `App.axaml.cs` to create and instance of the theme style that can be added to the `App` styles.

```csharp
public class App : Application
{
    // Create instance of the theme library.
    private readonly RomzetronTheme _theme = new();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        
        // Get the current application instance.
        var app = (App) Current!;
        
        // Add theme to the application styles.
        app.Styles.Add(_theme);
    }
    
    // Optional function that can be used to change the theme color at runtime.
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
```

The theme supports dark and light variations that can be set explicitly or to follow the system theme. Set the **RequestedThemeVariant** tag in `App.axaml` to one of the following values.

```xml
<Application
    xmlns="https://github.com/avaloniaui"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:Romzetron.Avalonia.Example"
    x:Class="Romzetron.Avalonia.Example.App"
    RequestedThemeVariant="Default">  <!-- Set the requested theme variant to Light, Dark, or Default (system theme). -->

    <Application.DataTemplates>
        <local:ViewLocator />
    </Application.DataTemplates>

</Application>
```

## Example Application

An example application is included in the solution that demonstrates the look & feel of most of the controls. I may add more detail in the front end of the example application
that explains how to customize the controls, but for now the best method to figure out how things work is to look at the source code.