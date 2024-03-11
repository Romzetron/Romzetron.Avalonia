using Avalonia.Controls;
using Romzetron.Avalonia.Example.ViewModels;

namespace Romzetron.Avalonia.Example.Views.Tabs;

public partial class TabSplitView : UserControl
{
    //==================================================
    // Constructor.
    //==================================================

    public TabSplitView()
    {
        InitializeComponent();
        DataContext = new SplitViewViewModel();
    }
}