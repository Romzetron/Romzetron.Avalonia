using System;
using Avalonia.Controls;
using ReactiveUI;

namespace Romzetron.Avalonia.Example.ViewModels;

public class SplitViewViewModel : ViewModelBase
{
    //==================================================
    // Private variables.
    //==================================================

    private bool _isLeft = true;
    private int _displayMode = 3; //CompactOverlay

    //==================================================
    // Properties.
    //==================================================

    public bool IsLeft
    {
        get => _isLeft;
        set
        {
            this.RaiseAndSetIfChanged(ref _isLeft, value);
            this.RaisePropertyChanged(nameof(PanePlacement));
        }
    }

    public int DisplayMode
    {
        get => _displayMode;
        set
        {
            this.RaiseAndSetIfChanged(ref _displayMode, value);
            this.RaisePropertyChanged(nameof(CurrentDisplayMode));
        }
    }

    public SplitViewPanePlacement PanePlacement => _isLeft ? SplitViewPanePlacement.Left : SplitViewPanePlacement.Right;

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