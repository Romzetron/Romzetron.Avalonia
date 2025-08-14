using System;
using ReactiveUI;

namespace Romzetron.Avalonia.Example.ViewModels;

public class CircularProgressViewModel : ViewModelBase
{
    //==================================================
    // Property backing variables.
    //==================================================

    private int _minDurationMs;
    private int _maxDurationMs;
    private int _durationMs;
    private TimeSpan _duration;

    //==================================================
    // Properties.
    //==================================================

    public int MinDurationMs
    {
        get => _minDurationMs;
        set => this.RaiseAndSetIfChanged(ref _minDurationMs, value);
    }

    public int MaxDurationMs
    {
        get => _maxDurationMs;
        set => this.RaiseAndSetIfChanged(ref _maxDurationMs, value);
    }

    public int DurationMs
    {
        get => _durationMs;
        set
        {
            this.RaiseAndSetIfChanged(ref _durationMs, value);
            RotationDuration = TimeSpan.FromMilliseconds(value);
        }
    }

    public TimeSpan RotationDuration
    {
        get => _duration;
        private set => this.RaiseAndSetIfChanged(ref _duration, value);
    }

    //==================================================
    // Constructor.
    //==================================================

    public CircularProgressViewModel()
    {
        MinDurationMs = 0;
        MaxDurationMs = 5000;
        DurationMs = 2500;
    }
}