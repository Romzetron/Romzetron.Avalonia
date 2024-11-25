using System;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Romzetron.Avalonia.DataGrid;

/// <summary>
/// Provides styling and theming for the Romzetron.Avalonia DataGrid component.
/// </summary>
public class RomzetronThemeDataGrid : Styles
{
    //==================================================
    // Constructor.
    //==================================================

    /// <summary>
    /// RomzetronThemeDataGrid is a class derived from Styles that facilitates applying
    /// various predefined color themes to Avalonia DataGrid controls. It provides a set of
    /// predefined color themes that can be easily switched.
    /// </summary>
    public RomzetronThemeDataGrid(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);
    }
}