using System;
using System.Collections.Generic;
using Avalonia.Controls;
using ReactiveUI;

namespace Romzetron.Avalonia.Example.ViewModels;

public class SplitViewViewModel : ViewModelBase
{
    //==================================================
    // Private variables.
    //==================================================

    private SplitViewPanePlacement _panePlacement = SplitViewPanePlacement.Left;
    private string _selectedPanelPlacement = "Left";
    private int _displayMode = 3; //CompactOverlay

    //==================================================
    // Properties.
    //==================================================

    public int DisplayMode
    {
        get => _displayMode;
        set
        {
            this.RaiseAndSetIfChanged(ref _displayMode, value);
            this.RaisePropertyChanged(nameof(CurrentDisplayMode));
        }
    }

    public List<string> PanelPlacementOptions { get; } = ["Left", "Right", "Top", "Bottom"];

    public string SelectedPanelPlacement
    {
        get => _selectedPanelPlacement;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedPanelPlacement, value);

            PanePlacement = value switch
            {
                "Left" => SplitViewPanePlacement.Left,
                "Right" => SplitViewPanePlacement.Right,
                "Top" => SplitViewPanePlacement.Top,
                "Bottom" => SplitViewPanePlacement.Bottom,
                _ => PanePlacement
            };
        }
    }

    public SplitViewPanePlacement PanePlacement
    {
        get => _panePlacement;
        set => this.RaiseAndSetIfChanged(ref _panePlacement, value);
    }

    public SplitViewDisplayMode CurrentDisplayMode
    {
        get
        {
            if (Enum.IsDefined(typeof(SplitViewDisplayMode), _displayMode))
                return (SplitViewDisplayMode) _displayMode;

            return SplitViewDisplayMode.CompactOverlay;
        }
    }
}