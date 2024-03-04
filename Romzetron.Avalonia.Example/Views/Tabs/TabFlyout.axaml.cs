using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;

namespace Romzetron.Avalonia.Example.Views.Tabs;

public partial class TabFlyout : UserControl
{
    public TabFlyout()
    {
        InitializeComponent();
        
        var afp = this.FindControl<Panel>("AttachedFlyoutPanel");
        if (afp != null)
        {
            afp.DoubleTapped += Afp_DoubleTapped;
        }
    }
    
    private void Afp_DoubleTapped(object? sender, RoutedEventArgs e)
    {
        if (sender is Panel p)
        {
            FlyoutBase.ShowAttachedFlyout(p);
        }
    }
}