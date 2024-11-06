using System;
using Avalonia.Markup.Xaml;
using Romzetron.Avalonia.Shared;

namespace Romzetron.Avalonia;

/// <summary>
/// Represents the Romzetron.Avalonia theme class.
/// </summary>
public class RomzetronTheme : RomzetronThemeBase<RomzetronTheme>
{
    //==================================================
    // Constructor.
    //==================================================

    /// <summary>
    /// Represents the custom theme for the Romzetron.Avalonia application.
    /// </summary>
    public RomzetronTheme(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);
    }
}