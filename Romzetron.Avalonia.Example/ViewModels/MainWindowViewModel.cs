using System.Linq;
using System.Reflection;
using System.Timers;
using Avalonia;
using Avalonia.Threading;
using ReactiveUI;
using Romzetron.Avalonia.Shared;

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

            var theme = GetRomzetronAvaloniaTheme();
            if (theme is not null)
                theme.ColorTheme = value;
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
        WindowTitle = $"Romzetron Avalonia Theme Example {GetNugetVersion()}";

        SelectedColorTheme = ColorTheme.Blue;

        _themeCycleTimer = new Timer(1000);
        _themeCycleTimer.Elapsed += OnThemeCycleTimerElapsed;

        RunTimer = true;
    }

    //==================================================
    // Get the nuget version.
    //==================================================

    private static string GetNugetVersion()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var attribute = assembly
            .GetCustomAttributes<AssemblyInformationalVersionAttribute>()
            .FirstOrDefault();

        if (attribute?.InformationalVersion == null)
            return "Version not found";

        var nugetVersion = attribute.InformationalVersion;
        var semanticVersion = nugetVersion.Split('+').First();

        return semanticVersion;
    }

    //==================================================
    // Get the RomzetronTheme style from the App.
    //==================================================

    private static RomzetronTheme? GetRomzetronAvaloniaTheme()
    {
        if (Application.Current is not App app)
            return null;

        foreach (var style in app.Styles)
        {
            if (style is RomzetronTheme theme)
                return theme;
        }

        return null;
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