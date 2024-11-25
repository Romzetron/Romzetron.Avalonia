# Romzetron.Avalonia.DataGrid Theme Library

[![GitHub License](https://img.shields.io/github/license/Romzetron/Romzetron.Avalonia)](https://github.com/Romzetron/Romzetron.Avalonia/blob/main/LICENSE.md)
[![NuGet Version](https://img.shields.io/nuget/v/Romzetron.Avalonia.DataGrid)](https://www.nuget.org/packages/Romzetron.Avalonia.DataGrid)

[Romzetron.Avalonia.DataGrid](https://github.com/Romzetron/Romzetron.Avalonia) is a UI theme library designed to work with the [Avalonia](https://avaloniaui.net) DataGrid control. The [Romzetron.Avalonia](https://github.com/Romzetron/Romzetron.Avalonia) library is a required prerequisite since it contains several control theme resources that the DataGrid theme uses.

## Installation

The [Romzetron.Avalonia.DataGrid](https://github.com/Romzetron/Romzetron.Avalonia) theme library is available on [nuget.org](https://www.nuget.org/packages/Romzetron.Avalonia.DataGrid) and can be added to your project with using the **Nuget Package Manager** within **Visual Studio** or **Jetbrains Rider**, or with the following terminal command:

```bash
dotnet add package Romzetron.Avalonia.DataGrid
```

## Applying Theme via XAML

The theme can be added to an application by modifying `App.axaml` to add `<RomzetronTheme />` and `<RomzetronThemeDataGrid />` to the `<Application.Styles>` tag. The default color theme is `Blue`.

```xml
<Application xmlns="https://github.com/avaloniaui">

    <Application.Styles>
        <RomzetronTheme />          <!-- Romzetron.Avalonia is a required prerequisite. -->
        <RomzetronThemeDataGrid />  <!-- DataGrid theme is added here. -->
    </Application.Styles>

</Application>
```