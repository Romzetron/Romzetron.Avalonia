using Avalonia.Controls;
using Romzetron.Avalonia.Example.ViewModels;

namespace Romzetron.Avalonia.Example.Views.Tabs;

public partial class TabDataGrid : UserControl
{
    public TabDataGrid()
    {
        InitializeComponent();
        DataContext = new DataGridViewModel();
    }
}