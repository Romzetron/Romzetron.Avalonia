using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using ReactiveUI;
using Romzetron.Avalonia.Example.ViewModels;

namespace Romzetron.Avalonia.Example.Views.Tabs;

//##################################################
// TabComboBox code behind.
//##################################################

public partial class TabComboBox : UserControl
{
    //==================================================
    // Constructor.
    //==================================================

    public TabComboBox()
    {
        InitializeComponent();
        DataContext = new TabComboBoxViewModel();
    }

    //==================================================
    // Initialize tab and load fonts.
    //==================================================

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        var fontComboBox = this.Get<ComboBox>("FontComboBox");
        fontComboBox.ItemsSource = FontManager.Current.SystemFonts;
        fontComboBox.SelectedIndex = 0;
    }
}

//##################################################
// TabComboBox view model
//##################################################

public class TabComboBoxViewModel : ViewModelBase
{
    private bool _wrapSelection;

    public bool WrapSelection
    {
        get => _wrapSelection;
        set => this.RaiseAndSetIfChanged(ref _wrapSelection, value);
    }

    public ObservableCollection<IdAndName> Values { get; set; } = new()
    {
        new IdAndName { Id = "Id 1", Name = "Name 1" },
        new IdAndName { Id = "Id 2", Name = "Name 2" },
        new IdAndName { Id = "Id 3", Name = "Name 3" },
        new IdAndName { Id = "Id 4", Name = "Name 4" },
        new IdAndName { Id = "Id 5", Name = "Name 5" },
    };
}

public class IdAndName
{
    public string? Id { get; set; }
    public string? Name { get; set; }
}