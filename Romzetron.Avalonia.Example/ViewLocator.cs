using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Romzetron.Avalonia.Example.ViewModels;

namespace Romzetron.Avalonia.Example;

/// <summary>
/// Represents a data template that locates and builds the appropriate view for a given view model.
/// </summary>
public class ViewLocator : IDataTemplate
{
    /// <summary>
    /// Builds a control instance corresponding to a given ViewModel.
    /// </summary>
    /// <param name="data">The ViewModel instance for which to create the view.</param>
    /// <returns>Returns an instance of the corresponding View or a TextBlock indicating the view was not found.</returns>
    public Control Build(object? data)
    {
        var name = data?.GetType().FullName!.Replace("ViewModel", "View");
        var type = Type.GetType(name ?? string.Empty);

        if (type != null)
            return (Control) Activator.CreateInstance(type)!;

        return new TextBlock { Text = "Not Found: " + name };
    }

    /// <summary>
    /// Determines whether the specified object is of type ViewModelBase.
    /// </summary>
    /// <param name="data">The object to check.</param>
    /// <returns>True if the specified object is of type ViewModelBase; otherwise, false.</returns>
    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}