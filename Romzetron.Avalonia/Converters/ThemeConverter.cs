using System;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace Romzetron.Avalonia.Converters;

public class ThemeConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        return value is not null && value.Equals(parameter);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        if (value is null || parameter is null)
            return BindingOperations.DoNothing;
        
        return value.Equals(true) ? (ColorTheme)parameter : BindingOperations.DoNothing;
    }
}
