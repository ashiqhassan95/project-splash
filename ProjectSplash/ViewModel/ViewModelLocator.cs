using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using ProjectSplash.Core.IRepository;
using ProjectSplash.Infrastructure.Repository;

namespace ProjectSplash.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(()=> SimpleIoc.Default);
            SimpleIoc.Default.Register<IPhotoRepository, PhotoRepository>();
            SimpleIoc.Default.Register<ISplashRepository, SplashRepository>();

            SimpleIoc.Default.Register<HomeViewModel>();
        }

        public HomeViewModel HomeViewModel => SimpleIoc.Default.GetInstance<HomeViewModel>();

    }
}
