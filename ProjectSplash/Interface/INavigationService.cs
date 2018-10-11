using System;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjectSplash.Interface
{
    public interface INavigationService
    {
        /// <summary>
        /// Event occur when frame navigated
        /// </summary>
        event EventHandler<NavigationEventArgs> FrameChanged;

        /// <summary>
        /// Event occur when back button is clicked
        /// </summary>
        event EventHandler<BackRequestedEventArgs> NavigationBackRequested;

        /// <summary>
        /// Return whether the frame can go back or not
        /// </summary>
        bool CanGoBack { get; }

        /// <summary>
        /// Return current page in navigation frame
        /// </summary>
        Type CurrentPage { get; }

        /// <summary>
        /// Navigate frame to specified page
        /// </summary>
        /// <param name="page">Specify view type</param>
        void Navigate(Type page);

        /// <summary>
        /// Navigate frame to specified page with parameter passed
        /// </summary>
        /// <param name="page">Specify view type</param>
        /// <param name="parameter">Specify parameter to pass</param>
        void Navigate(Type page, object parameter);

        /// <summary>
        /// Navigate frame to recent back page
        /// </summary>
        void GoBack();

        /// <summary>
        /// Delete the last page in the history
        /// </summary>
        void DeletePreviousPage();

        /// <summary>
        /// Reset the navigation frame to original state and clear history
        /// </summary>
        void Reset();
         
        /// <summary>
        /// Set navigation frame
        /// </summary>
        /// <param name="frame"></param>
        void SetNavigationFrame(Frame frame); 
    }
}
