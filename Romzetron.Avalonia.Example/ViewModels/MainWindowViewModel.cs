using System.Reflection;
using System.Timers;
using Avalonia;
using Avalonia.Threading;
using ReactiveUI;

namespace Romzetron.Avalonia.Example.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    //==================================================
    // Private variables.
    //==================================================

    private readonly Timer _themeCycleTimer;
    
    //==================================================
    // Properties variables.
    //==================================================

    private ColorTheme _selectedColorTheme;
    private bool _runTimer;

    //==================================================
    // Properties.
    //==================================================
    
    public ColorTheme SelectedColorTheme
    {
        get => _selectedColorTheme;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedColorTheme, value);
            var app = (App) Application.Current!;
            app.SetTheme(value);
        }
    }

    public bool RunTimer
    {
        get => _runTimer;
        set
        {
            if (_runTimer == value)
                return;

            this.RaiseAndSetIfChanged(ref _runTimer, value);

            if (_runTimer)
                _themeCycleTimer.Start();
            else
                _themeCycleTimer.Stop();
        }
    }
    
    public string WindowTitle { get; }

    //==================================================
    // Constructor.
    //==================================================

    public MainWindowViewModel()
    {
        var version = Assembly.GetExecutingAssembly().GetName().Version;

        WindowTitle = version is not null 
            ? $"Romzetron Avalonia Theme Example {version.Major}.{version.Minor}.{version.Build}.{version.Revision}" 
            : "Romzetron Avalonia Theme Example";
        
        SelectedColorTheme = ColorTheme.Blue;

        _themeCycleTimer = new Timer(1000);
        _themeCycleTimer.Elapsed += OnThemeCycleTimerElapsed;

        RunTimer = true;
    }
    
    //==================================================
    // Toggle cycling themes.
    //==================================================

    public void ToggleCyclingThemes()
    {
        RunTimer = !RunTimer;
    }
    
    //==================================================
    // Automatic colorTheme cycling timer elapsed.
    //==================================================

    private void OnThemeCycleTimerElapsed(object? sender, ElapsedEventArgs args)
    {
        Dispatcher.UIThread.Invoke(() =>
        {
            SelectedColorTheme = SelectedColorTheme switch
            {
                ColorTheme.Red => ColorTheme.Pink,
                ColorTheme.Pink => ColorTheme.Purple,
                ColorTheme.Purple => ColorTheme.DeepPurple,
                ColorTheme.DeepPurple => ColorTheme.Indigo,
                ColorTheme.Indigo => ColorTheme.Blue,
                ColorTheme.Blue => ColorTheme.Teal,
                ColorTheme.Teal => ColorTheme.Green,
                ColorTheme.Green => ColorTheme.Amber,
                ColorTheme.Amber => ColorTheme.Orange,
                ColorTheme.Orange => ColorTheme.DeepOrange,
                ColorTheme.DeepOrange => ColorTheme.Brown,
                ColorTheme.Brown => ColorTheme.BlueGrey,
                ColorTheme.BlueGrey => ColorTheme.Red,
                _ => SelectedColorTheme
            };
        });
    }
}