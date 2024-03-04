using Avalonia.Controls;

namespace Romzetron.Avalonia.Example.Views.Tabs;

public partial class TabCalendarDatePicker : UserControl
{
    //==================================================
    // Constructor.
    //==================================================
    
    public TabCalendarDatePicker()
    {
        InitializeComponent();
        
        //--------------------------------------------------
        // Add blackout dates to example.
        //--------------------------------------------------
        
        var blackoutCalendarDatePicker = this.Get<CalendarDatePicker>("BlackoutCalendarDatePicker");
        blackoutCalendarDatePicker.TemplateApplied += (s, e) =>
        {
            blackoutCalendarDatePicker.BlackoutDates?.AddDatesInPast();
        };
    }
}