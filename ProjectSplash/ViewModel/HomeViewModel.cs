using GalaSoft.MvvmLight.Command;
using ProjectSplash.Core.IRepository;
using ProjectSplash.Core.Model;
using ProjectSplash.Infrastructure;
using ProjectSplash.Infrastructure.Repository;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace ProjectSplash.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IPhotoRepository photoRepository;
        private readonly ISplashRepository splashRepository;

        public HomeViewModel(IPhotoRepository photoRepository, ISplashRepository splashRepository)
        {
            this.photoRepository = photoRepository;
            this.splashRepository = splashRepository;

            LoadMoreLatestPhotosCommand = new RelayCommand(async () => await LoadMoreLatestPhotosAsync());
            LoadMorePopularPhotosCommand = new RelayCommand(async () => await LoadMorePopularPhotosAsync());
            LoadMoreCollectionsCommand = new RelayCommand(async () => await LoadMoreCollectionsAsync());
        }  

        #region LatestPhotos Region

        private int CurrentLatestPhotosPage;

        private bool _isLatestPhotoLoading;
        public bool IsLatestPhotoLoading
        {
            get { return _isLatestPhotoLoading; }
            set { _isLatestPhotoLoading = value; RaisePropertyChanged(); }
        }

        private bool _isLatestPhotoLoadingMore;
        public bool IsLatestPhotoLoadingMore
        {
            get { return _isLatestPhotoLoadingMore; }
            set { _isLatestPhotoLoadingMore = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Photo> _latestPhotos;
        public ObservableCollection<Photo> LatestPhotos
        {
            get { return _latestPhotos; }
            set { _latestPhotos = value; RaisePropertyChanged(); }
        }

        private RelayCommand _loadMoreLatestPhotosCommand;
        public RelayCommand LoadMoreLatestPhotosCommand
        {
            get { return _loadMoreLatestPhotosCommand; }
            set { _loadMoreLatestPhotosCommand = value; RaisePropertyChanged(); }
        }
        #endregion

        #region PopularPhotos Region

        private int CurrentPopularPhotosPage;

        private bool _isPopularPhotoLoading;
        public bool IsPopularPhotoLoading
        {
            get { return _isPopularPhotoLoading; }
            set { _isPopularPhotoLoading = value; RaisePropertyChanged(); }
        }

        private bool _isPopularPhotoLoadingMore;
        public bool IsPopularPhotoLoadingMore
        {
            get { return _isPopularPhotoLoadingMore; }
            set { _isPopularPhotoLoadingMore = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Photo> _popularPhotos;
        public ObservableCollection<Photo> PopularPhotos
        {
            get { return _popularPhotos; }
            set { _popularPhotos = value; RaisePropertyChanged(); }
        }

        private RelayCommand _loadMorePopularPhotosCommand;
        public RelayCommand LoadMorePopularPhotosCommand
        {
            get { return _loadMorePopularPhotosCommand; }
            set { _loadMorePopularPhotosCommand = value; RaisePropertyChanged(); }
        }

        #endregion

        #region Collection Region

        private int CurrentCollectionsPage;

        private bool _isCollectionLoading;
        public bool IsCollectionLoading
        {
            get { return _isCollectionLoading; }
            set { _isCollectionLoading = value; RaisePropertyChanged(); }
        }

        private bool _isCollectionLoadingMore;
        public bool IsCollectionLoadingMore
        {
            get { return _isCollectionLoadingMore; }
            set { _isCollectionLoadingMore = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Collection> _collections;
        public ObservableCollection<Collection> Collections
        {
            get { return _collections; }
            set { _collections = value; RaisePropertyChanged(); }
        }

        private RelayCommand _loadMoreCollectionsCommand;
        public RelayCommand LoadMoreCollectionsCommand
        {
            get { return _loadMoreCollectionsCommand; }
            set { _loadMoreCollectionsCommand = value; RaisePropertyChanged(); }
        }

        #endregion

        #region Miscellaneous

        public RelayCommand DownloadsViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand AboutViewCommand { get; set; } 

        #endregion

        public override Task OnNavigatedToAsync(NavigationEventArgs e)
        {
            return base.OnNavigatedToAsync(e);

        }

        private async Task LoadLatestPhotosAsync()
        {
            if (LatestPhotos?.Count != 0)
                return;

            try
            {
                // Show UI Busy indicator
                IsLatestPhotoLoading = true;

                // Load photos from repo
                LatestPhotos = new ObservableCollection<Photo>(await Task.Run(async () => await photoRepository.GetPhotosAsync(Config.PerPage, CurrentLatestPhotosPage)));

                // Increment CurrentPage by one if last operation was success (check list items)
                if (LatestPhotos?.Count != 0)
                    CurrentLatestPhotosPage++;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                // Hide UI Busy indicator
                IsLatestPhotoLoading = false;
            }
        }

        private async Task LoadMoreLatestPhotosAsync()
        {
            if (IsLatestPhotoLoading && IsLatestPhotoLoadingMore)
                return;

            try
            {
                // Notify UI that more photos is loading
                IsLatestPhotoLoadingMore = true;

                var data = await Task.Run(async () => await photoRepository.GetPhotosAsync(Config.PerPage, CurrentLatestPhotosPage));
                if (data?.Count != 0)
                {
                    data.ForEach(LatestPhotos.Add);

                    // Increment CurrentPage by one
                    CurrentLatestPhotosPage++;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // Notify UI that more photos is loading finished
                IsLatestPhotoLoadingMore = false;
            }
        }

        private async Task LoadPopularPhotosAsync()
        {
            if (PopularPhotos?.Count != 0)
                return;

            try
            {
                // Show UI Busy indicator
                IsPopularPhotoLoading = true;

                // Load photos from repo
                PopularPhotos = new ObservableCollection<Photo>(await Task.Run(async () => await photoRepository.GetPhotosAsync(Config.PerPage, CurrentPopularPhotosPage, PhotoOrderBy.Popular)));

                // Increment CurrentPage by one if last operation was success (check list items)
                if (PopularPhotos?.Count != 0)
                    CurrentPopularPhotosPage++;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                // Hide UI Busy indicator
                IsPopularPhotoLoading = false;
            }
        }

        private async Task LoadMorePopularPhotosAsync()
        {
            if (IsPopularPhotoLoading && IsPopularPhotoLoadingMore)
                return;

            try
            {
                // Notify UI that more photos is loading
                IsPopularPhotoLoadingMore = true;

                var data = await Task.Run(async () => await photoRepository.GetPhotosAsync(Config.PerPage, CurrentPopularPhotosPage, PhotoOrderBy.Popular));
                if (data?.Count != 0)
                {
                    data.ForEach(PopularPhotos.Add);

                    // Increment CurrentPage by one
                    CurrentPopularPhotosPage++;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // Notify UI that more photos is loading finished
                IsPopularPhotoLoadingMore = false;
            }
        }

        private async Task LoadCollectionsAsync()
        {
            if (Collections?.Count != 0)
                return;

            try
            {
                // Show UI Busy indicator
                IsCollectionLoading = true;

                // Load photos from repo
                Collections = new ObservableCollection<Collection>(await Task.Run(async () => await splashRepository.GetCollectionsAsync(Config.PerPage, CurrentCollectionsPage)));

                // Increment CurrentPage by one if last operation was success (check list items)
                if (Collections?.Count != 0)
                    CurrentCollectionsPage++;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                // Hide UI Busy indicator
                IsCollectionLoading = false;
            }
        }

        private async Task LoadMoreCollectionsAsync()
        {
            if (IsCollectionLoading && IsCollectionLoadingMore)
                return;

            try
            {
                // Notify UI that more photos is loading
                IsCollectionLoadingMore = true;

                var data = await Task.Run(async () => await splashRepository.GetCollectionsAsync(Config.PerPage, CurrentCollectionsPage));
                if (data?.Count != 0)
                {
                    data.ForEach(Collections.Add);

                    // Increment CurrentPage by one
                    CurrentCollectionsPage++;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // Notify UI that more collection is loading finished
                IsCollectionLoadingMore = false;
            }
        } 
    }
}
