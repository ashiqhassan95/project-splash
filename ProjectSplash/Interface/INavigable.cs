using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
namespace ProjectSplash.Interface
{
    interface INavigable
    {
        Task OnNavigatedToAsync(NavigationEventArgs e);
        void OnNavigatedFrom(NavigationEventArgs e); 
    }
}
