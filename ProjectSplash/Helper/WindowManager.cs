using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Core;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using Windows.Foundation;
using ProjectSplash.Interface;

namespace ProjectSplash.Helper
{
    public class WindowManager : IWindowService
    {
        int mainViewId;
        int newViewId;

        public bool IsSubWindow
        {
            get
            {
                var core = CoreApplication.GetCurrentView();
                bool isMianWindow = core.IsMain;
                return !isMianWindow;
            }
        }

        public CoreDispatcher CurrentDispatcher
        {
            get
            {
                return CoreApplication.GetCurrentView().CoreWindow.Dispatcher;
            }
        }

        public async void Close()
        {
            //var currentView = CoreApplication.GetCurrentView();
            //currentView.CoreWindow.Close();

            var currentView = ApplicationView.GetForCurrentView();
            await currentView.TryConsolidateAsync();
        } 

        public async Task<int> CreateWindowAsync(Type type)
        {  
            CoreApplicationView newView = CoreApplication.CreateNewView();
            mainViewId = ApplicationView.GetForCurrentView().Id; 

            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(type);
                Window.Current.Content = frame;
                Window.Current.Activate();
                newViewId = ApplicationView.GetForCurrentView().Id; 
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId, ViewSizePreference.UseHalf);
            return newViewId;
        } 

        public async Task<int> CreateWindowAsync(Type type, object parameter)
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            mainViewId = ApplicationView.GetForCurrentView().Id;
             
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(type, parameter);
                Window.Current.Content = frame;
                Window.Current.Activate();
                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
            return newViewId;
        }

        public async Task<int> CreateWindowAsync(Type type, object parameter, Size windowSize)
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            mainViewId = ApplicationView.GetForCurrentView().Id;
            ApplicationView appView = null;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                appView = ApplicationView.GetForCurrentView();
                Frame frame = new Frame();
                frame.Navigate(type, parameter);
                Window.Current.Content = frame;
                Window.Current.Activate();
                newViewId = appView.Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
            return newViewId;
        } 

        public async Task SwitchToMainViewAsync()
        {
            try
            { 
                await ApplicationViewSwitcher.SwitchAsync(mainViewId, newViewId, ApplicationViewSwitchingOptions.ConsolidateViews); 
            }
            catch (Exception Ex)
            {

            }
        }
    }
}
