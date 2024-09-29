using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace Romzetron.Avalonia;

public enum ColorTheme
{
	Default,
	Amber,
	Blue,
	BlueGrey,
	Brown,
	DeepOrange,
	DeepPurple,
	Green,
	Indigo,
	Orange,
	Pink,
	Purple,
	Red,
	Teal
}

public abstract class Theme : Styles
{
	public static ColorTheme[] Colors { get; }

	public static readonly AttachedProperty<ColorTheme> ColorThemeProperty =
		AvaloniaProperty.RegisterAttached<Theme, Control, ColorTheme>("ColorTheme");

	static Theme()
	{
		Colors = new[]
		{
			ColorTheme.Default,
			ColorTheme.Amber,
			ColorTheme.Blue,
			ColorTheme.BlueGrey,
			ColorTheme.Brown,
			ColorTheme.DeepOrange,
			ColorTheme.DeepPurple,
			ColorTheme.Green,
			ColorTheme.Indigo,
			ColorTheme.Orange,
			ColorTheme.Pink,
			ColorTheme.Purple,
			ColorTheme.Red,
			ColorTheme.Teal
		};
	}

	public static ColorTheme GetColorTheme(Control element)
	{
		return element.GetValue(ColorThemeProperty);
	}

	public static void SetColorTheme(Control element, ColorTheme value)
	{
		element.SetValue(ColorThemeProperty, value);
	}
}