using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;

namespace Romzetron.Avalonia.Example.Views.Tabs;

public partial class TabAdornerLayer : UserControl
{
    //==================================================
    // Private variables.
    //==================================================

    private Control? _adorner;

    //==================================================
    // Constructor.
    //==================================================

    public TabAdornerLayer()
    {
        InitializeComponent();
    }

    //==================================================
    // Remove adorner button click event handler.
    //==================================================

    private void RemoveAdorner_OnClick(object? sender, RoutedEventArgs e)
    {
        var adornerButton = this.FindControl<Button>("AdornerButton");

        if (adornerButton is null)
            return;

        var adorner = AdornerLayer.GetAdorner(adornerButton);

        if (adorner is not null)
            _adorner = adorner;

        AdornerLayer.SetAdorner(adornerButton, null);
    }

    //==================================================
    // Add adorner button click event handler.
    //==================================================

    private void AddAdorner_OnClick(object? sender, RoutedEventArgs e)
    {
        var adornerButton = this.FindControl<Button>("AdornerButton");

        if (adornerButton is null)
            return;

        if (_adorner is not null)
            AdornerLayer.SetAdorner(adornerButton, _adorner);
    }
}