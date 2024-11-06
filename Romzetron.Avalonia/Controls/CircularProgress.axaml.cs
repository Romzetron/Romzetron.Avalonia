using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Romzetron.Avalonia.Controls;

/// <summary>
/// A custom control that represents a circular progress indicator.
/// </summary>
public sealed class CircularProgress : ContentControl
{
    //==================================================
    // Private property variables.
    //==================================================

    /// <summary>
    /// Represents the current percentage value of the circular progress.
    /// This value is updated based on the Value, Minimum, and Maximum properties.
    /// </summary>
    private double _percentage;

    /// <summary>
    /// Represents the radius used for rendering the circular progress indicator.
    /// This variable is calculated during the measure override process and
    /// takes into account the stroke thickness of the progress circle.
    /// </summary>
    private double _radius;

    //==================================================
    // Properties.
    //==================================================

    /// <summary>
    /// Identifies the IsIndeterminate dependency property.
    /// </summary>
    /// <remarks>
    /// This property determines whether the progress indicator is in an indeterminate state, meaning it shows an ongoing activity rather than a specific progress value.
    /// </remarks>
    public static readonly StyledProperty<bool> IsIndeterminateProperty = AvaloniaProperty.Register<CircularProgress, bool>(nameof(IsIndeterminate));

    /// <summary>
    /// Represents the maximum value for the circular progress indicator.
    /// </summary>
    /// <remarks>
    /// This property determines the upper limit of the range for the circular progress indicator.
    /// The default value is 100.
    /// </remarks>
    public static readonly StyledProperty<double> MaximumProperty = AvaloniaProperty.Register<CircularProgress, double>(nameof(Maximum), 100);

    /// <summary>
    /// Defines the minimum value for the CircularProgress control.
    /// </summary>
    public static readonly StyledProperty<double> MinimumProperty = AvaloniaProperty.Register<CircularProgress, double>(nameof(Minimum));

    /// <summary>
    /// Identifies the Percentage dependency property, which indicates the current progress percentage of the circular progress control.
    /// </summary>
    /// <remarks>
    /// This property is read-only and its value is calculated based on the current progress value with respect to the defined Minimum and Maximum properties.
    /// </remarks>
    public static readonly DirectProperty<CircularProgress, double> PercentageProperty =
        AvaloniaProperty.RegisterDirect<CircularProgress, double>(nameof(Percentage), x => x.Percentage);

    /// <summary>
    /// Defines the format in which the progress text is displayed.
    /// The default format is "{1:0}%".
    /// </summary>
    public static readonly StyledProperty<string> ProgressTextFormatProperty = AvaloniaProperty.Register<CircularProgress, string>(nameof(ProgressTextFormat), "{1:0}%");

    /// <summary>
    /// Identifies the ShowProgressText dependency property. When set to true, the progress text is displayed
    /// inside the circular progress control. If false, the progress text is hidden.
    /// </summary>
    public static readonly StyledProperty<bool> ShowProgressTextProperty = AvaloniaProperty.Register<CircularProgress, bool>(nameof(ShowProgressText));

    /// <summary>
    /// Identifies the StrokeLineCap property, which determines the shape used at the end of a stroke.
    /// </summary>
    public static readonly StyledProperty<PenLineCap> StrokeLineCapProperty = AvaloniaProperty.Register<CircularProgress, PenLineCap>(nameof(StrokeLineCap), PenLineCap.Round);

    /// <summary>
    /// Defines the brush used to draw the stroke of the circular progress indicator.
    /// </summary>
    public static readonly StyledProperty<Brush> StrokeProperty = AvaloniaProperty.Register<CircularProgress, Brush>(nameof(Stroke));

    /// <summary>
    /// Identifies the StrokeThickness dependency property.
    /// </summary>
    /// <remarks>
    /// The StrokeThickness property determines the thickness of the stroke
    /// used to draw the CircularProgress control's arc.
    /// </remarks>
    public static readonly StyledProperty<int> StrokeThicknessProperty = AvaloniaProperty.Register<CircularProgress, int>(nameof(StrokeThickness), 8);

    /// <summary>
    /// Gets or sets the sweep angle of the circular progress indicator.
    /// </summary>
    /// <remarks>
    /// The sweep angle determines how much of the circle is filled, measured in degrees.
    /// </remarks>
    public static readonly StyledProperty<double> SweepAngleProperty = AvaloniaProperty.Register<CircularProgress, double>(nameof(SweepAngle));

    /// <summary>
    /// Represents the current value of the progress indicator.
    /// </summary>
    /// <remarks>
    /// The value should be within the range specified by the Minimum and Maximum properties.
    /// </remarks>
    public static readonly StyledProperty<double> ValueProperty = AvaloniaProperty.Register<CircularProgress, double>(nameof(Value));

    /// <summary>
    /// Converter that returns the stroke thickness for the CircularProgress control.
    /// </summary>
    public static FuncValueConverter<CircularProgress, double> GetStrokeBorderThickness => new(x => x?.StrokeThickness ?? 8);

    /// <summary>
    /// Gets or sets a boolean value that indicates whether the progress is indeterminate.
    /// When set to true, the progress indicator does not display an exact value and may use an animation to show that progress is ongoing.
    /// </summary>
    public bool IsIndeterminate
    {
        get => GetValue(IsIndeterminateProperty);
        set => SetValue(IsIndeterminateProperty, value);
    }

    /// <summary>
    /// Gets or sets the maximum value of the progress bar.
    /// </summary>
    /// <remarks>
    /// The <see cref="Maximum"/> property determines the upper bound of the progress bar range.
    /// This property is used to calculate the percentage of the current progress relative to the total range.
    /// </remarks>
    public double Maximum
    {
        get => GetValue(MaximumProperty);
        set => SetValue(MaximumProperty, value);
    }

    /// <summary>
    /// Gets or sets the minimum value for the progress indicator. This determines the
    /// starting point of the progress, where 0 represents no progress.
    /// </summary>
    /// <value>
    /// The minimum value for the progress. The default value is 0.
    /// </value>
    public double Minimum
    {
        get => GetValue(MinimumProperty);
        set => SetValue(MinimumProperty, value);
    }

    /// <summary>
    /// Gets the percentage value indicating the current progress relative to the maximum value.
    /// </summary>
    /// <remarks>
    /// The percentage is calculated based on the Minimum, Maximum, and Value properties.
    /// It represents the completion level of the circular progress control as a value between 0 and 100.
    /// This property is read-only and is automatically updated based on the current progress.
    /// </remarks>
    public double Percentage
    {
        get => _percentage;
        private set => SetAndRaise(PercentageProperty, ref _percentage, value);
    }

    /// <summary>
    /// Gets or sets the format string used for displaying the progress text.
    /// The default format is "{1:0}%", where {1} represents the current Percentage value.
    /// </summary>
    public string ProgressTextFormat
    {
        get => GetValue(ProgressTextFormatProperty);
        set => SetValue(ProgressTextFormatProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the progress text should be displayed.
    /// </summary>
    /// <value>
    /// <c>true</c> if the progress text should be shown; otherwise, <c>false</c>.
    /// </value>
    public bool ShowProgressText
    {
        get => GetValue(ShowProgressTextProperty);
        set => SetValue(ShowProgressTextProperty, value);
    }

    /// <summary>
    /// Gets or sets the <see cref="Brush"/> used to paint the stroke of the CircularProgress control.
    /// </summary>
    /// <remarks>
    /// This property defines the color and potentially other characteristics of the stroke
    /// that outlines the circular progress indicator.
    /// </remarks>
    public Brush Stroke
    {
        get => GetValue(StrokeProperty);
        set => SetValue(StrokeProperty, value);
    }

    /// <summary>
    /// Gets or sets the style of the end caps for the stroke of the circular progress arc.
    /// </summary>
    /// <remarks>
    /// This property determines how the end points of the stroke are drawn when rendering the circular progress control.
    /// Valid values include members of the <see cref="Avalonia.Media.PenLineCap"/> enumeration such as `Flat`, `Square`, and `Round`.
    /// </remarks>
    public PenLineCap StrokeLineCap
    {
        get => GetValue(StrokeLineCapProperty);
        set => SetValue(StrokeLineCapProperty, value);
    }

    /// <summary>
    /// Gets or sets the thickness of the stroke of the circular progress indicator.
    /// </summary>
    /// <remarks>
    /// This property determines how thick the stroke of the circular progress will appear.
    /// The default value is 8.
    /// </remarks>
    public int StrokeThickness
    {
        get => GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }

    /// <summary>
    /// Gets or sets the sweep angle of the circular progress indicator.
    /// This represents the angle, in degrees, of the arc that indicates progress.
    /// </summary>
    public double SweepAngle
    {
        get => GetValue(SweepAngleProperty);
        set => SetValue(SweepAngleProperty, value);
    }

    /// <summary>
    /// Gets or sets the current value of the circular progress indicator.
    /// </summary>
    /// <remarks>
    /// This property represents the progress value and determines the proportion of the circular indicator that is filled.
    /// Valid values range between <see cref="Minimum"/> and <see cref="Maximum"/>.
    /// </remarks>
    public double Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    //==================================================
    // Measure override.
    //==================================================

    /// <summary>
    /// Measures the size required for the CircularProgress control, updates the radius, and renders the arc.
    /// </summary>
    /// <param name="availableSize">The available size that this element can give to child elements.</param>
    /// <returns>The size that this element determines it needs during layout.</returns>
    protected override Size MeasureOverride(Size availableSize)
    {
        _radius = availableSize.Height / 2;
        _radius -= StrokeThickness;
        RenderArc();
        return new Size(_radius * 2, _radius * 2);
    }

    //==================================================
    // Property changed handler.
    //==================================================

    /// <summary>
    /// Called when a property value changes.
    /// </summary>
    /// <param name="e">The event data that contains information about which property changed and the old and new values of the property.</param>
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        if (e.Property == IsIndeterminateProperty ||
            e.Property == MinimumProperty ||
            e.Property == MaximumProperty ||
            e.Property == StrokeThicknessProperty ||
            e.Property == ValueProperty)
            RenderArc();
    }

    //==================================================
    // Render arc.
    //==================================================

    /// <summary>
    /// Calculates and updates the sweep angle and percentage of the circular progress indicator.
    /// The sweep angle is determined based on the current value, minimum, and maximum properties.
    /// This method is invoked when relevant properties change.
    /// </summary>
    private void RenderArc()
    {
        var total = Maximum - Minimum;
        var value = Value - Minimum;
        double percentage;

        if (value <= 0)
            percentage = 0;
        else if (value > total)
            percentage = 1;
        else
            percentage = value / total;

        SweepAngle = percentage * 360;
        Percentage = percentage * 100;
    }
}