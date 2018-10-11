using GalaSoft.MvvmLight.Ioc;
using ProjectSplash.Interface;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace ProjectSplash.ViewModel
{
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase, INavigable
    {
        protected readonly INavigationService navigationService;
        protected readonly IDialogService dialogService;
        protected readonly IWindowService windowService;
        protected readonly ILocalNotificationService localNotificationService;

        public ViewModelBase()
        {
            this.navigationService = navigationService ?? SimpleIoc.Default.GetInstance<INavigationService>();
            this.dialogService = dialogService ?? SimpleIoc.Default.GetInstance<IDialogService>();
            this.windowService = windowService ?? SimpleIoc.Default.GetInstance<IWindowService>();
            this.localNotificationService = localNotificationService ?? SimpleIoc.Default.GetInstance<ILocalNotificationService>();
        }

        public bool IsSubWindow => IsInDesignMode ? true : windowService.IsSubWindow; 

        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                if (_pageTitle != value)
                {
                    _pageTitle = value;
                    RaisePropertyChanged(); 
                }
            }
        } 

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }

         
        public virtual async Task OnNavigatedToAsync(NavigationEventArgs e)
        {
            return;
        }

        public virtual void OnNavigatedFrom(NavigationEventArgs e)
        {
            return;
        }

        public async Task PerformTaskOnMainUIAsync(DispatchedHandler action)
        {
            try
            {
                await CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, action);
            }
            catch(Exception ex)
            {

            } 
        }

        public async Task PerformTaskOnCurrentUIAsync(DispatchedHandler action)
        {
            var dispatcher = Window.Current.Dispatcher;
            await dispatcher.TryRunAsync(CoreDispatcherPriority.Normal, action);
        }
    }
}
