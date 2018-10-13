using ProjectSplash.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjectSplash.Views
{ 
    public sealed partial class HomeView : Page
    {
        private HomeViewModel ViewModel;
        public HomeView()
        {
            this.InitializeComponent();
            this.ViewModel = (HomeViewModel)DataContext;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.OnNavigatedToAsync(e);
        }
    }
}
