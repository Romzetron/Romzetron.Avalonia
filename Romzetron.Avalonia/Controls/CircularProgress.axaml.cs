#region References

using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media;

#endregion

namespace Romzetron.Avalonia.Controls;

public sealed class CircularProgress : ContentControl
{
	#region Fields

	public static readonly StyledProperty<bool> IsIndeterminateProperty = AvaloniaProperty.Register<CircularProgress, bool>(nameof(IsIndeterminate));
	public static readonly StyledProperty<double> MaximumProperty = AvaloniaProperty.Register<CircularProgress, double>(nameof(Maximum), 100);
	public static readonly StyledProperty<double> MinimumProperty = AvaloniaProperty.Register<CircularProgress, double>(nameof(Minimum));
	public static readonly DirectProperty<CircularProgress, double> PercentageProperty = AvaloniaProperty.RegisterDirect<CircularProgress, double>(nameof(Percentage), x => x.Percentage);
	public static readonly StyledProperty<string> ProgressTextFormatProperty = AvaloniaProperty.Register<CircularProgress, string>(nameof(ProgressTextFormat), "{1:0}%");
	public static readonly StyledProperty<bool> ShowProgressTextProperty = AvaloniaProperty.Register<CircularProgress, bool>(nameof(ShowProgressText));
	public static readonly StyledProperty<PenLineCap> StrokeLineCapProperty = AvaloniaProperty.Register<CircularProgress, PenLineCap>(nameof(StrokeLineCap), PenLineCap.Round);
	public static readonly StyledProperty<Brush> StrokeProperty = AvaloniaProperty.Register<CircularProgress, Brush>(nameof(Stroke));
	public static readonly StyledProperty<int> StrokeThicknessProperty = AvaloniaProperty.Register<CircularProgress, int>(nameof(StrokeThickness), 8);
	public static readonly StyledProperty<double> SweepAngleProperty = AvaloniaProperty.Register<CircularProgress, double>(nameof(SweepAngle));
	public static readonly StyledProperty<double> ValueProperty = AvaloniaProperty.Register<CircularProgress, double>(nameof(Value));

	private double _percentage;
	private double _radius;

	#endregion

	#region Properties

	public static FuncValueConverter<CircularProgress, double> GetStrokeBorderThickness => new(x => x?.StrokeThickness ?? 8);

	public bool IsIndeterminate
	{
		get => GetValue(IsIndeterminateProperty);
		set => SetValue(IsIndeterminateProperty, value);
	}

	public double Maximum
	{
		get => GetValue(MaximumProperty);
		set => SetValue(MaximumProperty, value);
	}

	public double Minimum
	{
		get => GetValue(MinimumProperty);
		set => SetValue(MinimumProperty, value);
	}

	/// <summary>
	/// Gets the overall percentage complete of the progress
	/// </summary>
	public double Percentage
	{
		get => _percentage;
		private set => SetAndRaise(PercentageProperty, ref _percentage, value);
	}

	public string ProgressTextFormat
	{
		get => GetValue(ProgressTextFormatProperty);
		set => SetValue(ProgressTextFormatProperty, value);
	}

	public bool ShowProgressText
	{
		get => GetValue(ShowProgressTextProperty);
		set => SetValue(ShowProgressTextProperty, value);
	}

	public Brush Stroke
	{
		get => GetValue(StrokeProperty);
		set => SetValue(StrokeProperty, value);
	}

	public PenLineCap StrokeLineCap
	{
		get => GetValue(StrokeLineCapProperty);
		set => SetValue(StrokeLineCapProperty, value);
	}

	public int StrokeThickness
	{
		get => GetValue(StrokeThicknessProperty);
		set => SetValue(StrokeThicknessProperty, value);
	}

	public double SweepAngle
	{
		get => GetValue(SweepAngleProperty);
		set => SetValue(SweepAngleProperty, value);
	}

	public double Value
	{
		get => GetValue(ValueProperty);
		set => SetValue(ValueProperty, value);
	}

	#endregion

	#region Methods

	protected override Size MeasureOverride(Size availableSize)
	{
		_radius = availableSize.Height / 2;
		_radius -= StrokeThickness;
		RenderArc();
		return new Size(_radius * 2, _radius * 2);
	}

	protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs e)
	{
		base.OnPropertyChanged(e);

		if ((e.Property == IsIndeterminateProperty) ||
			(e.Property == MinimumProperty) ||
			(e.Property == MaximumProperty) ||
			(e.Property == StrokeThicknessProperty) ||
			(e.Property == ValueProperty))
		{
			RenderArc();
		}
	}

	private void RenderArc()
	{
		var total = Maximum - Minimum;
		var value = Value - Minimum;
		double percentage;

		if (value <= 0)
		{
			percentage = 0;
		}
		else if (value > total)
		{
			percentage = 1;
		}
		else
		{
			percentage = value / total;
		}
		SweepAngle = percentage * 360;
		Percentage = percentage * 100;
	}

	#endregion
}