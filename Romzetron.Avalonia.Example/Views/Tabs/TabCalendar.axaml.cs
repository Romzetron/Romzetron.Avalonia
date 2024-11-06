using System;
using System.Linq;
using Avalonia.Controls;

namespace Romzetron.Avalonia.Example.Views.Tabs;

public partial class TabCalendar : UserControl
{
    //==================================================
    // Constructor.
    //==================================================

    public TabCalendar()
    {
        InitializeComponent();

        //--------------------------------------------------
        // Get the current date.
        //--------------------------------------------------

        var today = DateTime.Today;

        var firstMonday = Enumerable.Range(1, 7)
            .Select(i => new DateTime(today.Year, today.Month, i))
            .First(d => d.DayOfWeek == DayOfWeek.Monday);

        var firstEndOfWeek = firstMonday.AddDays(4);
        var thirdMonday = firstMonday.AddDays(14);
        var thirdEndOfWeek = thirdMonday.AddDays(4);

        //--------------------------------------------------
        // Set selection date to today for single selection
        // example.
        //--------------------------------------------------

        var singleSelectionCalendar = this.Get<Calendar>("SingleSelectionCalendar");
        singleSelectionCalendar.SelectedDate = today;

        //--------------------------------------------------
        // Set selected date range for single range
        // selection example.
        //--------------------------------------------------

        var singleRangeSelectionCalendar = this.Get<Calendar>("SingleRangeSelectionCalendar");
        singleRangeSelectionCalendar.SelectedDates.AddRange(firstMonday, firstEndOfWeek);

        //--------------------------------------------------
        // Set multiple selected date ranges for multiple
        // range selection example.
        //--------------------------------------------------

        var multipleRangeSelectionCalendar = this.Get<Calendar>("MultipleRangeSelectionCalendar");
        multipleRangeSelectionCalendar.SelectedDates.AddRange(firstMonday, firstEndOfWeek);
        multipleRangeSelectionCalendar.SelectedDates.AddRange(thirdMonday, thirdEndOfWeek);

        //--------------------------------------------------
        // Set start and end date range for display date
        // range example.
        //--------------------------------------------------

        var displayDatesCalendar = this.Get<Calendar>("DisplayDatesCalendar");
        displayDatesCalendar.SelectedDate = today;
        displayDatesCalendar.DisplayDateStart = today.AddDays(-25);
        displayDatesCalendar.DisplayDateEnd = today.AddDays(25);

        //--------------------------------------------------
        // Set blackout dates for blackout example.
        //--------------------------------------------------

        var blackoutCalendar = this.Get<Calendar>("BlackoutCalendar");
        blackoutCalendar.SelectedDate = today;
        blackoutCalendar.BlackoutDates.AddDatesInPast();
        blackoutCalendar.BlackoutDates.Add(new CalendarDateRange(today.AddDays(2)));

        //--------------------------------------------------
        // Set blackout dates for disabled example.
        //--------------------------------------------------

        var disabledCalendar = this.Get<Calendar>("DisabledCalendar");
        disabledCalendar.SelectedDate = today;
        disabledCalendar.BlackoutDates.AddDatesInPast();
        disabledCalendar.BlackoutDates.Add(new CalendarDateRange(today.AddDays(2)));
        disabledCalendar.SelectedDates.AddRange(today, today.AddDays(1));
    }
}