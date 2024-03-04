using System;
using Avalonia.Controls;

namespace Romzetron.Avalonia.Example.Views.Tabs;

public partial class TabButtonSpinner : UserControl
{
    //==================================================
    // Private variables.
    //==================================================

    private readonly string[] _mountains =
    {
        "Apple",
        "Banana",
        "Blueberry",
        "Cherry",
        "Grape",
        "Orange",
        "Mango",
        "Raspberry",
        "Watermelon"
    };

    //==================================================
    // Constructor.
    //==================================================

    public TabButtonSpinner()
    {
        InitializeComponent();
    }

    //==================================================
    // Spin button click event handler.
    //==================================================

    public void OnSpin(object sender, SpinEventArgs e)
    {
        var spinner = (ButtonSpinner) sender;

        if (spinner.Content is not TextBlock txtBox)
            return;

        var value = Array.IndexOf(_mountains, txtBox.Text);

        if (e.Direction == SpinDirection.Increase)
            value++;
        else
            value--;

        if (value < 0)
            value = _mountains.Length - 1;
        else if (value >= _mountains.Length)
            value = 0;

        txtBox.Text = _mountains[value];
    }
}