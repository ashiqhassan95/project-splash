namespace ProjectSplash.Helper
{
    //public class LocalNotificationService : ILocalNotificationService
    //{ 
    //    private LocalNotificationManager notificationManager;

    //    public void SetLocalNotificationContainer(Grid grid)
    //    {
    //        notificationManager = new LocalNotificationManager(grid);
    //    }

    //    public void ShowLocalNotification(SimpleNotification simpleNotification)
    //    {
    //        if (notificationManager == null)
    //            return;

    //        simpleNotification.Show();
    //    }

    //    public void ShowLocalNotification(string message)
    //    {
    //        if (notificationManager == null)
    //            return;

    //        SimpleNotification notification = new SimpleNotification();
    //        var color = (Color)App.Current.Resources["SystemAccentColor"];
    //        notification.Text = message;
    //        notification.Glyph = "\uE105";
    //        notification.Background = new SolidColorBrush(color); //new SolidColorBrush(HexToColor("#6EAF26"));  
    //        notification.TimeSpan = TimeSpan.FromSeconds(3);
    //        notification.Padding = new Thickness(3);
    //        notification.VerticalAlignment = VerticalAlignment.Bottom;
    //        notificationManager.Show(notification);
    //    }

    //    public void ShowLocalNotification(string message, string glyph)
    //    {
    //        if (notificationManager == null)
    //            return;

    //        SimpleNotification notification = new SimpleNotification();
    //        var color = (Color)App.Current.Resources["SystemAccentColor"];
    //        notification.Text = message;
    //        notification.Glyph = glyph;
    //        notification.Background = new SolidColorBrush(color);
    //        notification.TimeSpan = TimeSpan.FromSeconds(3);
    //        notification.Padding = new Thickness(3);
    //        notification.VerticalAlignment = VerticalAlignment.Bottom;
    //        notificationManager.Show(notification);
    //    }

    //    public void ShowLocalNotification(string message, string glyph, VerticalAlignment verticalAlignment)
    //    {
    //        if (notificationManager == null)
    //            return;

    //        SimpleNotification notification = new SimpleNotification();
    //        var color = (Color)App.Current.Resources["SystemAccentColor"];
    //        notification.Text = message;
    //        notification.Glyph = glyph;
    //        notification.Background = new SolidColorBrush(color);
    //        notification.TimeSpan = TimeSpan.FromSeconds(3);
    //        notification.Padding = new Thickness(3);
    //        notification.VerticalAlignment = verticalAlignment;
    //        notificationManager.Show(notification);
    //    }

    //    public void ShowLocalNotification(string message, string glyph, VerticalAlignment verticalAlignment, Duration transitionDuration)
    //    {
    //        if (notificationManager == null)
    //            return;

    //        SimpleNotification notification = new SimpleNotification();
    //        var color = (Color)App.Current.Resources["SystemAccentColor"];
    //        notification.Text = message;
    //        notification.Glyph = glyph;
    //        notification.Background = new SolidColorBrush(color);
    //        notification.TimeSpan = TimeSpan.FromSeconds(3);
    //        notification.Padding = new Thickness(3);
    //        notification.TransitionDuration = transitionDuration;
    //        notification.VerticalAlignment = verticalAlignment;
    //        notificationManager.Show(notification);
    //    }

    //    public void ShowLocalNotification(string message, string glyph, VerticalAlignment verticalAlignment, Duration transitionDuration, Action action)
    //    {
    //        if (notificationManager == null)
    //            return;

    //        SimpleNotification notification = new SimpleNotification();
    //        var color = (Color)App.Current.Resources["SystemAccentColor"];
    //        notification.Text = message;
    //        notification.Glyph = glyph;
    //        notification.Background = new SolidColorBrush(color);
    //        notification.TimeSpan = TimeSpan.FromSeconds(3);
    //        notification.Padding = new Thickness(3);
    //        notification.TransitionDuration = transitionDuration;
    //        notification.VerticalAlignment = verticalAlignment;
    //        notification.Action = action;
    //        notificationManager.Show(notification);
    //    }

    //    private Color HexToColor(string hex)
    //    {
    //        if (string.IsNullOrWhiteSpace(hex))
    //            throw new NullReferenceException(nameof(hex));

    //        var colorStr = ((string)hex).ToLower();

    //        colorStr = colorStr.Replace("#", string.Empty);
    //        var r = (byte)Convert.ToUInt32(colorStr.Substring(0, 2), 16);
    //        var g = (byte)Convert.ToUInt32(colorStr.Substring(2, 2), 16);
    //        var b = (byte)Convert.ToUInt32(colorStr.Substring(4, 2), 16);

    //        return Color.FromArgb(255, r, g, b);
    //    }
    //}
}
