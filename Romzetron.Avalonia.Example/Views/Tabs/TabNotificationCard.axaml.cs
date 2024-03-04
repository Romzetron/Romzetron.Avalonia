using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;

namespace Romzetron.Avalonia.Example.Views.Tabs;

public partial class TabNotificationCard : UserControl
{
    //==================================================
    // Private variables.
    //==================================================

    private WindowNotificationManager? _notificationManagerTopRight;
    private WindowNotificationManager? _notificationManagerTopLeft;
    private WindowNotificationManager? _notificationManagerBottomRight;
    private WindowNotificationManager? _notificationManagerBottomLeft;

    //==================================================
    // Constructor.
    //==================================================

    public TabNotificationCard()
    {
        InitializeComponent();
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
        _notificationManagerBottomRight = new WindowNotificationManager(topLevel) { Position = NotificationPosition.BottomRight };
        _notificationManagerBottomLeft = new WindowNotificationManager(topLevel) { Position = NotificationPosition.BottomLeft };
    }

    //==================================================
    // Display info notification in top right corner of
    // the window.
    //==================================================

    private void ShowTopRightNotification_OnClick(object? sender, RoutedEventArgs e)
    {
        _notificationManagerTopRight?.Show(new Notification("Notification", "This is a top right Information notification."));
    }

    //==================================================
    // Display success notification in top left corner
    // of the window.
    //==================================================

    private void ShowTopLeftNotification_OnClick(object? sender, RoutedEventArgs e)
    {
        _notificationManagerTopLeft?.Show(new Notification("Notification", "This is a top left Success notification.", NotificationType.Success));
    }

    //==================================================
    // Display warning notification in bottom left
    // corner of the window.
    //==================================================

    private void ShowBottomLeftNotification_OnClick(object? sender, RoutedEventArgs e)
    {
        _notificationManagerBottomLeft?.Show(new Notification("Notification", "This is a bottom left Warning notification.", NotificationType.Warning));
    }

    //==================================================
    // Display error notification in bottom right corner
    // of the window.
    //==================================================

    private void ShowBottomRightNotification_OnClick(object? sender, RoutedEventArgs e)
    {
        _notificationManagerBottomRight?.Show(new Notification("Notification", "This is a bottom right Error notification.", NotificationType.Error));
    }
}