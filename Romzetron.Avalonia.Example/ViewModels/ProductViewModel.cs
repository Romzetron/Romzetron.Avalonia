using System;
using ReactiveUI;

namespace Romzetron.Avalonia.Example.ViewModels;

public class ProductViewModel : ViewModelBase
{
    //==================================================
    // Property backing variables.
    //==================================================

    private int _productId;
    private string _name = "";
    private string _category = "";
    private string _manufacturer = "";
    private double _price;
    private int _stockQuantity;
    private DateTime _dateAdded;
    private DateTime _lastRestocked;
    private bool _isAvailable;
    private string _sku = "";
    private string _warehouseLocation = "";
    private double _weight;
    private double _dimensions;
    private string _color = "";
    private string _material = "";
    private string _warranty = "";
    private string _supplier = "";
    private string _description = "";
    private double _discount;
    private int _customerRating;
    private int _timesPurchased;

    //==================================================
    // Properties.
    //==================================================

    public int ProductID
    {
        get => _productId;
        set => this.RaiseAndSetIfChanged(ref _productId, value);
    }

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string Category
    {
        get => _category;
        set => this.RaiseAndSetIfChanged(ref _category, value);
    }

    public string Manufacturer
    {
        get => _manufacturer;
        set => this.RaiseAndSetIfChanged(ref _manufacturer, value);
    }

    public double Price
    {
        get => _price;
        set => this.RaiseAndSetIfChanged(ref _price, value);
    }

    public int StockQuantity
    {
        get => _stockQuantity;
        set => this.RaiseAndSetIfChanged(ref _stockQuantity, value);
    }

    public DateTime DateAdded
    {
        get => _dateAdded;
        set => this.RaiseAndSetIfChanged(ref _dateAdded, value);
    }

    public DateTime LastRestocked
    {
        get => _lastRestocked;
        set => this.RaiseAndSetIfChanged(ref _lastRestocked, value);
    }

    public bool IsAvailable
    {
        get => _isAvailable;
        set => this.RaiseAndSetIfChanged(ref _isAvailable, value);
    }

    public string SKU
    {
        get => _sku;
        set => this.RaiseAndSetIfChanged(ref _sku, value);
    }

    public string WarehouseLocation
    {
        get => _warehouseLocation;
        set => this.RaiseAndSetIfChanged(ref _warehouseLocation, value);
    }

    public double Weight
    {
        get => _weight;
        set => this.RaiseAndSetIfChanged(ref _weight, value);
    }

    public double Dimensions
    {
        get => _dimensions;
        set => this.RaiseAndSetIfChanged(ref _dimensions, value);
    }

    public string Color
    {
        get => _color;
        set => this.RaiseAndSetIfChanged(ref _color, value);
    }

    public string Material
    {
        get => _material;
        set => this.RaiseAndSetIfChanged(ref _material, value);
    }

    public string Warranty
    {
        get => _warranty;
        set => this.RaiseAndSetIfChanged(ref _warranty, value);
    }

    public string Supplier
    {
        get => _supplier;
        set => this.RaiseAndSetIfChanged(ref _supplier, value);
    }

    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    public double Discount
    {
        get => _discount;
        set => this.RaiseAndSetIfChanged(ref _discount, value);
    }

    public int CustomerRating
    {
        get => _customerRating;
        set => this.RaiseAndSetIfChanged(ref _customerRating, value);
    }

    public int TimesPurchased
    {
        get => _timesPurchased;
        set => this.RaiseAndSetIfChanged(ref _timesPurchased, value);
    }
}