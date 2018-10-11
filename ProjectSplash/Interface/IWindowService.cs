using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;

namespace ProjectSplash.Interface
{
    public interface IWindowService
    {
        bool IsSubWindow { get; }

        CoreDispatcher CurrentDispatcher { get; }

        Task<int> CreateWindowAsync(Type type); 

        Task<int> CreateWindowAsync(Type type, object parameter);

        Task<int> CreateWindowAsync(Type type, object parameter, Size windowSize);

        Task SwitchToMainViewAsync();

        void Close();
    }
}
