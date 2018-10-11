using ProjectSplash.Core.Model;
using ProjectSplash.Infrastructure.Repository;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace ProjectSplash.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            
        }

        private ObservableCollection<Photo> _latestPhotos;
        public ObservableCollection<Photo> LatestPhotos
        {
            get { return _latestPhotos; }
            set { _latestPhotos = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Photo> _popularPhotos;
        public ObservableCollection<Photo> PopularPhotos
        {
            get { return _popularPhotos; }
            set { _popularPhotos = value; RaisePropertyChanged(); }
        }

        public override Task OnNavigatedToAsync(NavigationEventArgs e)
        {
            return base.OnNavigatedToAsync(e);

        }
    }
}
    