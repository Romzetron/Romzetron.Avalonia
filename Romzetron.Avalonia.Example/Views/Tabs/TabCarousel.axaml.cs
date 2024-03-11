using System;
using Avalonia.Animation;
using Avalonia.Controls;

namespace Romzetron.Avalonia.Example.Views.Tabs;

public partial class TabCarousel : UserControl
{
    //==================================================
    // Control references.
    //==================================================

    private readonly Carousel _carousel;
    private readonly Button _buttonPrevious;
    private readonly Button _buttonNext;
    private readonly ComboBox _transition;
    private readonly ComboBox _orientation;

    //==================================================
    // Constructor.
    //==================================================

    public TabCarousel()
    {
        InitializeComponent();
        _carousel = this.Get<Carousel>("Carousel");
        _buttonPrevious = this.Get<Button>("ButtonPrevious");
        _buttonNext = this.Get<Button>("ButtonNext");
        _transition = this.Get<ComboBox>("Transition");
        _orientation = this.Get<ComboBox>("Orientation");
        _buttonPrevious.Click += (_, _) => _carousel.Previous();
        _buttonNext.Click += (_, _) => _carousel.Next();
        _transition.SelectionChanged += TransitionChanged;
        _orientation.SelectionChanged += TransitionChanged;
    }

    //==================================================
    // Transition changed event handler.
    //==================================================

    private void TransitionChanged(object? sender, SelectionChangedEventArgs e)
    {
        _carousel.PageTransition = _transition.SelectedIndex switch
        {
            0 => null,
            1 => new PageSlide(TimeSpan.FromSeconds(0.25), _orientation.SelectedIndex == 0 ? PageSlide.SlideAxis.Horizontal : PageSlide.SlideAxis.Vertical),
            2 => new CrossFade(TimeSpan.FromSeconds(0.25)),
            3 => new Rotate3DTransition(TimeSpan.FromSeconds(0.5), _orientation.SelectedIndex == 0 ? PageSlide.SlideAxis.Horizontal : PageSlide.SlideAxis.Vertical),
            _ => _carousel.PageTransition
        };
    }
}