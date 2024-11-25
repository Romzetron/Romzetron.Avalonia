using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace Romzetron.Avalonia.Converters;

/// <summary>
/// The ThemeConverter class is responsible for converting between ColorTheme enumerations
/// and their corresponding boolean values for data binding purposes in Avalonia UI.
/// </summary>
public class ThemeConverter : IValueConverter
{
    /// <summary>
    /// Converts the input value and parameter to a boolean indicating whether they are equal.
    /// </summary>
    /// <param name="value">The value produced by the binding source.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <return>Returns true if the value is equal to the parameter; otherwise, false.</return>
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is not null && value.Equals(parameter);
    }

    /// <summary>
    /// Converts a Boolean value back to its corresponding ColorTheme enum value.
    /// </summary>
    /// <param name="value">The Boolean value to be converted back.</param>
    /// <param name="targetType">The target type of the conversion (expected to be ColorTheme).</param>
    /// <param name="parameter">Additional parameter used in the conversion, expected to be a ColorTheme value.</param>
    /// <param name="culture">The culture to be used in the conversion.</param>
    /// <returns>The converted ColorTheme value if <paramref name="value"/> is true and <paramref name="parameter"/> is not null; otherwise, BindingOperations.DoNothing.</returns>
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null || parameter is null)
            return BindingOperations.DoNothing;

        return value.Equals(true) ? (ColorTheme) parameter : BindingOperations.DoNothing;
    }
}