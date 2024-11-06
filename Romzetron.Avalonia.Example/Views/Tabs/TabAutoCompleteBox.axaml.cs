using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;

namespace Romzetron.Avalonia.Example.Views.Tabs;

public partial class TabAutoCompleteBox : UserControl
{
    //==================================================
    // Properties.
    //==================================================

    public StateData[] States { get; private set; }
    public LinkedList<string>[] Sentences { get; private set; }

    //==================================================
    // Constructor.
    //==================================================

    public TabAutoCompleteBox()
    {
        InitializeComponent();

        States = BuildAllStates();
        Sentences = BuildAllSentences();

        foreach (var box in GetAllAutoCompleteBox().Where(x => x.Name != "CustomAutocompleteBox"))
            box.ItemsSource = States;

        var converter = new FuncMultiValueConverter<string, string>(parts => string.Format("{0} ({1})", parts.ToArray()));

        var binding = new MultiBinding { Converter = converter };
        binding.Bindings.Add(new Binding("Name"));
        binding.Bindings.Add(new Binding("Abbreviation"));

        var multibindingBox = this.Get<AutoCompleteBox>("MultiBindingBox");
        multibindingBox.ValueMemberBinding = binding;

        var asyncBox = this.Get<AutoCompleteBox>("AsyncBox");
        asyncBox.AsyncPopulator = PopulateAsync;

        var customAutocompleteBox = this.Get<AutoCompleteBox>("CustomAutocompleteBox");
        customAutocompleteBox.ItemsSource = Sentences.SelectMany(x => x);
        customAutocompleteBox.TextFilter = LastWordContains;
        customAutocompleteBox.TextSelector = AppendWord;
    }

    //==================================================
    // Build state list.
    //==================================================

    private static StateData[] BuildAllStates()
    {
        return
        [
            new StateData("Alabama", "AL", "Montgomery"),
            new StateData("Alaska", "AK", "Juneau"),
            new StateData("Arizona", "AZ", "Phoenix"),
            new StateData("Arkansas", "AR", "Little Rock"),
            new StateData("California", "CA", "Sacramento"),
            new StateData("Colorado", "CO", "Denver"),
            new StateData("Connecticut", "CT", "Hartford"),
            new StateData("Delaware", "DE", "Dover"),
            new StateData("Florida", "FL", "Tallahassee"),
            new StateData("Georgia", "GA", "Atlanta"),
            new StateData("Hawaii", "HI", "Honolulu"),
            new StateData("Idaho", "ID", "Boise"),
            new StateData("Illinois", "IL", "Springfield"),
            new StateData("Indiana", "IN", "Indianapolis"),
            new StateData("Iowa", "IA", "Des Moines"),
            new StateData("Kansas", "KS", "Topeka"),
            new StateData("Kentucky", "KY", "Frankfort"),
            new StateData("Louisiana", "LA", "Baton Rouge"),
            new StateData("Maine", "ME", "Augusta"),
            new StateData("Maryland", "MD", "Annapolis"),
            new StateData("Massachusetts", "MA", "Boston"),
            new StateData("Michigan", "MI", "Lansing"),
            new StateData("Minnesota", "MN", "St. Paul"),
            new StateData("Mississippi", "MS", "Jackson"),
            new StateData("Missouri", "MO", "Jefferson City"),
            new StateData("Montana", "MT", "Helena"),
            new StateData("Nebraska", "NE", "Lincoln"),
            new StateData("Nevada", "NV", "Carson City"),
            new StateData("New Hampshire", "NH", "Concord"),
            new StateData("New Jersey", "NJ", "Trenton"),
            new StateData("New Mexico", "NM", "Santa Fe"),
            new StateData("New York", "NY", "Albany"),
            new StateData("North Carolina", "NC", "Raleigh"),
            new StateData("North Dakota", "ND", "Bismarck"),
            new StateData("Ohio", "OH", "Columbus"),
            new StateData("Oklahoma", "OK", "Oklahoma City"),
            new StateData("Oregon", "OR", "Salem"),
            new StateData("Pennsylvania", "PA", "Harrisburg"),
            new StateData("Rhode Island", "RI", "Providence"),
            new StateData("South Carolina", "SC", "Columbia"),
            new StateData("South Dakota", "SD", "Pierre"),
            new StateData("Tennessee", "TN", "Nashville"),
            new StateData("Texas", "TX", "Austin"),
            new StateData("Utah", "UT", "Salt Lake City"),
            new StateData("Vermont", "VT", "Montpelier"),
            new StateData("Virginia", "VA", "Richmond"),
            new StateData("Washington", "WA", "Olympia"),
            new StateData("West Virginia", "WV", "Charleston"),
            new StateData("Wisconsin", "WI", "Madison"),
            new StateData("Wyoming", "WY", "Cheyenne")
        ];
    }

    //==================================================
    // Build sentences.
    //==================================================

    private static LinkedList<string>[] BuildAllSentences()
    {
        return new[]
            {
                "Hello world",
                "No this is Patrick",
                "Never gonna give you up",
                "How does one patch KDE2 under FreeBSD"
            }
            .Select(x => new LinkedList<string>(x.Split(' ')))
            .ToArray();
    }

    //==================================================
    // Get all AutoCompleteBox objects.
    //==================================================

    private IEnumerable<AutoCompleteBox> GetAllAutoCompleteBox() =>
        this.GetLogicalDescendants()
            .OfType<AutoCompleteBox>();

    //==================================================
    // Check if a string contains a substring.
    //==================================================

    private static bool StringContains(string str, string? query)
    {
        return query != null && str.Contains(query, StringComparison.OrdinalIgnoreCase);
    }

    //==================================================
    // Populate search result asynchronously.
    //==================================================

    private async Task<IEnumerable<object>> PopulateAsync(string? searchText, CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(1.5), cancellationToken);
        return States.Where(data => StringContains(data.Name, searchText) || StringContains(data.Capital, searchText)).ToList();
    }

    //==================================================
    // Check if last word contains substring.
    //==================================================

    private bool LastWordContains(string? searchText, string? item)
    {
        var words = searchText?.Split(' ') ?? [];

        var options = Sentences
            .Select(x => x.First)
            .ToArray();

        for (var i = 0; i < words.Length; ++i)
        {
            var word = words[i];

            for (var j = 0; j < options.Length; ++j)
            {
                if (options[i] is not { } option)
                    continue;

                if (i == words.Length - 1)
                    options[j] = option.Value.ToLower().Contains(word.ToLower()) ? option : null;
                else
                    options[j] = option.Value.Equals(word, StringComparison.InvariantCultureIgnoreCase) ? option.Next : null;
            }
        }

        return options.Any(x => x != null && x.Value == item);
    }

    //==================================================
    // Append word.
    //==================================================

    private static string AppendWord(string? text, string? item)
    {
        if (item is null)
            return string.Empty;

        var parts = text?.Split(' ') ?? [];

        if (parts.Length == 0)
            return item;

        parts[^1] = item;
        return string.Join(" ", parts);
    }

    //==================================================
    // Initialize component.
    //==================================================

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}

//##################################################
// StateData class.
//##################################################

public class StateData
{
    public string Name { get; private set; }
    public string Abbreviation { get; private set; }
    public string Capital { get; private set; }

    public StateData(string name, string abbreviation, string capital)
    {
        Name = name;
        Abbreviation = abbreviation;
        Capital = capital;
    }

    public override string ToString()
    {
        return Name;
    }
}