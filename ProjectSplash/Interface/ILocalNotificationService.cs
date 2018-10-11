using System;
using Windows.UI.Xaml;

namespace ProjectSplash.Interface
{
    public interface ILocalNotificationService
    {
        //void SetLocalNotificationContainer(Grid grid);
        //void ShowLocalNotification(SimpleNotification simpleNotification);

        void ShowLocalNotification(string message);
        void ShowLocalNotification(string message, string glyph);
        void ShowLocalNotification(string message, string glyph, VerticalAlignment verticalAlignment);
        void ShowLocalNotification(string message, string glyph, VerticalAlignment verticalAlignment, Duration transitionDuration);
        void ShowLocalNotification(string message, string glyph, VerticalAlignment verticalAlignment, Duration transitionDuration, Action action);
    }
}
