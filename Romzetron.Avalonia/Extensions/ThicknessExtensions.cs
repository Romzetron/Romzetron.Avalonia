#region References

using System.Linq;
using Avalonia;

#endregion

namespace Romzetron.Avalonia.Extensions;

public static class ThicknessExtensions
{
    #region Methods

    public static double Max(this Thickness value)
    {
        return value.IsUniform ? value.Top : new[] { value.Left, value.Top, value.Right, value.Bottom }.Max();
    }

    #endregion
}