using ProjectSplash.Interface;
using System;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjectSplash.Helper
{
    public class NavigationService : GalaSoft.MvvmLight.ViewModelBase, INavigationService
    {
        private const string instanceName = "UWP navigation service";

        private Frame NavigationFrame;

        public event EventHandler<NavigationEventArgs> FrameChanged;
        public event EventHandler<BackRequestedEventArgs> NavigationBackRequested;

        public bool CanGoBack => EnsureFrameCreated() ? NavigationFrame.CanGoBack : false;
        public Type CurrentPage => EnsureFrameCreated() ? NavigationFrame.CurrentSourcePageType : null; 

        public void GoBack()
        {
            if (EnsureFrameCreated() && NavigationFrame.CanGoBack)
                NavigationFrame.GoBack();
        }

        public void Navigate(Type page)
        {
            if (EnsureFrameCreated())
                NavigationFrame.Navigate(page);
        }

        public void Navigate(Type page, object parameter)
        {
            if (EnsureFrameCreated())
                NavigationFrame.Navigate(page, parameter);
        }

        public bool EnsureFrameCreated()
        {
            if (NavigationFrame != null)
                return true;
            return false;
        }

        public void Reset()
        {
            NavigationFrame.BackStack.Clear();
            NavigationFrame.ForwardStack.Clear();

            var cacheSize = NavigationFrame.CacheSize;
            NavigationFrame.CacheSize = 0;
            NavigationFrame.CacheSize = cacheSize;

            FrameChanged?.Invoke(NavigationFrame, null); 
        }

        public void SetNavigationFrame(Frame frame)
        {
            NavigationFrame = frame;
            NavigationFrame.Navigated += NavigationFrame_Navigated;
            SystemNavigationManager.GetForCurrentView().BackRequested += NavigationService_BackRequested;
        }

        private void NavigationService_BackRequested(object sender, BackRequestedEventArgs e)
        {
            //if (SimpleIoc.Default.GetInstance<ShellViewModel>().IsHamburgerMenuPaneVisible)
            //{
            //    SimpleIoc.Default.GetInstance<ShellViewModel>().IsHamburgerMenuPaneVisible = false;
            //    e.Handled = true;
            //}
            //else
            NavigationBackRequested?.Invoke(sender, e);
            if (CanGoBack)
            {
                GoBack();
                e.Handled = true;
            }
        }

        private void NavigationFrame_Navigated(object sender, NavigationEventArgs e)
        {
            FrameChanged?.Invoke(sender, e); 
        }

        public void DeletePreviousPage()
        {

        } 
    }
}
