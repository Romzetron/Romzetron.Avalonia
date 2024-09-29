using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;

namespace Romzetron.Avalonia.Example.Views.Tabs;

public partial class TabNotificationCard : UserControl, INotifyPropertyChanged
{
    //==================================================
    // Private variables.
    //==================================================

    private WindowNotificationManager? _notificationManagerTopRight;
    private WindowNotificationManager? _notificationManagerTopLeft;
    private WindowNotificationManager? _notificationManagerTopCenter;
    private WindowNotificationManager? _notificationManagerBottomRight;
    private WindowNotificationManager? _notificationManagerBottomLeft;
    private WindowNotificationManager? _notificationManagerBottomCenter;

    //==================================================
    // Private property variables.
    //==================================================

    private string _selectedNotificationType = "Information";

    //==================================================
    // Properties.
    //==================================================

    public ObservableCollection<string> NotificationTypes { get; } = ["Information", "Success", "Warning", "Error"];

    public string SelectedNotificationType
    {
        get => _selectedNotificationType;
        set
        {
            _selectedNotificationType = value;
            OnPropertyChanged(nameof(SelectedNotificationType));
        }
    }

    //==================================================
    // Constructor.
    //==================================================

    public TabNotificationCard()
    {
        InitializeComponent();
        DataContext = this;
    }

    //==================================================
    // Attached to visual tree event handler.
    //==================================================

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        var topLevel = TopLevel.GetTopLevel(this);

        _notificationManagerTopRight = new WindowNotificationManager(topLevel) { Position = NotificationPosition.TopRight };
        _notificationManagerTopLeft = new WindowNotificationManager(topLevel) { Position = NotificationPosition.TopLeft };
        _notificationManagerTopCenter = new WindowNotificationManager(topLevel) { Position = NotificationPosition.TopCenter };
        _notificationManagerBottomRight = new WindowNotificationManager(topLevel) { Position = NotificationPosition.BottomRight };
        _notificationManagerBottomLeft = new WindowNotificationManager(topLevel) { Position = NotificationPosition.BottomLeft };
        _notificationManagerBottomCenter = new WindowNotificationManager(topLevel) { Position = NotificationPosition.BottomCenter };
    }

    //==================================================
    // Display info notification in top right corner of
    // the window.
    //==================================================

    private void ShowTopRightNotification_OnClick(object? sender, RoutedEventArgs e)
    {
        _notificationManagerTopRight?.Show(new Notification("Notification", $"This is a top right {SelectedNotificationType} notification."), GetNotificationType());
    }

    //==================================================
    // Display success notification in top left corner
    // of the window.
    //==================================================

    private void ShowTopLeftNotification_OnClick(object? sender, RoutedEventArgs e)
    {
        _notificationManagerTopLeft?.Show(new Notification("Notification", $"This is a top left {SelectedNotificationType} notification.", GetNotificationType()));
    }

    //==================================================
    // Display success notification in top center of the
    // window.
    //==================================================

    private void ShowTopCenterNotification_OnClick(object? sender, RoutedEventArgs e)
    {
        _notificationManagerTopCenter?.Show(new Notification("Notification", $"This is a top center {SelectedNotificationType} notification."), GetNotificationType());
    }

    //==================================================
    // Display warning notification in bottom left
    // corner of the window.
    //==================================================

    private void ShowBottomLeftNotification_OnClick(object? sender, RoutedEventArgs e)
    {
        _notificationManagerBottomLeft?.Show(new Notification("Notification", $"This is a bottom left {SelectedNotificationType} notification.", GetNotificationType()));
    }

    //==================================================
    // Display error notification in bottom right corner
    // of the window.
    //==================================================

    private void ShowBottomRightNotification_OnClick(object? sender, RoutedEventArgs e)
    {
        _notificationManagerBottomRight?.Show(new Notification("Notification", $"This is a bottom right {SelectedNotificationType} notification.", GetNotificationType()));
    }

    //==================================================
    // Display success notification in bottom center of
    // the window.
    //==================================================

    private void ShowBottomCenterNotification_OnClick(object? sender, RoutedEventArgs e)
    {
        _notificationManagerBottomCenter?.Show(new Notification("Notification", $"This is a bottom center {SelectedNotificationType} notification."), GetNotificationType());
    }

    //==================================================
    // Convert notification type string to enum.
    //==================================================

    private NotificationType GetNotificationType()
    {
        return SelectedNotificationType switch
        {
            "Information" => NotificationType.Information,
            "Success" => NotificationType.Success,
            "Warning" => NotificationType.Warning,
            "Error" => NotificationType.Error,
            _ => NotificationType.Information
        };
    }

    //==================================================
    // Property changed event handling.
    //==================================================

    public new event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}