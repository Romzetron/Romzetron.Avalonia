using System.Linq;
using Avalonia;

namespace Romzetron.Avalonia.Extensions;

/// <summary>
/// Provides extension methods for working with the <see cref="Thickness"/> structure.
/// </summary>
public static class ThicknessExtensions
{
    /// <summary>
    /// Returns the maximum value among the Left, Top, Right, and Bottom components of the Thickness.
    /// If the Thickness is uniform, it returns the value of the Top component.
    /// </summary>
    /// <param name="value">The Thickness instance to evaluate.</param>
    /// <return>The maximum component value.</return>
    public static double Max(this Thickness value)
    {
        return value.IsUniform ? value.Top : new[] { value.Left, value.Top, value.Right, value.Bottom }.Max();
    }
}