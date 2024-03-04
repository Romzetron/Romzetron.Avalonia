using Avalonia.Controls;
using Romzetron.Avalonia.Example.ViewModels;

namespace Romzetron.Avalonia.Example.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var mainVm = new MainWindowViewModel();
        DataContext = mainVm;
    }
}