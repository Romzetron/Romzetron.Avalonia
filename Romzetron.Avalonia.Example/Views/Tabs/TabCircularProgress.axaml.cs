using Avalonia.Controls;
using Romzetron.Avalonia.Example.ViewModels;

namespace Romzetron.Avalonia.Example.Views.Tabs;

public partial class TabCircularProgress : UserControl
{
    //==================================================
    // Constructor.
    //==================================================

    public TabCircularProgress()
    {
        InitializeComponent();
        DataContext = new CircularProgressViewModel();
    }
}